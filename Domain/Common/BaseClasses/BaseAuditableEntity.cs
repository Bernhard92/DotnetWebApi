namespace SUKiiServer.Domain.Common.BaseClasses;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTimeOffset CreatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset ModifiedAt { get; set; }

    public Guid ModifiedBy { get; set; }
}
