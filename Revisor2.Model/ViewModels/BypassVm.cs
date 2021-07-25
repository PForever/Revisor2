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

        private DateTime bypassDate;
        private string addressName;
        private Guid addressId;

        public DateTime BypassDate { get => bypassDate; set => Set(ref bypassDate, value); }
        public string AddressName { get => addressName; set => Set(ref addressName, value); }
        public Guid AddressId { get => addressId; set => Set(ref addressId, value); }
        public ICommand SaveCommand { get; }

        public override string DisplayMember => $"{AddressName} ({BypassDate})";

        ObservableCollection<ContributionVm> Contributions { get; } = new();
    }
}
