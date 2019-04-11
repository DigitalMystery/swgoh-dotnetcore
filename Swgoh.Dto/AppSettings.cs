namespace Swgoh.Dto
{
    public class AppSettings
    {
        public Login Login { get; set; }
    }

    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string GrantType { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
