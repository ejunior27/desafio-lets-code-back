namespace LetsAuth.Models.Models
{
    public class AuthenticateResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(string user, string token)
        {            
            Username = user;
            Token = token;
        }
    }
}
