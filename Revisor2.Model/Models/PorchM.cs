using System;

namespace Revisor2.Model.Models
{
    public class PorchM : DomainModelBase<PorchM, Guid>
    {
        public PorchM(Guid id) :base(id) {}
        public string Name { get; init; }
        public int? OrderNumber { get; init; }
        public int? FirstRoom { get; init; }
        public int? LastRoom { get; init; }
        public int? Floor { get; init; }
        public override string DisplayMember => $"{Name} ({FirstRoom} - {LastRoom})";
    }
}
