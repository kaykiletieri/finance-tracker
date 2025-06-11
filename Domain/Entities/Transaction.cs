using Domain.ValueObjects;

namespace Domain.Entities;

public abstract class Transaction : Entity
{
    public DateTime TransactionDate { get; protected set; }
    public Money Amount { get; protected set; }
    public string? Description { get; protected set; }

    protected Transaction(DateTime transactionDate, Money amount, string? description = null)
    {
        TransactionDate = transactionDate;
        Amount = amount;
        Description = description;
    }
}
