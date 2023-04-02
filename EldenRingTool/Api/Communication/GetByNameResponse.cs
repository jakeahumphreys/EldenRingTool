using EldenRingTool.Api.Types;

namespace EldenRingTool.Api.Communication;

public sealed class GetByNameResponse : BaseResponse
{
    public Boss Boss { get; set; }
}