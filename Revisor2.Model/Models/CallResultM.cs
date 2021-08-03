using System;

namespace Revisor2.Model.Models
{
    public class CallResultM : DomainModelBase<CallResultM, int>
    {
        public CallResultM(int id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}