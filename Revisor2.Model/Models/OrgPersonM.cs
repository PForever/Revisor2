using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class OrgPersonM : DomainModelBase<OrgPersonM, Guid>
    {
        public OrgPersonM() { }
        public OrgPersonM(Guid id, string shortName) : base(id)
        {
            _ShortName = shortName;
        }
        private string _ShortName;
        public string ShortName { get => _ShortName; set => Set(ref _ShortName, value); }

        public override string DisplayMember => ShortName;
    }
}