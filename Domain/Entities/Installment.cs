using Domain.ValueObjects;

namespace Domain.Entities;

public sealed class Installment : Entity
{
    public Money Amount { get; private set; }
    public DateTime DueDate { get; private set; }
    public bool IsPaid { get; private set; }
    public Expense Expense { get; private set; }

    public Installment(Money amount, DateTime dueDate, Expense expense)
    {
        Amount = amount;
        DueDate = dueDate;
        Expense = expense;
        IsPaid = false;
    }

    public void MarkAsPaid()
    {
        IsPaid = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateInstallment(Money amount, DateTime dueDate)
    {
        Amount = amount;
        DueDate = dueDate;
        UpdatedAt = DateTime.UtcNow;
    }

    public override string ToString()
    {
        return $"{base.ToString()} - Amount: {Amount}, Due Date: {DueDate}, Is Paid: {IsPaid}";
    }
}
