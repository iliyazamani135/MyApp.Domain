namespace MyApp.Domain.Abstraction
{


    public abstract class ValueObject
    {
        protected abstract IEnumerable<object?> GetEqualityComponents();


        public override bool Equals(object? obj)
        => obj is ValueObject other && GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());


        public override int GetHashCode()
        => GetEqualityComponents()
        .Aggregate(0, (hash, component) => HashCode.Combine(hash, component));
    }
}