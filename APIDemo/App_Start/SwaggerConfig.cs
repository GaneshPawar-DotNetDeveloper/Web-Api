using System.Reflection;
using System.Web.Http;
using Swashbuckle.Application;

public class SwaggerConfig
{
    private static Assembly thisAssembly;

    public static void Register()
    {
        GlobalConfiguration.Configuration
            .EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "API Demo");
            })
            .EnableSwaggerUi(c =>
            {
                c.DisableValidator(); // Example customization
                c.DocumentTitle("My Custom API Documentation");
                c.InjectStylesheet(thisAssembly, "MyProject.SwaggerExtensions.custom.css");
                c.InjectJavaScript(thisAssembly, "MyProject.SwaggerExtensions.custom.js");
                c.CustomAsset("index", thisAssembly, "MyProject.SwaggerExtensions.index.html");
            });
    }
}
