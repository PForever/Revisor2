using System;

namespace Revisor2.Model.ViewModels
{
    public class CallResultVm : ViewModelBase<CallResultVm, int>
    {
        public CallResultVm(int id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}