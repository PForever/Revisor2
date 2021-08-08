using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class MonthM : DomainModelBase<MonthM, Guid>
    {
        public MonthM() {}
        public MonthM(Guid id, string name, DateTime dateStart, DateTime dateFinish) : base(id)
        {
            Name = name;
            DateStart = dateStart;
            DateFinish = dateFinish;
        }
        public string Name { get; set; }
        private DateTime _DateStart;
        public DateTime DateStart { get => _DateStart; set => Set(ref _DateStart, value); }
        private DateTime _DateFinish;
        public DateTime DateFinish { get => _DateFinish; set => Set(ref _DateFinish, value); }
        public override string DisplayMember => $"{Name}";
    }
}