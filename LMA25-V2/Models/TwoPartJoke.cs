using LMA25_V2.Interfaces;

namespace LMA25_V2.Models
{
    internal class TwoPartJoke : IPrintable
    {
        private readonly Joke _joke;
        public string Setup { get; set; } = "";
        public string Delivery { get; set; } = "";

        public TwoPartJoke(Joke joke)
        {
            _joke = joke;
        }
        public override string ToString()
        {
            return $"{Setup} --- {Delivery}";
        }
    }
}
