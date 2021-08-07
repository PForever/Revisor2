using Revisor2.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Revisor2.Model.Models
{
    public class BypassM : DomainModelBase<BypassM, Guid>
    {
        public BypassM() { }
        public BypassM(Guid id) : base(id) { }

        private DateOnly _bypassDate;
        private AddressM _address;
        private MonthM _month;

        public MonthM Month { get => _month; set => Set(ref _month, value); }

        public DateOnly BypassDate { get => _bypassDate; set => Set(ref _bypassDate, value); }
        public AddressM Address { get => _address; set => Set(ref _address, value); }
        public string AddressName { get => _address.Name; }
        public override string DisplayMember => $"{AddressName} ({BypassDate})";

        ObservableCollection<ContributionM> Contributions { get; } = new();
        ObservableCollection<PersonTimeM> PersonTimes { get; } = new();
        public bool IsComplited { get; set; }
        public string Description { get; set; }
    }
}
