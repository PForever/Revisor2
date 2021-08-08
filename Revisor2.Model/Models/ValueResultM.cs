using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class ValueResultM : DomainModelBase<ValueResultM, Guid>
    {
        public ValueResultM() { }
        public ValueResultM(Guid id, DateTime date, int value) : base(id)
        {
            _Date = date;
            _Value = value;
        }
        private DateTime _Date;
        public DateTime Date { get => _Date; set => Set(ref _Date, value); }
        public ContributionM Contribution { get; set; }
        private int _Value;
        public int Value { get => _Value; set => Set(ref _Value, value); }
        public override string DisplayMember => $"{Value} - {Date}";
    }
}
