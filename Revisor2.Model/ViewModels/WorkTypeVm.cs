namespace Revisor2.Model.ViewModels
{
    public class WorkTypeVm : ViewModelBase<WorkTypeVm, int>
    {
        public WorkTypeVm(int id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}