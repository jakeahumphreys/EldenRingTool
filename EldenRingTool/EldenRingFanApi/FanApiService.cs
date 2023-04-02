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

    public async Task<GetByNameResponse> GetByName(string name)
    {
        var parsedName = name.Replace(" ", "%20");
        var result = await _fanApiClient.GetByName(parsedName);

        if (result.IsFailure)
            return new GetByNameResponse().WithError<GetByNameResponse>(result.Errors.First());

        return new GetByNameResponse
        {
            Boss = result.Content.Data.First()
        };
    }

    public async Task<GetByIdResponse> GetById(string id)
    {
        var result = await _fanApiClient.GetById(id);

        if (result.IsFailure)
            return new GetByIdResponse().WithError<GetByIdResponse>(result.Errors.First());

        return new GetByIdResponse
        {
            Boss = result.Content.Data.First()
        };
    }
}