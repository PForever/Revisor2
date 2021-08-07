using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class SosialStatusM : DomainModelBase<SosialStatusM, Guid>
    {
        public SosialStatusM() { }
        public SosialStatusM(Guid id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}