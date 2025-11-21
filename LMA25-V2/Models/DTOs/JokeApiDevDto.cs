namespace LMA25_V2.Models.DTOs
{
    public class JokeApiDevDto
    {
        public bool error { get; set; }
        public int amount { get; set; }
        public ApiDevJoke[] jokes { get; set; }
    }

    public class ApiDevJoke
    {
        public string category { get; set; }
        public string type { get; set; }
        public string joke { get; set; }
        public ApiDevFlags flags { get; set; }
        public int id { get; set; }
        public bool safe { get; set; }
        public string lang { get; set; }
        public string setup { get; set; }
        public string delivery { get; set; }
    }

    public class ApiDevFlags
    {
        public bool nsfw { get; set; }
        public bool religious { get; set; }
        public bool political { get; set; }
        public bool racist { get; set; }
        public bool sexist { get; set; }
        public bool _explicit { get; set; }
    }

}
