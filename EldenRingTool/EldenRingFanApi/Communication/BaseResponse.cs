namespace EldenRingTool.EldenRingFanApi.Communication;

public class BaseResponse
{
    public Error Error { get; set; }
}

public class Error
{
    public string Message { get; set; }
}