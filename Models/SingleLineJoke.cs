using LMA25_V2.Interfaces;

namespace LMA25_V2.Models
{
    public class SingleLineJoke : IPrintable
    {
        private readonly Joke _joke;
        public string Text { get; set; } = "";

        public SingleLineJoke(Joke joke)
        {
            _joke = joke;
        }

        public string Print()
        {
            return $"{_joke.Type.ToString()}: {Text}";
        }
    }
}
