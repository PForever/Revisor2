using System;

namespace Revisor2.Model.Models
{
    public class MonthM : DomainModelBase<MonthM, Guid>
    {
        public MonthM(Guid id) : base(id) {}
        public string Name {  get; init; }
        public DateOnly DateStart { get; init; }
        public DateOnly DateFinish { get; init; }
        public override string DisplayMember => $"{Name}";
    }
}