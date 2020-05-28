using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DadJokeGenerator.Models
{
    public class DadJokeSearchResults
    {

        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("next_page")]
        public int NextPage { get; set; }

        [JsonProperty("previous_page")]
        public int PreviousPage { get; set; }

        [JsonProperty("results")]
        private IEnumerable<Joke> Results { get; set; }

        public IEnumerable<DadJoke> Jokes
        {
            get
            {
                return Results.Select(r => new DadJoke
                {
                    Id = r.Id,
                    Joke = r.JokeText,
                    Status = 200
                });
            }
        }

        [JsonProperty("search_term")]
        public string SearchTerm { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("total_jokes")]
        public int TotalJokes { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }

    public class Joke
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("joke")]
        public string JokeText { get; set; }
    }
}
