namespace Revisor2.Model.ViewModels
{
    public class SosialSatusVm : ViewModelBase<SosialSatusVm, int>
    {
        public SosialSatusVm(int id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}