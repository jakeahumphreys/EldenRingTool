using EldenRingTool.Api.Types;
using JCommon.Communication.External;

namespace EldenRingTool.Api.Communication;

public sealed class GetByIdResponse : BaseResponse
{
    public Boss Boss { get; set; }
}