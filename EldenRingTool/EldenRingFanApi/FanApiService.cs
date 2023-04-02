using EldenRingTool.EldenRingFanApi.Communication;

namespace EldenRingTool.EldenRingFanApi;

public interface IFanApiService
{
    public Task<AllBossesResponse> GetAll();
}

public sealed class FanApiService : IFanApiService
{
    private readonly IFanApiClient _fanApiClient;

    public FanApiService(IFanApiClient fanApiClient)
    {
        _fanApiClient = fanApiClient;
    }

    public async Task<AllBossesResponse> GetAll()
    {
        var result = await _fanApiClient.GetAllAsync();

        if (result.IsFailure)
            return new AllBossesResponse().WithError<AllBossesResponse>(result.Errors.First());

        return new AllBossesResponse
        {
            Bosses = result.Content
        };
    }
}