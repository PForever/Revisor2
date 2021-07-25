using Revisor2.Model.ViewModels;

namespace Revisor2.Model.Repositories
{
    public class PlaceVm : ViewModelBase<PlaceVm, int>
    {
        public PlaceVm(int id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}