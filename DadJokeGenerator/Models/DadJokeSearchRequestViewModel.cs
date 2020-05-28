namespace DadJokeGenerator.Models
{
    public class DadJokeSearchRequestViewModel
    {
        public string Term { get; set; }
        public int Limit { get; set; } = 10;

        public DadJokeSearchFilter ToModel()
        {
            return new DadJokeSearchFilter
            {
                Term = Term,
                Limit = Limit
            };
        }
    }
}
