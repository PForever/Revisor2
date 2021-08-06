using Revisor2.Model.Infrastructure;
using System;
using System.Collections.ObjectModel;

namespace Revisor2.Model.Models
{
    public class AddressM : DomainModelBase<AddressM, int>
    {
        public AddressM(int id) : base(id) { }

        public ObservableCollection<BypassM> Bypasses { get; } = new();
        public ObservableCollection<PersonM> People { get; } = new();
        public ObservableCollection<PorchM> Porches { get; } = new();
        public string Name { get; set; }
        public string Description { get; set; }
        public override string DisplayMember => Name;
    }
}
