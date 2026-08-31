using Soenneker.Wikimedia.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Wikimedia.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached Wikimedia API client backed by the configured HTTP transport.
/// </summary>
public interface IWikimediaOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached Wikimedia API client.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured Wikimedia API client.</returns>
    ValueTask<WikimediaOpenApiClient> Get(CancellationToken cancellationToken = default);
}
