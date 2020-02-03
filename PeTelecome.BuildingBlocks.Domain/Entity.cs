using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.BuildingBlocks.Domain
{
    public class Entity
    {
        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        protected void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void CheckRule(IBusinessRule businessRule)
        {
            if (businessRule.IsBroken())
                throw new BusinessRuleValidationException(businessRule);
        }
    }
}
