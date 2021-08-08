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

        public BypassM(Guid id, DateTime bypassDate, AddressM address, MonthM month, bool isComplited, string description) : base(id)
        {
            _bypassDate = bypassDate;
            _address = address ?? throw new ArgumentNullException(nameof(address));
            _month = month ?? throw new ArgumentNullException(nameof(month));
            _IsComplited = isComplited;
            _Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        private DateTime _bypassDate;
        private AddressM _address;
        private MonthM _month;

        public MonthM Month { get => _month; set => Set(ref _month, value); }

        public DateTime BypassDate { get => _bypassDate; set => Set(ref _bypassDate, value); }
        public AddressM Address { get => _address; set => Set(ref _address, value); }
        public string AddressName { get => _address.Name; }
        public override string DisplayMember => $"{AddressName} ({BypassDate})";

        ObservableCollection<ContributionM> Contributions { get; } = new();
        ObservableCollection<PersonTimeM> PersonTimes { get; } = new();
        private bool _IsComplited;
        public bool IsComplited { get => _IsComplited; set => Set(ref _IsComplited, value); }
        private string _Description;
        public string Description { get => _Description; set => Set(ref _Description, value); }
    }
}
