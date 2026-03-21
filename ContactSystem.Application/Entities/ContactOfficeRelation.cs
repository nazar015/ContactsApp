namespace ContactSystem.Application.Entities;

public class ContactOfficeRelation
{
    public Guid ContactId { get; set; }

    public Guid OfficeId { get; set; }

    public Contact Contact { get; set; } = null!;

    public Office Office { get; set; } = null!;
}