using System;

namespace Revisor2.Model.Models
{
    public class OrgStateM : DomainModelBase<OrgStateM, int>
    {
        public OrgStateM(int id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}