using LMA25_V2.Interfaces;

namespace LMA25_V2.Models
{
    public class Joke : IPrintable
    {
        public enum JokeType
        {
            Error = -1,
            Unknown = 0,
            Programming,
            DadJoke,
            KnockKnock
        }

        public int Id { get; set; }
        public JokeType Type { get; set; } = JokeType.Unknown;
        public string ErrorMsg { get; set; }

        public string ToString()
        {
            return ErrorMsg;
        }
    }
}