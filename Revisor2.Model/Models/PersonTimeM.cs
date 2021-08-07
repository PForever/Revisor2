using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class PersonTimeM : DomainModelBase<PersonTimeM, Guid>
    {
        public PersonTimeM() { }
        public PersonTimeM(Guid id) : base(id) { }
        public PersonTimeM Person { get; }
        public TimeOnly Start { get; }
        public TimeOnly Finish { get; }
        public override string DisplayMember => $"{Person} - ({Start} - {Finish})";
    }
}