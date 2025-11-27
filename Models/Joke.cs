using LMA25_V2.Interfaces;

namespace LMA25_V2.Models
{
    public class Joke
    {
        public enum JokeType
        {
            Unknown,
            Programming,
            DadJoke,
            KnockKnock
        }
        public int Id { get; private set; }
        public JokeType Type { get; private set; } = JokeType.Unknown;

        public Joke(int id, JokeType type) 
        {
            Id = id;
            Type = type;
        }

    }
}