using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DadJokeGenerator.Models
{
    public class DadJokeSearchFilter
    {
        public string Term { get; set; }
        public int? Limit { get; set; }

        public string ToQueryString()
        {
            var filters = new List<string>
            {
                !string.IsNullOrWhiteSpace(Term) ? $"term={Term}" : null,
                !(Limit == null || Limit == 0) ? $"limit={Limit}" : null
            }.Where(f => f != null);

            var returnString = $"?{string.Join('&', filters)}";
            return returnString;
        }
    }
}
