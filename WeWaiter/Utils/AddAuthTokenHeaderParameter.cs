using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WeWaiter
{
    /// <summary>
    /// this class is for swagger to generate AuthToken Header filed on swagger UI
    /// </summary>
    public class AddAuthTokenHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            //先判断是否是匿名访问,
            if (context.ApiDescription.ActionDescriptor is ControllerActionDescriptor descriptor)
            {
                var actionAttributes = descriptor.MethodInfo.GetCustomAttributes(inherit: true);

                var isAnonymous = actionAttributes.Any(a => a is AllowAnonymousAttribute);
                var isAuthorized = actionAttributes.Any(a => a is AuthorizeAttribute);

                //非匿名的方法,链接中添加 access_token 值
                if (!isAnonymous && isAuthorized)
                {
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = "token",
                        In = ParameterLocation.Header,
                        Description = "access token",
                        Schema = new OpenApiSchema()
                        {
                            Type = "string"
                        },
                        Required = true
                    });
                }
            }
        }
    }

}
