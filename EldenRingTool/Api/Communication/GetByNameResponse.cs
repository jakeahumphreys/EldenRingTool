using EldenRingTool.Api.Types;
using JCommon.Communication.External;

namespace EldenRingTool.Api.Communication;

public sealed class GetByNameResponse : BaseResponse
{
    public Boss Boss { get; set; }
}