using MyApp.Domain.Entities;
using MyApp.Infrastructure.Persistence;
using System.Linq;

namespace MyApp.Infrastructure.Seed
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Apartments.Any())
            {
                context.Apartments.AddRange(
                    new Apartment { Name = "آپارتمان یک", Address = "تهران، خیابان انقلاب", PricePerNight = 100 , Subject = "" , Title = ""},
                    new Apartment { Name = "آپارتمان دو", Address = "اصفهان، میدان نقش جهان", PricePerNight = 80, Subject = "", Title = "" },
                    new Apartment { Name = "آپارتمان سه", Address = "شیراز، حافظیه", PricePerNight = 90 , Subject = "", Title = "" }
                );

                context.SaveChanges();
            }
        }
    }           
}
