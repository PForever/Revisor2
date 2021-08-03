namespace Revisor2.Model.Models
{
    public class WorkTypeM : DomainModelBase<WorkTypeM, int>
    {
        public WorkTypeM(int id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}