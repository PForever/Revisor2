﻿using System;

namespace Revisor2.Model.Models
{
    public class OrgPersonM : DomainModelBase<OrgPersonM, int>
    {
        public OrgPersonM(int id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}