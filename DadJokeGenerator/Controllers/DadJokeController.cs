using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using DadJokeGenerator.Interfaces;
using DadJokeGenerator.Models;
using DadJokeGenerator.Services;
using Microsoft.AspNetCore.Mvc;

namespace DadJokeGenerator.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class DadJokeController : ControllerBase
    {
        private readonly IDadJokeService _dadJokeService;

        public DadJokeController(IDadJokeService dadJokeService)
        {
            _dadJokeService = dadJokeService;
        }

        /// <summary>
        /// Gets a random dad joke.
        /// </summary>
        /// <returns>A random dad joke.</returns>
        [HttpGet]
        [Route("getRandomJoke")]
        public async Task<IActionResult> Get()
        {
            var dadJoke = await _dadJokeService.GetRandomDadJoke();
            if (dadJoke == null)
                return BadRequest();

            return Ok(dadJoke);
        }

        /// <summary>
        /// Gets a dad joke from it's ID.
        /// </summary>
        /// <param name="JokeID">The ID of the joke to return.</param>
        /// <returns>A dad joke that matches the entered ID.</returns>
        [HttpGet]
        [Route("getJokeFromId")]
        public async Task<IActionResult> GetDadJoke([Required, FromQuery] string JokeID)
        {
            if (string.IsNullOrEmpty(JokeID))
                return BadRequest("Joke ID cannot be null or empty.");

            var dadJoke = await _dadJokeService.GetDadJoke(JokeID);
            if (dadJoke == null)
                return NotFound(new {Id = JokeID});

            if (dadJoke.Status < 200 || dadJoke.Status >= 300)
                return BadRequest();

            return Ok(dadJoke);
        }

        /// <summary>
        /// Search for jokes with the specified term.
        /// </summary>
        /// <param name="dadJokeSearchRequest.Term">The term to search jokes for.</param>
        /// <param name="dadJokeSearchRequest.Limit">How many jokes you want to return (default 10).</param>
        /// <returns>A list of dad jokes that had the search term within them.</returns>
        [HttpGet]
        [Route("searchJoke")]
        public async Task<IActionResult> SearchDadJokes([FromQuery] DadJokeSearchRequestViewModel dadJokeSearchRequest)
        {
            var dadJokes = await _dadJokeService.SearchDadJokes(dadJokeSearchRequest.ToModel());
            if (dadJokes == null)
                return BadRequest();

            return Ok(dadJokes);
        }
    }
}
