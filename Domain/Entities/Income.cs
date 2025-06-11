using Domain.ValueObjects;

namespace Domain.Entities;

public class Income : Transaction
{
    public string? Source { get; private set; }

    public Income(DateTime transactionDate, Money amount, string source, string? description = null)
        : base(transactionDate, amount, description)
    {
        Source = source;
    }

    public void UpdateIncome(Money amount, string source, string? description = null)
    {
        Amount = amount;
        Source = source;
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }

    public override string ToString()
    {
        return $"{base.ToString()} - Source: {Source}";
    }
}
