using EldenRingTool.Common;

namespace EldenRingTool.EldenRingFanApi.Communication;

public class BaseResponse
{
    public Error Error { get; set; }

    public T WithError<T>(Error error) where T : BaseResponse
    {
        Error = error;

        return (T) this;
    }
}