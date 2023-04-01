using EldenRingTool.EldenRingFanApi.Communication;
using EldenRingTool.EldenRingFanApi.Types;
using Newtonsoft.Json;

namespace EldenRingTool.EldenRingFanApi;

public sealed class FanApiClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://eldenring.fanapis.com/api";

    public FanApiClient()
    {
        _httpClient = new HttpClient();
    }

    public AllBossesResponse GetAll()
    {
        var uri = new Uri($"{BaseUrl}/bosses");
        var responseString = _httpClient.GetStringAsync(uri).Result;

        if (string.IsNullOrWhiteSpace(responseString))
            return new AllBossesResponse().WithError<AllBossesResponse>(new Error{Message = "Unable to fetch bosses."});

        var parsedResponse = JsonConvert.DeserializeObject<BossesRoot>(responseString);

        if (parsedResponse.Data.Count == 0)
            return new AllBossesResponse().WithError<AllBossesResponse>(new Error {Message = "No bosses were returned from the API."});

        return new AllBossesResponse
        {
            Bosses = parsedResponse.Data
        };
    }
}