using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class SubscribeResultM : DomainModelBase<SubscribeResultM, Guid>
    {
        public SubscribeResultM() { }
        public SubscribeResultM(Guid id) : base(id) { }
        public DateOnly Date { get; set; }
        public ContributionM Contribution { get; set; }
        public SubscribeM Subscribe { get; init; }
        public int Value { get; set; }
        public override string DisplayMember => $"{Value} - {Date}";
    }
}
