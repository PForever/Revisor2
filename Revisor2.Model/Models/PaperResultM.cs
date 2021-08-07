using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class PaperResultM : DomainModelBase<ValueResultM, Guid>
    {
        public PaperResultM() { }
        public PaperResultM(Guid id) : base(id) { }
        public DateOnly Date { get; set; }
        public ContributionM Contribution { get; set; }
        public PaperM Paper { get; set; }
        public override string DisplayMember => $"{Paper.Number} - {Date}";
    }
}
