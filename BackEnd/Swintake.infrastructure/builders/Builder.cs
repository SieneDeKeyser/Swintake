namespace Swintake.infrastructure.builders
{
    public abstract class Builder<T>
    {
        public abstract T Build();
        // refactor naar implementatie met return new<T> (this)
    }
}
