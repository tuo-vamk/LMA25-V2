using LMA25_V2.Interfaces;
using LMA25_V2.Models;
using LMA25_V2.Models.DTOs;
using System.Text.Json;

namespace LMA25_V2.Services
{
    public class JokeServiceJokeDevApi : IJokeService
    {
        private HttpClient httpClient;
        private readonly string url;

        public JokeServiceJokeDevApi(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            url = "https://v2.jokeapi.dev/joke/Programming?blacklistFlags=nsfw,religious,political,racist,sexist,explicit&amount=";
        }

        public async Task<JokeApiResult<IPrintable>> GetJokeAsync()
        {
            try
            {
                var req = url + 1;
                var response = await httpClient.GetAsync(req);

                if (!response.IsSuccessStatusCode)
                {
                    // Generate failure result with status code info
                    return JokeApiResult<IPrintable>.Failure($"Error: {response.StatusCode}");
                }

                var json = await response.Content.ReadAsStringAsync();

                var apiDevJoke = JsonSerializer.Deserialize<ApiDevJoke>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (apiDevJoke == null)
                {
                    return JokeApiResult<IPrintable>.Failure("Failed to parse jokes from response.");
                }

                var iPrintableJoke = mapDtoToJoke(apiDevJoke);

                // Generate success result
                return JokeApiResult<IPrintable>.Success(iPrintableJoke);
            }
            catch (Exception ex)
            {
                // Generate failure result with exception message
                return JokeApiResult<IPrintable>.Failure($"Exception: {ex.Message}");
            }
        }

        public Task<JokeApiResult<List<IPrintable>>> GetJokesAsync()
        {
            throw new NotImplementedException();
        }

        private List<IPrintable> mapToJokes(JokeApiDevDto dto)
        {
            var jokes = new List<IPrintable>();
            foreach (var apiJoke in dto.jokes)
            {
                jokes.Add(mapDtoToJoke(apiJoke));
                
            }
            return jokes;
        }

        private IPrintable mapDtoToJoke(ApiDevJoke apiJoke)
        {
            var joke = new Joke(apiJoke.id, mapJokeType(apiJoke.category));

            return apiJoke.type switch
            {
                "single" => new SingleLineJoke(joke) { Text = apiJoke.joke },
                "twopart" => new TwoPartJoke(joke) { Setup = apiJoke.setup, Delivery = apiJoke.delivery },
                _ => throw new InvalidOperationException($"Unknown joke type: {apiJoke.type}")
            };
        }

        private Joke.JokeType mapJokeType(string type)
        {
            return type.ToLower() switch
            {
                "programming" => Joke.JokeType.Programming,
                "dadjoke" => Joke.JokeType.DadJoke,
                "knockknock" => Joke.JokeType.KnockKnock,
                _ => Joke.JokeType.Unknown,
            };
        }
    }
}
