using EldenRingTool.Common;

namespace EldenRingTool.Api.Communication;

public class BaseResponse
{
    public Error Error { get; set; }

    public T WithError<T>(Error error) where T : BaseResponse
    {
        Error = error;

        return (T) this;
    }
}