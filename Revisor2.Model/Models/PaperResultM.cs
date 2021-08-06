using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class PaperResultM : DomainModelBase<ValueResultM, Guid>
    {
        public DateOnly Date { get; set; }
        public PaperResultM(Guid id) : base(id) { }
        public ContributionM Contribution { get; init; }
        public PaperM Paper { get; set; }
        public override string DisplayMember => $"{Paper.Number} - {Date}";
    }
}
