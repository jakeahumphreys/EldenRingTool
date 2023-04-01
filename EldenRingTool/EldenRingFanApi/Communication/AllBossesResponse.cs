using EldenRingTool.EldenRingFanApi.Types;

namespace EldenRingTool.EldenRingFanApi.Communication;

public sealed class AllBossesResponse : BaseResponse
{
    public List<Boss> Bosses { get; set; }
}