using LMA25_V2.Models;

namespace LMA25_V2.Interfaces
{
    public interface IJokeService
    {
        Task<IPrintable> GetJokeAsync();
        Task<List<IPrintable>> GetJokesAsync(int jokeCount);
    }
}