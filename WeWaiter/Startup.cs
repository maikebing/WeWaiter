using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Senparc.CO2NET;
using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP;
using Senparc.Weixin.RegisterServices;
using Senparc.Weixin.TenPay;
using Senparc.Weixin.WxOpen;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using WeWaiter.Data;
using WeWaiter.Utils;

namespace WeWaiter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure =>
            {
                configure.AddConsole()
                .AddJournal();
            });
            services.AddSwaggerGen(c =>
            {
                //配置第一个Doc
                c.SwaggerDoc("v1", new Info { Title = "WeWaiter Server", Version = "v1" });

                c.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WeWaiter.xml"));
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMemoryCache();//使用本地缓存必须添加

            services.AddSession();//使用Session
            services.AddMvcCore().AddApiExplorer();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var connectionString = Configuration.GetConnectionString("WeWaiterContext");
            services.AddEntityFrameworkNpgsql().AddDbContext<WeWaiterContext>(options => options.UseNpgsql(connectionString));
            services.AddOptions();

            services.ConfigureJwtAuthentication();
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
            });
            services.AddSenparcGlobalServices(Configuration)//Senparc.CO2NET 全局注册
                   .AddSenparcWeixinServices(Configuration);//Senparc.Weixin 注册
            Utils.Server.ImageHost = Configuration["ImageHostURL"];
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.ShowExtensions();
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.RoutePrefix = "swagger";
            });
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc();
            var senparcWeixinSetting = Configuration.GetSection("SenparcWeixinSetting").Get<SenparcWeixinSetting>();
            var snparcSetting = Configuration.GetSection("SenparcSetting").Get<SenparcSetting>();
            IRegisterService register = RegisterService.Start(env, snparcSetting)
                                                 .UseSenparcGlobal();

            register.UseSenparcWeixin(senparcWeixinSetting)
             //注意：上一行没有 ; 下面可接着写 .RegisterXX()

            #region 注册公众号或小程序（按需）

             //注册公众号（可注册多个）
             .RegisterMpAccount(senparcWeixinSetting, "鸿运博纳")
             //注册多个公众号或小程序（可注册多个）
             .RegisterWxOpenAccount(senparcWeixinSetting, "WeWaiter")

          //除此以外，仍然可以在程序任意地方注册公众号或小程序：
          //  AccessTokenContainer.Register(appId, appSecret, name);//命名空间：Senparc.Weixin.MP.Containers

            #endregion 注册公众号或小程序（按需）

            #region 注册企业号（按需）

          //注册企业微信（可注册多个）
          // .RegisterWorkAccount(senparcWeixinSetting, "【盛派网络】企业微信")

          //除此以外，仍然可以在程序任意地方注册企业微信：
          //AccessTokenContainer.Register(corpId, corpSecret, name);//命名空间：Senparc.Weixin.Work.Containers

            #endregion 注册企业号（按需）

            #region 注册微信支付（按需）

          //注册旧微信支付版本（V2）（可注册多个）
          //   .RegisterTenpayOld(senparcWeixinSetting, "【盛派网络小助手】公众号")//这里的 name 和第一个 RegisterMpAccount() 中的一致，会被记录到同一个 SenparcWeixinSettingItem 对象中

          // 注册最新微信支付版本（V3）（可注册多个）
          .RegisterTenpayV3(senparcWeixinSetting, null);//记录到同一个 SenparcWeixinSettingItem 对象中

            #endregion 注册微信支付（按需）
        }
    }
}