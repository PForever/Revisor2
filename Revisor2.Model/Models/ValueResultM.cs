using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class ValueResultM : DomainModelBase<ValueResultM, Guid>
    {
        public DateOnly Date { get; set; }
        public ValueResultM(Guid id) : base(id) { }
        public ContributionM Contribution { get; init; }
        public int Value { get; set; }
        public override string DisplayMember => $"{Value} - {Date}";
    }
}
