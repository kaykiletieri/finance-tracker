namespace Domain.Entities;

public sealed class CreditCard : Entity
{
    public string LastFourDigits { get; private set; }
    public string CardHolderName { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public string? Description { get; private set; }
    public bool IsActive { get; private set; }
    public decimal? Limit { get; private set; }

    public CreditCard
    (
        string lastFourDigits,
        string cardHolderName,
        DateTime expirationDate,
        bool isActive,
        decimal? limit = null,
        string? description = null
    )
    {
        LastFourDigits = lastFourDigits;
        CardHolderName = cardHolderName;
        ExpirationDate = expirationDate;
        IsActive = isActive;
        Limit = limit;
        Description = description;
    }
}
