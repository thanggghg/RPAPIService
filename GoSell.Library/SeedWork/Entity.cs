using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace GoSell.Library.Seedwork;

public abstract class Entity
{
    int? _requestedHashCode;
    long _Id;
    [Column("id")]
    public virtual long Id
    {
        get
        {
            return _Id;
        }
        set
        {
            _Id = value;
        }
    }

    string _createdBy;
    [Column("created_by")]
    [MaxLength(150)]
    public virtual string CreatedBy
    {
        get { return _createdBy; }
        set
        {
            _createdBy = value;
        }
    }

    DateTime? _createdDate;

    [Column("created_date", TypeName = "timestamp without time zone")]
    public virtual DateTime? CreatedDate
    {
        get { return _createdDate; }
        set
        {
            _createdDate = value;
        }
    }

    string _lastModifiedBy;

    [Column("last_modified_by")]
    [MaxLength(150)]
    public virtual string LastModifiedBy
    {
        get { return _lastModifiedBy; }
        set
        {
            _lastModifiedBy = value;
        }
    }

    DateTime? _lastModifiedDate;

    [Column("last_modified_date", TypeName = "timestamp without time zone")]
    public virtual DateTime? LastModifiedDate
    {
        get { return _lastModifiedDate; }
        set
        {
            _lastModifiedDate = value;
        }
    }
    private List<INotification> _domainEvents;
    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents != null ? _domainEvents?.AsReadOnly() : null;

    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents = _domainEvents ?? new List<INotification>();
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    public bool IsTransient()
    {
        return this.Id == default;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Entity))
            return false;

        if (Object.ReferenceEquals(this, obj))
            return true;

        if (this.GetType() != obj.GetType())
            return false;

        Entity item = (Entity)obj;

        if (item.IsTransient() || this.IsTransient())
            return false;
        else
            return item?.Id == this?.Id;
    }

    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

            return _requestedHashCode.Value;
        }
        else
            return base.GetHashCode();

    }
    public static bool operator ==(Entity left, Entity right)
    {
        if (Object.Equals(left, null))
            return (Object.Equals(right, null)) ? true : false;
        else
            return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }

    public void UpdateLastModified(string name)
    {
        LastModifiedDate = DateTime.UtcNow;
        LastModifiedBy = name;
    }
    public void UpdateCreatedBy(string name)
    {
        CreatedBy = name;
        CreatedDate = DateTime.UtcNow;
    }
}
