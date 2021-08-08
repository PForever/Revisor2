using Revisor2.Model.Infrastructure;
using System;
using System.Collections.ObjectModel;

namespace Revisor2.Model.Models
{
    public class AddressM : DomainModelBase<AddressM, Guid>
    {
        public AddressM() { }
        public AddressM(Guid id, string name, string description) : base(id)
        {
            _Name = name;
            _Description = description;
        }

        public ObservableCollection<BypassM> Bypasses { get; } = new();
        public DomainModelCollection<PersonM> People { get; set; }
        public ObservableCollection<PorchM> Porches { get; } = new();
        private string _Name;
        public string Name { get => _Name; set => Set(ref _Name, value); }
        private string _Description;
        public string Description { get => _Description; set => Set(ref _Description, value); }
        public override string DisplayMember => Name;
    }
}
