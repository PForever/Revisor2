using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class SubscribeResultM : DomainModelBase<SubscribeResultM, Guid>
    {
        public SubscribeResultM() { }
        public SubscribeResultM(Guid id, DateTime date, SubscribeM subscribe, int value) : base(id)
        {
            _Date = date;
            _Subscribe = subscribe;
            _Value = value;
        }
        private DateTime _Date;
        public DateTime Date { get => _Date; set => Set(ref _Date, value); }
        public ContributionM Contribution { get; set; }
        private SubscribeM _Subscribe;
        public SubscribeM Subscribe { get => _Subscribe; set => SetVm(ref _Subscribe, value); }
        private int _Value;
        public int Value { get => _Value; set => Set(ref _Value, value); }
        public override string DisplayMember => $"{Value} - {Date}";
    }
}
