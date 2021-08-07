using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class SubscribeM : DomainModelBase<SubscribeM, Guid>
    {
        public SubscribeM() { }
        public SubscribeM(Guid id) : base(id) { }
        public ContributionM Contribution { get; set; }
        public string Name { get; set; }
        public override string DisplayMember => Name;
    }
}
