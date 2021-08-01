using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Revisor2.Model.ViewModels
{
    public class BypassVm : ViewModelBase<BypassVm, Guid>
    {
        public BypassVm(Guid id) : base(id) { }

        private DateOnly _bypassDate;
        private AddressVm _address;
        private MonthVm _month;

        public MonthVm Month { get => _month; set => Set(ref _month, value); }

        public DateOnly BypassDate { get => _bypassDate; set => Set(ref _bypassDate, value); }
        public AddressVm Address { get => _address; set => Set(ref _address, value); }
        public string AddressName { get => _address.Name; }
        public ICommand SaveCommand { get; }

        public override string DisplayMember => $"{AddressName} ({BypassDate})";

        ObservableCollection<ContributionVm> Contributions { get; } = new();
        ObservableCollection<PersonTimeVm> PersonTimes { get; } = new();
        public bool IsComplited { get; set; }
        public string Description { get; }
    }
}
