using Soenneker.Wikimedia.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Wikimedia.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class WikimediaOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IWikimediaOpenApiClientUtil _openapiclientutil;

    public WikimediaOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IWikimediaOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
