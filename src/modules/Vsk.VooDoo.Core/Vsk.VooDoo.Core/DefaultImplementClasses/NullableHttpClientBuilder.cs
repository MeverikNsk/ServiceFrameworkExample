namespace Vsk.VooDoo.Core.DefaultImplementClasses
{
    using Microsoft.Extensions.DependencyInjection;

    internal class NullableHttpClientBuilder : IHttpClientBuilder
    {
        private readonly IServiceCollection _services;

        public NullableHttpClientBuilder(IServiceCollection services)
        {
            _services = services;
        }

        public string Name => nameof(NullableHttpClientBuilder);

        public IServiceCollection Services => _services;
    }
}
