using System;

namespace Revisor2.Model.ViewModels
{
    public class OrgStateVm : ViewModelBase<OrgStateVm, int>
    {
        public OrgStateVm(int id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}