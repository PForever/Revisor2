using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class OrgStateM : DomainModelBase<OrgStateM, Guid>
    {
        public OrgStateM() { }
        public OrgStateM(Guid id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}