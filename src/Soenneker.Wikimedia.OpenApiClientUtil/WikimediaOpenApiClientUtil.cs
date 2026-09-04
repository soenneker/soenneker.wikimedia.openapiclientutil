using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Wikimedia.HttpClients.Abstract;
using Soenneker.Wikimedia.OpenApiClientUtil.Abstract;
using Soenneker.Wikimedia.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Wikimedia.OpenApiClientUtil;

/// <inheritdoc cref="IWikimediaOpenApiClientUtil" />
public sealed class WikimediaOpenApiClientUtil : IWikimediaOpenApiClientUtil
{
    private readonly AsyncSingleton<WikimediaOpenApiClient> _client;

    public WikimediaOpenApiClientUtil(IWikimediaOpenApiHttpClient httpClientProvider)
    {
        _client = new AsyncSingleton<WikimediaOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientProvider.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new WikimediaOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<WikimediaOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
