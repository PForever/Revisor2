using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class SubscribeResultM : DomainModelBase<SubscribeResultM, Guid>
    {
        public DateOnly Date { get; set; }
        public SubscribeResultM(Guid id) : base(id) { }
        public ContributionM Contribution { get; init; }
        public SubscribeM Subscribe { get; init; }
        public int Value { get; set; }
        public override string DisplayMember => $"{Value} - {Date}";
    }
}
