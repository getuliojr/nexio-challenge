using Challenge.Filters.Swagger;
using Swashbuckle.Application;
using System.Web.Http;

namespace Challenge
{
    public static class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Nexio challenge");
                        c.IncludeXmlComments(GetXmlCommentsPath());
                        c.OperationFilter<AuthOperationFilter>();
                    })
                .EnableSwaggerUi(c =>
                    {

                    });
        }

        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\Challenge.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
