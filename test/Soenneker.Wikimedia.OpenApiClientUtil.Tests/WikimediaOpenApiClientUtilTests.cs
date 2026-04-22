using Soenneker.Wikimedia.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Wikimedia.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class WikimediaOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IWikimediaOpenApiClientUtil _openapiclientutil;

    public WikimediaOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IWikimediaOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
