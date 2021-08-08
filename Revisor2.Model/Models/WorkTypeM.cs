using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class WorkTypeM : DomainModelBase<WorkTypeM, Guid>
    {
        public WorkTypeM() { }
        public WorkTypeM(Guid id, string name) : base(id)
        {
            _Name = name;
        }
        private string _Name;
        public string Name { get => _Name; set => Set(ref _Name, value); }

        public override string DisplayMember => Name;
    }
}