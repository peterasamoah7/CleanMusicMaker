namespace CleanMusicMaker.Models
{
    public class TokenRequest
    {
        public string Username { get; }

        public string Password { get; }

        public TokenRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
