using Revisor2.Model.Infrastructure;

namespace Revisor2.Model.Repositories
{
    public class PlaceM : DomainModelBase<PlaceM, int>
    {
        public PlaceM(int id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}