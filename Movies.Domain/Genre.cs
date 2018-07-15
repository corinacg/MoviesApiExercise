using System;

namespace Movies.Domain
{
    [Flags]
    public enum Genre
    {
        Action = 1,
        Comedy = 2,
        Family = 4,
        History = 8,
        Mistery = 16,
        SciFi = 32,
        War = 64,
        Adventure = 128,
        Crime = 256,
        Fantasy = 512,
        Horror = 1024,
        News = 2048,
        Thriller = 4096,
        Drama = 8192,
        Biography = 16384,
        Documentary = 32768,
        Music = 65536
    }
}
