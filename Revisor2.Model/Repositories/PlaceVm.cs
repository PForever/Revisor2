using Revisor2.Model.Models;

namespace Revisor2.Model.Repositories
{
    public class PlaceVm : DomainModelBase<PlaceVm, int>
    {
        public PlaceVm(int id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}