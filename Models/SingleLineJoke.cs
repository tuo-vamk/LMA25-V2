using Interrfaces;
using LMA25_V2.Interfaces;

namespace LMA25_V2.Models
{
    public class SingleLineJoke : IPrintable
    {
        private readonly IJoke _joke;
        public string Text { get; set; } = "";

        public SingleLineJoke(IJoke joke)
        {
            _joke = joke;
        }

        public string Print()
        {
            return $"{_joke.GetType()}: {Text}";
        }
    }
}
