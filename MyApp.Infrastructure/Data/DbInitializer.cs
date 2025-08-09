using Myapp.Domain.Entities;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Persistence;
using System.Linq;

public class UserSeeder
{
    private readonly AppDbContext _context;

    public UserSeeder(AppDbContext context)
    {
        _context = context;
    }

    public void SeedAdminUser()
    {
        if (!_context.Users.Any())
        {
            _context.Users.Add(new User
            {
                Username = "admin",
                Password = "1234"  // توجه: حتماً تو پروژه واقعی باید هش کنی
            });
            _context.SaveChanges();
        }
    }
}
