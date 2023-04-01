using EldenRingTool.Common;
using EldenRingTool.EldenRingFanApi.Communication;
using EldenRingTool.EldenRingFanApi.Types;
using Newtonsoft.Json;

namespace EldenRingTool.EldenRingFanApi;

public interface IFanApiClient
{
    public Result<AllBossesResponse> GetAll();
}

public sealed class FanApiClient : IFanApiClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://eldenring.fanapis.com/api";

    public FanApiClient()
    {
        _httpClient = new HttpClient();
    }

    public Result<AllBossesResponse> GetAll()
    {
        var uri = new Uri($"{BaseUrl}/bosses");
        var responseString = _httpClient.GetStringAsync(uri).Result;

        if (string.IsNullOrWhiteSpace(responseString))
            return new Result<AllBossesResponse>().WithError("No response was returned from the API.");

        var parsedResponse = JsonConvert.DeserializeObject<BossesRoot>(responseString);

        if (parsedResponse.Data.Count == 0)
            return new Result<AllBossesResponse>().WithError("No results were returned from the API.");

        return new Result<AllBossesResponse>(new AllBossesResponse
        {

            Bosses = parsedResponse.Data
        });
    }
}