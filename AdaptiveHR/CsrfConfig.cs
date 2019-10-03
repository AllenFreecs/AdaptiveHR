using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace AdaptiveHR
{
    public class CsrfConfig : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {

            if (context.MethodInfo.CustomAttributes.Any(c => c.AttributeType == typeof(ValidateAntiForgeryTokenAttribute)))
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<IParameter>();

                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "XSRF-TOKEN",
                    In = "header",
                    Type = "string",
                    Required = false,
                });
            };
        }
    }
}
