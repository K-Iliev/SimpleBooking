using System.Collections.Generic;

namespace Domain.Common
{
    public interface IEntity
    {
        IReadOnlyCollection<IDomainEvent> Events { get; }

        void ClearEvents();
    }
}
