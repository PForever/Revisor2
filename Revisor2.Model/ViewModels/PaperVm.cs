namespace Revisor2.Model.ViewModels
{
    public class PaperVm : ViewModelBase<PaperVm, int>
    {
        public PaperVm(int id) : base(id) { }
        public int Number { get; init; }

        public override string DisplayMember => Number.ToString();
    }
}