using EldenRingTool.EldenRingFanApi.Types;

namespace EldenRingTool.EldenRingFanApi.Communication;

public sealed class GetByNameResponse : BaseResponse
{
    public Boss Boss { get; set; }
}