using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class PersonTimeM : DomainModelBase<PersonTimeM, Guid>
    {
        private TimeOnly _finish;
        private TimeOnly _start;

        public PersonTimeM() { }
        public PersonTimeM(Guid id, TimeOnly finish, TimeOnly start) : base(id)
        {
            _finish = finish;
            _start = start;
        }
        public PersonTimeM Person { get; set; }
        public TimeOnly Start { get => _start; set => Set(ref _start, value); }
        public TimeOnly Finish { get => _finish; set => Set(ref _finish, value); }
        public override string DisplayMember => $"{Person} - ({Start} - {Finish})";
    }
}