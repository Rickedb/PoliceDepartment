namespace PoliceDepartment.Domain.ValuedObjects
{
    public class AuthenticatedUser
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public int ExpiresIn { get; set; }

        public AuthenticatedUser()
        {

        }
    }
}
