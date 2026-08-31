using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Wikimedia.HttpClients.Registrars;
using Soenneker.Wikimedia.OpenApiClientUtil.Abstract;

namespace Soenneker.Wikimedia.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the cached Wikimedia API client provider.
/// </summary>
public static class WikimediaOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds the Wikimedia API client provider as a singleton service.
    /// </summary>
    public static IServiceCollection AddWikimediaOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddWikimediaOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IWikimediaOpenApiClientUtil, WikimediaOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds the Wikimedia API client provider as a scoped service while retaining the singleton HTTP transport.
    /// </summary>
    public static IServiceCollection AddWikimediaOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddWikimediaOpenApiHttpClientAsSingleton()
                .TryAddScoped<IWikimediaOpenApiClientUtil, WikimediaOpenApiClientUtil>();

        return services;
    }
}
