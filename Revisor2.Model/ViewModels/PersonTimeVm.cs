using System;

namespace Revisor2.Model.ViewModels
{
    public class PersonTimeVm : ViewModelBase<PersonTimeVm, Guid>
    {
        public PersonTimeVm(Guid id) : base(id) { }
        public PersonTimeVm Person { get; }
        public TimeOnly Start { get; }
        public TimeOnly Finish { get; }
        public override string DisplayMember => $"{Person} - ({Start} - {Finish})";
    }
}