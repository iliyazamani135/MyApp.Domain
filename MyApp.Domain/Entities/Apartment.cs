using MyApp.Domain.ValueObjects;

namespace MyApp.Domain.Entities
{
    public class Apartment
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public int Capacity { get; private set; }

        public Apartment(string name, Address address, int capacity)
        {
            Name = name;
            Address = address;
            Capacity = capacity;
        }

        public void UpdateDetails(string name, Address address, int capacity)
        {
            Name = name;
            Address = address;
            Capacity = capacity;
        }
    }
}

// هر اپارتمان میتونه چندتا زرزو داشته باشه ای کالکشن رزرو برای رابطه یک به چند استفاده میشه    إ
// این کد هایی که زدم انتیتی هستش ،انتیتی ها شی هویت دار مثل ادرس و قیمت انیتیتی هستن در واقع کلاس هایی هستن که اطلاعات اصلی سیستم رو نگه میدارن 