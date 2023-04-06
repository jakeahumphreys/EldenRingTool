using EldenRingTool.Api;
using EldenRingTool.Api.Types;
using JCommon.ErrorHandling;
using Microsoft.AspNetCore.Components;

namespace EldenRingTool.Pages;

public partial class Bosses
{
    [Inject]
    protected IApiService ApiService { get; set; }
    
    public List<Boss> AllBosses { get; set; }
    public Error Error { get; set; }

    protected override async Task OnInitializedAsync()
    {
        AllBosses = new List<Boss>();
        
        var allBossesResponse = await ApiService.GetAll();

        if (allBossesResponse.Error != null)
        {
            Error = allBossesResponse.Error;
        }

        AllBosses = allBossesResponse.Bosses;
    }
}