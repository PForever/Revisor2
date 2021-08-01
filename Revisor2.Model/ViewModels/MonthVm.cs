using System;

namespace Revisor2.Model.ViewModels
{
    public class MonthVm : ViewModelBase<MonthVm, Guid>
    {
        public MonthVm(Guid id) : base(id) {}
        public string Name {  get; init; }
        public DateOnly DateStart { get; init; }
        public DateOnly DateFinish { get; init; }
        public override string DisplayMember => $"{Name}";
    }
}