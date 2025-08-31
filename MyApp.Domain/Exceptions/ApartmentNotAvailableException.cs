namespace MyApp.Domain.Exceptions
{
    public class ApartmentNotAvailableException : Exception
    {   
        public ApartmentNotAvailableException(string message) : base(message) { }
    }
}
