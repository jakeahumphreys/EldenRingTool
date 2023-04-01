using EldenRingTool.EldenRingFanApi;
using EldenRingTool.EldenRingFanApi.Types;
using Microsoft.AspNetCore.Components;

namespace EldenRingTool.Pages;

public partial class Bosses
{
    [Inject]
    protected IFanApiService FanApiService { get; set; }
    
    public List<Boss> AllBosses { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var allBossesResponse = FanApiService.GetAll();

        if (allBossesResponse.Error != null)
        {
            //handle error
        }

        AllBosses = allBossesResponse.Bosses;
    }
}