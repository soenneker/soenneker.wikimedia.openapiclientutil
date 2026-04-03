using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Wikimedia.HttpClients.Abstract;
using Soenneker.Wikimedia.OpenApiClientUtil.Abstract;
using Soenneker.Wikimedia.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Wikimedia.OpenApiClientUtil;

///<inheritdoc cref="IWikimediaOpenApiClientUtil"/>
public sealed class WikimediaOpenApiClientUtil : IWikimediaOpenApiClientUtil
{
    private readonly AsyncSingleton<WikimediaOpenApiClient> _client;

    public WikimediaOpenApiClientUtil(IWikimediaOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<WikimediaOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Wikimedia:ApiKey");
            string authHeaderValueTemplate = configuration["Wikimedia:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
