using System;

namespace Revisor2.Model.ViewModels
{
    public class OrgPersonVm : ViewModelBase<OrgPersonVm, int>
    {
        public OrgPersonVm(int id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}