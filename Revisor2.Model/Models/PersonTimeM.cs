﻿using System;

namespace Revisor2.Model.Models
{
    public class PersonTimeM : DomainModelBase<PersonTimeM, Guid>
    {
        public PersonTimeM(Guid id) : base(id) { }
        public PersonTimeM Person { get; }
        public TimeOnly Start { get; }
        public TimeOnly Finish { get; }
        public override string DisplayMember => $"{Person} - ({Start} - {Finish})";
    }
}