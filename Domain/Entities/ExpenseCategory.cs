namespace Domain.Entities;

public sealed class ExpenseCategory : Entity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public ExpenseCategory(string name, string? description = null)
    {
        Name = name;
        Description = description;
    }
    
    public void UpdateCategory(string name, string? description = null)
    {
        Name = name;
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public override string ToString()
    {
        return $"{base.ToString()} - Name: {Name}, Description: {Description}";
    }
}
