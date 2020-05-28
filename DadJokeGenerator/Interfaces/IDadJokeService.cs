using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadJokeGenerator.Models;

namespace DadJokeGenerator.Interfaces
{
    public interface IDadJokeService
    {
        Task<DadJoke> GetRandomDadJoke();
        Task<DadJoke> GetDadJoke(string jokeId);
        Task<List<DadJoke>> SearchDadJokes(DadJokeSearchFilter dadJokeSearchFilter);
    }
}
