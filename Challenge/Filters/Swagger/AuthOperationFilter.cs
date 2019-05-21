using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Challenge.Filters.Swagger
{
    public class AuthOperationFilter : IOperationFilter

    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (apiDescription.GetControllerAndActionAttributes<AuthFilterAttribute>().Any())
            {
                if (operation == null) return;

                if (operation.parameters == null)
                {
                    operation.parameters = new List<Parameter>();
                }

                var parameter = new Parameter
                {
                    description = "The authorization token",
                    @in = "header",
                    name = "Authorization",
                    required = true,
                    type = "string"
                };


                parameter.required = true;
                operation.parameters.Add(parameter);
            }
        }
    }
}