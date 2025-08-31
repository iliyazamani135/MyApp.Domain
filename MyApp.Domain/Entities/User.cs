namespace MyApp.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }

        public User(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public void UpdateProfile(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
    }
}
