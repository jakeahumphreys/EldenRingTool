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
        var result = _fanApiClient.GetAll();

        if (result.IsFailure)
            return new AllBossesResponse().WithError<AllBossesResponse>(result.Errors.First());

        return result.Content;
    }
}