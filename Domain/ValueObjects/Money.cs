namespace Domain.ValueObjects;

public class Money
{
    public decimal Amount { get; private set; }

    public Money(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative");
        Amount = amount;
    }

    public Money Add(Money other)
    {
        return new Money(this.Amount + other.Amount);
    }

    public Money Subtract(Money other)
    {
        if (this.Amount < other.Amount)
            throw new InvalidOperationException("Insufficient funds");
        return new Money(this.Amount - other.Amount);
    }

    public override string ToString()
    {
        return $"${Amount:0.00}";
    }
}
