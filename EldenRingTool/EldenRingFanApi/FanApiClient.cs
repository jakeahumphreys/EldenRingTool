using EldenRingTool.Common;
using EldenRingTool.EldenRingFanApi.Communication;
using EldenRingTool.EldenRingFanApi.Types;
using Newtonsoft.Json;

namespace EldenRingTool.EldenRingFanApi;

public interface IFanApiClient
{
    public Task<Result<BossesRoot>> GetByName(string name);
    public Task<Result<BossesRoot>> GetById(string id);
    public Task<Result<List<Boss>>> GetAllAsync();
}

public sealed class FanApiClient : IFanApiClient
{
    private const string BaseUrl = "https://eldenring.fanapis.com/api";

    public async Task<Result<BossesRoot>> GetByName(string name)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                var uri = new Uri($"{BaseUrl}/bosses?name={name}");
                using (var response = await httpClient.GetAsync(uri))
                {
                    if(!response.IsSuccessStatusCode)
                        return new Result<BossesRoot>().WithError($"The API returned a non-success status code: {response.StatusCode}.");
                    
                    var result = await response.Content.ReadAsStringAsync();

                    if(string.IsNullOrWhiteSpace(result))
                        return new Result<BossesRoot>().WithError($"No response was returned from the API.");

                    var parsedResponse = JsonConvert.DeserializeObject<BossesRoot>(result);
                    
                    if(parsedResponse.Count == 0)
                        return new Result<BossesRoot>().WithError($"{name} was not found on the API.");

                    return new Result<BossesRoot>(parsedResponse);
                }
            }
        }
        catch (Exception exception)
        {
            return new Result<BossesRoot>().WithError(exception.Message);
        }
    }
    
    public async Task<Result<BossesRoot>> GetById(string id)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                var uri = new Uri($"{BaseUrl}/bosses/{id}");
                using (var response = await httpClient.GetAsync(uri))
                {
                    if(!response.IsSuccessStatusCode)
                        return new Result<BossesRoot>().WithError($"The API returned a non-success status code: {response.StatusCode}.");
                    
                    var result = await response.Content.ReadAsStringAsync();

                    if(string.IsNullOrWhiteSpace(result))
                        return new Result<BossesRoot>().WithError($"No response was returned from the API.");

                    var parsedResponse = JsonConvert.DeserializeObject<BossesRoot>(result);
                    
                    if(parsedResponse.Count == 0)
                        return new Result<BossesRoot>().WithError($"{id} was not found on the API.");

                    return new Result<BossesRoot>(parsedResponse);
                }
            }
        }
        catch (Exception exception)
        {
            return new Result<BossesRoot>().WithError(exception.Message);
        }
    }
    
    public async Task<Result<List<Boss>>> GetAllAsync()
    {
        try
        {
            var pageSize = 20;
            var pageNumber = 0;

            var bosses = new List<Boss>();

            using (var httpClient = new HttpClient())
            {
                var moreData = true;
                while (moreData)
                {
                    var uri = new Uri($"{BaseUrl}/bosses?limit={pageSize}&page={pageNumber}");
                    using (HttpResponseMessage response = await httpClient.GetAsync(uri))
                    {
                        if (!response.IsSuccessStatusCode)
                            return new Result<List<Boss>>().WithError($"The API returned a non-success status code: {response.StatusCode}.");

                        var result = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrWhiteSpace(result))
                            return new Result<List<Boss>>().WithError("No response was returned from the API.");

                        var parsedResponse = JsonConvert.DeserializeObject<BossesRoot>(result);
                        bosses.AddRange(parsedResponse.Data);
                    
                        if (parsedResponse.Count == 0 || parsedResponse.Count < pageSize)
                        {
                            moreData = false;
                        }
                        else
                        {
                            pageNumber++;
                        }
                    }
                }
            }

            return new Result<List<Boss>>(bosses);
        }
        catch (Exception exception)
        {
            return new Result<List<Boss>>().WithError(exception.Message);
        }
    }
}