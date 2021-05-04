namespace PoliceDepartment.Auth.Authentication
{
    public class AuthenticationOptions
    {
        public string Secret { get; set; }
        public int TotalMinutesOfValidToken { get; set; }
    }
}
