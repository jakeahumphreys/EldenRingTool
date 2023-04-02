using EldenRingTool.EldenRingFanApi.Types;

namespace EldenRingTool.EldenRingFanApi.Communication;

public sealed class GetByIdResponse : BaseResponse
{
    public Boss Boss { get; set; }
}