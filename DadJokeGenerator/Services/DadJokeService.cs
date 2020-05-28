using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DadJokeGenerator.Interfaces;
using DadJokeGenerator.Models;
using Newtonsoft.Json;

namespace DadJokeGenerator.Services
{
    public class DadJokeService : IDadJokeService
    {
        private readonly HttpClient _client;
        public DadJokeService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://icanhazdadjoke.com/"),
                Timeout = TimeSpan.FromSeconds(5)
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<DadJoke> GetRandomDadJoke()
        {
            var response = await _client.GetAsync("");
            if (!response.IsSuccessStatusCode)
                return null;

            var dadJoke = JsonConvert.DeserializeObject<DadJoke>(await response.Content.ReadAsStringAsync());

            return dadJoke.IsValid() ? dadJoke : null;
        }

        public async Task<DadJoke> GetDadJoke(string jokeId)
        {
            var response = await _client.GetAsync($"j/{jokeId}");
            if (!response.IsSuccessStatusCode)
                return null;

            var dadJoke = JsonConvert.DeserializeObject<DadJoke>(await response.Content.ReadAsStringAsync());

            return dadJoke.IsValid() ? dadJoke : null;
        }

        public async Task<List<DadJoke>> SearchDadJokes(DadJokeSearchFilter dadJokeSearchFilter)
        {
            var response = await _client.GetAsync($"search{dadJokeSearchFilter.ToQueryString()}");
            if (!response.IsSuccessStatusCode)
                return null;

            var dadJokes = JsonConvert.DeserializeObject<DadJokeSearchResults>(await response.Content.ReadAsStringAsync());

            return dadJokes.Jokes.Where(j => j.IsValid()).ToList();
        }
    }
}
