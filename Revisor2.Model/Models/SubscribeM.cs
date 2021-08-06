using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class SubscribeM : DomainModelBase<SubscribeM, Guid>
    {
        public SubscribeM(Guid id) : base(id) { }
        public string Name { get; set; }
        public override string DisplayMember => Name;
    }
}
