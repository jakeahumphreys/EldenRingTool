// using EldenRingTool.EldenRingFanApi;
// using EldenRingTool.EldenRingFanApi.Communication;
// using EldenRingTool.EldenRingFanApi.Types;
// using EldenRingTool.Tests.EldenRingFanApi.Helpers;
// using Moq;
//
// namespace EldenRingTool.Tests.EldenRingFanApi.GivenARequestForAllBosses;
//
// [TestFixture]
// public class WhenThereAreNoResults
// {
//     private AllBossesResponse _result;
//
//     [OneTimeSetUp]
//     public void Setup()
//     {
//         var client = new Mock<IFanApiClient>();
//
//         client.Setup(x => x.GetAll()).Returns(new AllBossesResponse {Bosses = new List<Boss>()});
//         
//         var fanApiService = new FanApiService(client.Object);
//         _result = fanApiService.GetAll();
//     }
//
//     [Test]
//     public void ThenAnErrorIsReturned()
//     {
//         Assert.That(_result.Error, Is.Not.Null);
//         Assert.That(_result.Error.Message, Is.EqualTo("No bosses were returned from the API."));
//     }
//
//     [Test]
//     public void ThenTheExpectedResultsAreReturned()
//     {
//         Assert.That(_result.Bosses, Is.Empty);
//     }
// }