namespace Vsk.VooDoo.Core.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using Refit;
    using Vsk.VooDoo.Core.DefaultImplementClasses;
    using Vsk.VooDoo.Core.Module;
    using Vsk.VooDoo.Core.Services;

    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Инициализация модулей сервиса
        /// </summary>
        public static void InitServiceModules(this IServiceCollection services, IList<string> dllPrefix)
        {
            LoaderModulesHelper.LoadAndInitServiceModules(services, dllPrefix);
        }

        /// <summary>
        /// Регистрация WebApi сервиса
        /// </summary>
        /// <typeparam name="TService">Интерфейс сервиса</typeparam>
        /// <typeparam name="TImplementation">Реализация интерфейса сервиса</typeparam>
        /// <param name="services"></param>
        public static void RegisterWebApiService<TService, TImplementation>(this IServiceCollection services)
            where TService : class, IWebApiService
            where TImplementation : class, TService
        {
            services.AddTransient<TService, TImplementation>();
        }

        /// <summary>
        /// Регистрация клиента WebApi сервиса
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="services"></param>
        /// <param name="settings">Настройки для http-refit клиента если сервис не находится в данном инстансе приложения</param>
        public static IHttpClientBuilder RegisterWebApiClient<TService>(this IServiceCollection services, RefitSettings? settings = null)
            where TService : class, IWebApiService
        {
            if (!services.Any(x => x.ServiceType == typeof(TService)))
            {
                return services.AddRefitClient<TService>(settings);
            }

            return new NullableHttpClientBuilder(services);
        }
    }
}
