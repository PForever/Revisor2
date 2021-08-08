using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class OrgStateM : DomainModelBase<OrgStateM, Guid>
    {
        public OrgStateM() { }
        public OrgStateM(Guid id, string name) : base(id)
        {
            _Name = name;
        }
        private string _Name;
        public string Name { get => _Name; set => Set(ref _Name, value); }

        public override string DisplayMember => Name;
    }
}