using LMA25_V2.Interfaces;
using LMA25_V2.Models;
using LMA25_V2.Models.DTOs;
using System.Net;
using System.Text.Json;

namespace LMA25_V2.Services
{
    internal class JokeServiceJokeDevApi : IJokeService
    {
        private HttpClient httpClient;
        private readonly string url;

        public JokeServiceJokeDevApi(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            url = "https://v2.jokeapi.dev/joke/Programming?blacklistFlags=nsfw,religious,political,racist,sexist,explicit&amount=";
        }

        public async Task<IPrintable> GetJokeAsync()
        {
            var joke = await GetOneJokeAsync();
            return joke;
        }

        public async Task<List<IPrintable>> GetJokesAsync(int jokeCount)
        {
            return await GetJokeWithCountAsync(jokeCount);
        }

        private async Task<IPrintable> GetOneJokeAsync()
        {
            var req = url + 1;
            HttpResponseMessage response = await httpClient.GetAsync(req);

            if (response.IsSuccessStatusCode == false)
            {
                return errorJoke(response.StatusCode);
            }

            string json = await response.Content.ReadAsStringAsync();

            var ApiDevJoke = JsonSerializer.Deserialize<ApiDevJoke>(json);

            return mapDtoToJoke(ApiDevJoke);
        }

        private async Task<List<IPrintable>> GetJokeWithCountAsync(int jokeCount)
        {
            var req = url + jokeCount;
            HttpResponseMessage response = await httpClient.GetAsync(req);

            if (response.IsSuccessStatusCode == false)
            {
                return new List<IPrintable> { errorJoke(response.StatusCode) };
            }

            string json = await response.Content.ReadAsStringAsync();

            var jokeApiDevDto = JsonSerializer.Deserialize<JokeApiDevDto>(json);

            return mapToJokes(jokeApiDevDto);
        }

        private IPrintable errorJoke(HttpStatusCode responseStatusCode)
        {
            return new Joke
            {
                Type = Joke.JokeType.Error,
                ErrorMsg = "No joke available (HTTP " + responseStatusCode + ")"
            };
        }

        private List<IPrintable> mapToJokes(JokeApiDevDto? dto)
        {
            if (dto == null) {
                return new List<IPrintable>
                {
                    new Joke
                    {
                        Type = Joke.JokeType.Error,
                        ErrorMsg = "Joke data is null"
                    }
                };
            }

            var jokes = new List<IPrintable>();
            foreach (var apiJoke in dto.jokes)
            {
                jokes.Add(mapDtoToJoke(apiJoke));
                
            }
            return jokes;
        }

        private IPrintable mapDtoToJoke(ApiDevJoke? apiJoke)
        {
            if(apiJoke == null)
                {
                return new Joke
                {
                    Type = Joke.JokeType.Error,
                    ErrorMsg = "Joke data is null"
                };
            }

            var joke = new Joke()
            {
                Id = apiJoke.id,
                Type = mapJokeType(apiJoke.type)
            };

            if (apiJoke.type == "single")
            {
                return new SingleLineJoke(joke)
                    {
                        Text = apiJoke.joke
                    };
            }
            else if (apiJoke.type == "twopart")
            {
                return new TwoPartJoke(joke)
                    {
                        Setup = apiJoke.setup,
                        Delivery = apiJoke.delivery
                    };
            }

            return new Joke
            {
                Type = Joke.JokeType.Error,
                ErrorMsg = "Joke type not recognized"
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
