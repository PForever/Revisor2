using Revisor2.Model.Infrastructure;

namespace Revisor2.Model.Models
{
    public class SosialSatusM : DomainModelBase<SosialSatusM, int>
    {
        public SosialSatusM(int id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}