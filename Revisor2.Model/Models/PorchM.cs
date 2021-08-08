using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class PorchM : DomainModelBase<PorchM, Guid>
    {
        public PorchM() {}
        public PorchM(Guid id, string name, int? orderNumber, int? firstRoom, int? lastRoom, int? floor) : base(id)
        {
            _Name = name;
            _OrderNumber = orderNumber;
            _FirstRoom = firstRoom;
            _LastRoom = lastRoom;
            _Floor = floor;
        }
        private string _Name;
        public string Name { get => _Name; set => Set(ref _Name, value); }
        private int? _OrderNumber;
        public int? OrderNumber { get => _OrderNumber; set => Set(ref _OrderNumber, value); }
        private int? _FirstRoom;
        public int? FirstRoom { get => _FirstRoom; set => Set(ref _FirstRoom, value); }
        private int? _LastRoom;
        public int? LastRoom { get => _LastRoom; set => Set(ref _LastRoom, value); }
        private int? _Floor;
        public int? Floor { get => _Floor; set => Set(ref _Floor, value); }
        public override string DisplayMember => $"{Name} ({FirstRoom} - {LastRoom})";
    }
}
