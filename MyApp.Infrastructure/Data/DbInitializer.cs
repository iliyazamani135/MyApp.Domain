using MyApp.Domain.Entities;

if (!context.Users.Any())
{
    context.Users.Add(new User
    {
        Username = "admin",
        Password = "1234" // توجه: تو نسخه‌های جدی‌تر باید رمز رو هش کنیم
    });

    context.SaveChanges();
}
// کاربر تستی 