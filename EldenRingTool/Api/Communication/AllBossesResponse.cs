using EldenRingTool.Api.Types;
using JCommon.Communication.External;

namespace EldenRingTool.Api.Communication;

public sealed class AllBossesResponse : BaseResponse
{
    public List<Boss> Bosses { get; set; }

    public AllBossesResponse()
    {
        Bosses = new List<Boss>();
    }
}