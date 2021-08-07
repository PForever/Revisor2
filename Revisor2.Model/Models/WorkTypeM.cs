using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class WorkTypeM : DomainModelBase<WorkTypeM, Guid>
    {
        public WorkTypeM() { }
        public WorkTypeM(Guid id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}