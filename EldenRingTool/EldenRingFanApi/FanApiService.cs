using EldenRingTool.EldenRingFanApi.Communication;

namespace EldenRingTool.EldenRingFanApi;

public interface IFanApiService
{
    public AllBossesResponse GetAll();
}

public sealed class FanApiService : IFanApiService
{
    private readonly IFanApiClient _fanApiClient;

    public FanApiService(IFanApiClient fanApiClient)
    {
        _fanApiClient = fanApiClient;
    }

    public AllBossesResponse GetAll()
    {
        return _fanApiClient.GetAll();
    }
}