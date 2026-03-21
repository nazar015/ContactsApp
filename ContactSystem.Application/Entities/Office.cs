namespace ContactSystem.Application.Entities;

public class Office : Entity<Guid>
{
    public string Name { get; set; } = null!;

    public ICollection<ContactOfficeRelation>? ContactOffices { get; set; }
}