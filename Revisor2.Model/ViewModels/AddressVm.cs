using System;

namespace Revisor2.Model.ViewModels
{
    public class AddressVm : ViewModelBase<AddressVm, int>
    {
        public AddressVm(int id) : base(id) { }
        public string Name { get; init; }
        public string Description { get; init; }
        public override string DisplayMember => Name;
    }
}
