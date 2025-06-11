using Domain.ValueObjects;

namespace Domain.Entities;

public class Expense : Transaction
{
    public bool IsPaid { get; private set; }
    public ICollection<Installment> Installments { get; private set; }
    public ICollection<ExpenseCategory> Categories { get; private set; } = [];

    public Expense(DateTime transactionDate, Money amount, bool isPaid, ICollection<Installment> installments, ICollection<ExpenseCategory> categories, string? description = null)
        : base(transactionDate, amount, description)
    {
        IsPaid = isPaid;
        Categories = categories ?? [];
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

    public void RemoveInstallment(Installment installment)
    {
        if (!Installments.Contains(installment))
        {
            throw new InvalidOperationException("Installment does not exist in the expense.");
        }
        Installments.Remove(installment);
    }

    public void AddCategory(ExpenseCategory category)
    {
        if (Categories.Contains(category))
        {
            throw new InvalidOperationException("Category already exists in the expense.");
        }
        Categories.Add(category);
    }

    public void RemoveCategory(ExpenseCategory category)
    {
        if (!Categories.Contains(category))
        {
            throw new InvalidOperationException("Category does not exist in the expense.");
        }
        Categories.Remove(category);
    }

    public void UpdateExpense(Money amount, bool isPaid, string? description = null)
    {
        Amount = amount;
        IsPaid = isPaid;
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }
}
