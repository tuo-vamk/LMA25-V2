using Interrfaces;
using LMA25_V2.Interfaces;

namespace LMA25_V2.Models
{
    public class TwoPartJoke : IPrintable
    {
        private readonly IJoke _joke;
        public string Setup { get; set; } = "";
        public string Delivery { get; set; } = "";

        public TwoPartJoke(IJoke joke)
        {
            _joke = joke;
        }

        public string Print()
        {
            return $"{_joke.GetType()}: {Setup} --- {Delivery}";
        }
    }
}
