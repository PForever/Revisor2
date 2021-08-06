using Revisor2.Model.Infrastructure;

namespace Revisor2.Model.Models
{
    public class SosialStatusM : DomainModelBase<SosialStatusM, int>
    {
        public SosialStatusM(int id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}