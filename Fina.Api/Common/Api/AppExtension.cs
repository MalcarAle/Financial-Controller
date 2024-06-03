using Swashbuckle.AspNetCore.SwaggerUI;

namespace Fina.Api.Common.Api
{
    public static class AppExtension
    {
        public static void ConfigureDevEnvironment(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Financial App");
                c.RoutePrefix = "swagger"; // Define a rota para acessar o Swagger UI
                c.DocumentTitle = "Your API Documentation"; // Título da página do Swagger UI
                c.DocExpansion(DocExpansion.List); // Define o modo de expansão da documentação
            });

        }
    }
}
