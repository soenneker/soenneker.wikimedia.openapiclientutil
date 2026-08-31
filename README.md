[![](https://img.shields.io/nuget/v/soenneker.wikimedia.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.wikimedia.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.wikimedia.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.wikimedia.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.wikimedia.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.wikimedia.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.wikimedia.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.wikimedia.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Wikimedia.OpenApiClientUtil

Provides a cached `WikimediaOpenApiClient` that uses the configured Wikimedia HTTP client for its base address and request headers.

## Installation

```bash
dotnet add package Soenneker.Wikimedia.OpenApiClientUtil
```

## Configuration

```json
{
  "Wikimedia": {
    "ClientBaseUrl": "https://en.wikipedia.org/api/rest_v1",
    "AccessToken": "your-access-token",
    "UserAgent": "MyApp/1.0 (https://example.com/contact)"
  }
}
```

Change `ClientBaseUrl` to select another Wikimedia project or language, such as `https://commons.wikimedia.org/api/rest_v1`. `Wikimedia:ApiKey` remains supported as a legacy alias for `AccessToken`.

## Registration and usage

```csharp
using Soenneker.Wikimedia.OpenApiClient.Models;
using Soenneker.Wikimedia.OpenApiClientUtil.Abstract;
using Soenneker.Wikimedia.OpenApiClientUtil.Registrars;

services.AddWikimediaOpenApiClientUtilAsSingleton();

public sealed class ArticleService
{
    private readonly IWikimediaOpenApiClientUtil _clientProvider;

    public ArticleService(IWikimediaOpenApiClientUtil clientProvider)
    {
        _clientProvider = clientProvider;
    }

    public async Task<string?> GetSummary(CancellationToken cancellationToken)
    {
        var client = await _clientProvider.Get(cancellationToken);
        Summary? summary = await client.Page.Summary["Earth"]
            .GetAsync(cancellationToken: cancellationToken);

        return summary?.Extract;
    }
}
```

`AddWikimediaOpenApiClientUtilAsScoped()` creates one generated client per scope while continuing to use the singleton HTTP transport. Disposing the scoped provider does not remove that shared transport.
