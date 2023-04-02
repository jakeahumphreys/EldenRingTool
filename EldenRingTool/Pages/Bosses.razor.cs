using EldenRingTool.Api;
using EldenRingTool.Api.Types;
using EldenRingTool.Common;
using Microsoft.AspNetCore.Components;

namespace EldenRingTool.Pages;

public partial class Bosses
{
    [Inject]
    protected IFanApiService FanApiService { get; set; }
    
    public List<Boss> AllBosses { get; set; }
    public Error Error { get; set; }

    protected override async Task OnInitializedAsync()
    {
        AllBosses = new List<Boss>();
        
        var allBossesResponse = await FanApiService.GetAll();

        if (allBossesResponse.Error != null)
        {
            Error = allBossesResponse.Error;
        }

        AllBosses = allBossesResponse.Bosses;
    }
}