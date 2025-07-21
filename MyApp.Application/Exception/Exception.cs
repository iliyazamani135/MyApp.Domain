namespace MyApp.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
//وقتی بخوای توی برنامه بگی:

//"آیتمی که دنبالشی وجود نداره"
//ل وقتی که یه کاربر یا آپارتمان یا رزرو خاصی رو تو دیتابیس پیدا نمی‌کنیم.