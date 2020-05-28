namespace DadJokeGenerator.Models
{
    public class DadJoke
    {
        public string Id { get; set; }
        public string Joke { get; set; }
        public int Status { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Id) ||
                string.IsNullOrEmpty(Joke) ||
                Status < 200 || Status >= 300)
            {
                return false;
            }

            return true;
        }
    }
}
