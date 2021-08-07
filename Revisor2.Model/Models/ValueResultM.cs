using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class ValueResultM : DomainModelBase<ValueResultM, Guid>
    {
        public ValueResultM() { }
        public ValueResultM(Guid id) : base(id) { }
        public DateOnly Date { get; set; }
        public ContributionM Contribution { get; set; }
        public int Value { get; set; }
        public override string DisplayMember => $"{Value} - {Date}";
    }
}
