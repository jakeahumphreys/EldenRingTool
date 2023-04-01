using EldenRingTool.EldenRingFanApi.Communication;

namespace EldenRingTool.EldenRingFanApi;

public sealed class FanApiService
{
    private readonly FanApiClient _fanApiClient;

    public FanApiService()
    {
        _fanApiClient = new FanApiClient();
    }

    public AllBossesResponse GetAll()
    {
        return _fanApiClient.GetAll();
    }
}