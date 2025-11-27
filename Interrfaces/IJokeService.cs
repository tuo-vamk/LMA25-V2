namespace LMA25_V2.Interfaces
{
    public interface IJokeService
    {
        Task<JokeApiResult<IPrintable>> GetJokeAsync();
        Task<JokeApiResult<List<IPrintable>>> GetJokesAsync();
    }
}