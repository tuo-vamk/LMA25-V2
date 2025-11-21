using LMA25_V2.Interfaces;

namespace LMA25_V2.Models
{
    internal class SingleLineJoke : IPrintable
    {
        private readonly Joke _joke;
        public string Text { get; set; } = "";

        public SingleLineJoke(Joke joke)
        {
            _joke = joke;
        }

        public override string ToString()
        {
            return $"{Text}";
        }

    }
}
