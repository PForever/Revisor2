using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class PlaceM : DomainModelBase<PlaceM, Guid>
    {
        public PlaceM() { }
        public PlaceM(Guid id) : base(id) { }
        public string Name { get; init; }

        public override string DisplayMember => Name;
    }
}