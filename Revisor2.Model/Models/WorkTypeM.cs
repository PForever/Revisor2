using Revisor2.Model.Infrastructure;

namespace Revisor2.Model.Models
{
    public class WorkTypeM : DomainModelBase<WorkTypeM, int>
    {
        public WorkTypeM() { }
        public WorkTypeM(int id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}