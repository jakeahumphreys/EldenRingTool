using EldenRingTool.Api.Communication;

namespace EldenRingTool.Api;

public interface IApiService
{
    public Task<AllBossesResponse> GetAll();
}

public sealed class ApiService : IApiService
{
    private readonly IApiClient _apiClient;

    public ApiService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<AllBossesResponse> GetAll()
    {
        var result = await _apiClient.GetAllAsync();

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
        var result = await _apiClient.GetByName(parsedName);

        if (result.IsFailure)
            return new GetByNameResponse().WithError<GetByNameResponse>(result.Errors.First());

        return new GetByNameResponse
        {
            Boss = result.Content.Data.First()
        };
    }

    public async Task<GetByIdResponse> GetById(string id)
    {
        var result = await _apiClient.GetById(id);

        if (result.IsFailure)
            return new GetByIdResponse().WithError<GetByIdResponse>(result.Errors.First());

        return new GetByIdResponse
        {
            Boss = result.Content.Data.First()
        };
    }
}