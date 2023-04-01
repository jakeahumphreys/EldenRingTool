namespace EldenRingTool.Common;

public class Result<T>
{
    public T Content { get; set; }
    public List<Error> Errors { get; set; }
    public bool IsFailure => Errors.Any();

    public Result()
    {
        Errors = new List<Error>();
    }

    public Result(T content)
    {
        Errors = new List<Error>();
        Content = content;
    }

    public Result<T> WithError(string message)
    {
        return new Result<T>
        {
            Errors = new List<Error>
            {
                new Error {Message = message}
            }
        };
    }
}