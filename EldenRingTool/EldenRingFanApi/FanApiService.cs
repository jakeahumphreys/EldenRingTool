using EldenRingTool.EldenRingFanApi.Communication;

namespace EldenRingTool.EldenRingFanApi;

public interface IFanApiService
{
    public AllBossesResponse GetAll();
}

public sealed class FanApiService : IFanApiService
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