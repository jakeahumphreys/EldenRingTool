using EldenRingTool.Common;
using EldenRingTool.EldenRingFanApi;
using EldenRingTool.EldenRingFanApi.Communication;
using EldenRingTool.EldenRingFanApi.Types;
using EldenRingTool.Tests.EldenRingFanApi.Helpers;
using Moq;

namespace EldenRingTool.Tests.EldenRingFanApi.GivenARequestForAllBosses;

[TestFixture]
public class WhenThereAreResults
{
    private AllBossesResponse _result;

    [OneTimeSetUp]
    public void Setup()
    {
        var client = new Mock<IFanApiClient>();

        var testBoss = new TestBossBuilder()
            .WithId("1")
            .WithDescription("Test Boss")
            .WithLocation("Somewhere in the code")
            .WithName("Test Boss")
            .Build();

        client.Setup(x => x.GetAll()).Returns(new Result<AllBossesResponse>(new AllBossesResponse
        {
            Bosses = new List<Boss> {testBoss}
        }));
        
        var fanApiService = new FanApiService(client.Object);
        _result = fanApiService.GetAll();
    }

    [Test]
    public void ThenNoErrorsAreReturned()
    {
        Assert.That(_result.Error, Is.Null);
    }

    [Test]
    public void ThenTheExpectedResultsAreReturned()
    {
        Assert.That(_result.Bosses.Count, Is.EqualTo(1));
    }
}