using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class PaperM : DomainModelBase<PaperM, Guid>
    {
        public PaperM() { }
        public PaperM(Guid id) : base(id) { }
        public string Name { get; init; }
        public int Number { get; init; }
        public override string DisplayMember => Number.ToString();
    }
}