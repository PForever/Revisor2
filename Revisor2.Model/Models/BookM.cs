﻿using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class BookM : DomainModelBase<BookM, Guid>
    {
        public BookM(Guid id) : base(id) { }
        public string Name { get; set; }
        public override string DisplayMember => Name;
    }
}