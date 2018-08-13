using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
namespace WeWaiter
{
    public class AddAuthTokenHeaderParameter : IOperationFilter
    {

        public void Apply(Operation operation, OperationFilterContext context)
        {

            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }
            operation.Parameters.Add( new NonBodyParameter()
            {
                Name = "token",
                In = "header",
                Type = "string",
                Description = "token认证信息",
                Required = true
            });
        }
    }

}
