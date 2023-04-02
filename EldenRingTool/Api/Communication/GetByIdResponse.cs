using EldenRingTool.Api.Types;

namespace EldenRingTool.Api.Communication;

public sealed class GetByIdResponse : BaseResponse
{
    public Boss Boss { get; set; }
}