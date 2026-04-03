using Soenneker.Wikimedia.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Wikimedia.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IWikimediaOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<WikimediaOpenApiClient> Get(CancellationToken cancellationToken = default);
}
