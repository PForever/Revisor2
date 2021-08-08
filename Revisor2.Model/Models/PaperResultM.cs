using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class PaperResultM : DomainModelBase<ValueResultM, Guid>
    {
        public PaperResultM() { }
        public PaperResultM(Guid id, DateTime date, PaperM paper) : base(id)
        {
            _Date = date;
            _Paper = paper;
        }
        private DateTime _Date;
        public DateTime Date { get => _Date; set => Set(ref _Date, value); }
        private ContributionM _Contribution;
        public ContributionM Contribution { get => _Contribution; set => SetVm(ref _Contribution, value); }
        private PaperM _Paper;
        public PaperM Paper { get => _Paper; set => SetVm(ref _Paper, value); }
        public override string DisplayMember => $"{Paper.Number} - {Date}";
    }
}
