namespace Vsk.VooDoo.WebHost.Extensions
{
    using Microsoft.AspNetCore.Builder;

    public static class WebApplicationBuilderExtensions
    {
        public static void RunAsService(this WebApplicationBuilder builder)
        {
            var app = builder.Build();

            // Добавление swagger-а
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
