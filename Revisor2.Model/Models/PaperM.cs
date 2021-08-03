namespace Revisor2.Model.Models
{
    public class PaperM : DomainModelBase<PaperM, int>
    {
        public PaperM(int id) : base(id) { }
        public int Number { get; init; }

        public override string DisplayMember => Number.ToString();
    }
}