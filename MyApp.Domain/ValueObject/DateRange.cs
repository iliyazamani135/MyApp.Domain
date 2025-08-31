namespace MyApp.Domain.ValueObjects
{
    public class DateRange
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public DateRange(DateTime start, DateTime end)
        {
            if (end <= start)
                throw new ArgumentException("End date must be after start date.");
            Start = start;
            End = end;
        }
    }
}
