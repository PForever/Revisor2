using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class OrgPersonM : DomainModelBase<OrgPersonM, Guid>
    {
        public OrgPersonM() { }
        public OrgPersonM(Guid id) : base(id) { }
        public string ShortName { get; init; }

        public override string DisplayMember => ShortName;
    }
}