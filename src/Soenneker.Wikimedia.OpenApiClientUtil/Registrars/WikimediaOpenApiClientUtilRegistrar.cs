using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Wikimedia.HttpClients.Registrars;
using Soenneker.Wikimedia.OpenApiClientUtil.Abstract;

namespace Soenneker.Wikimedia.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class WikimediaOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="WikimediaOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddWikimediaOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddWikimediaOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IWikimediaOpenApiClientUtil, WikimediaOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="WikimediaOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddWikimediaOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddWikimediaOpenApiHttpClientAsSingleton()
                .TryAddScoped<IWikimediaOpenApiClientUtil, WikimediaOpenApiClientUtil>();

        return services;
    }
}
