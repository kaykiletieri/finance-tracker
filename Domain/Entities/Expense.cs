using Domain.ValueObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Entities;

public class Expense : Transaction
{
    public bool IsPaid { get; private set; }
    public ICollection<Installment> Installments { get; private set; }

    public Expense(DateTime transactionDate, Money amount, bool isPaid, ICollection<Installment> installments, string? description = null)
        : base(transactionDate, amount, description)
    {
        IsPaid = isPaid;
        Installments = installments ?? [];
    }

    public void MarkAsPaid()
    {
        IsPaid = true;
        foreach (Installment installment in Installments)
        {
            installment.MarkAsPaid();
        }
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddInstallment(Money amount, DateTime dueDate)
    {
        Installment installment = new(amount, dueDate, this);
        Installments.Add(installment);
    }

    public void UpdateExpense(Money amount, string description, DateTime date)
    {
        Amount = amount;
        Description = description;
        TransactionDate = date;
        UpdatedAt = DateTime.UtcNow;
    }
}
