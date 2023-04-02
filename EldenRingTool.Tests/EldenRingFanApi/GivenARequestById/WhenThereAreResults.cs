using EldenRingTool.Api;
using EldenRingTool.Api.Communication;
using EldenRingTool.Api.Types;
using EldenRingTool.Common;
using EldenRingTool.Tests.EldenRingFanApi.Helpers;
using Moq;

namespace EldenRingTool.Tests.EldenRingFanApi.GivenARequestById;

public sealed class WhenThereAreResults
{
    private Task<GetByIdResponse> _result;

    [OneTimeSetUp]
    public void Setup()
    {
        var client = new Mock<IApiClient>();

        var testBoss = new TestBossBuilder()
            .WithId("1")
            .WithDescription("Test Boss")
            .WithLocation("Somewhere in the code")
            .WithName("Test Boss")
            .Build();

        client.Setup(x => x.GetByIdAsync(It.Is<string>(y => y == "test"))).ReturnsAsync(new Result<BossesRoot>
        {
            Content = new BossesRoot
            {
                Data = new List<Boss>
                {
                    testBoss
                }
            }
        });
        
        var fanApiService = new ApiService(client.Object);
        _result = fanApiService.GetById("test");
    }

    [Test]
    public void ThenNoErrorsAreReturned()
    {
        Assert.That(_result.Result.Error, Is.Null);
    }

    [Test]
    public void ThenTheExpectedResultsAreReturned()
    {
        Assert.That(_result.Result.Boss.Name, Is.EqualTo("Test Boss"));
    }
}