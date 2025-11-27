
public class JokeApiResult<T>
{
    public bool IsSuccess { get; private set; }
    public T? Data { get; private set; }
    public string? ErrorMessage { get; private set; }

    private JokeApiResult(bool isSuccess, T? data, string? errorMessage)
    {
        IsSuccess = isSuccess;
        Data = data;
        ErrorMessage = errorMessage;
    }

    public static JokeApiResult<T> Success(T data)
    {
        return new JokeApiResult<T>(true, data, null);
    }

    public static JokeApiResult<T> Failure(string errorMessage)
    {
        return new JokeApiResult<T>(false, default, errorMessage);
    }
}
