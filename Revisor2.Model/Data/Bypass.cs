using Revisor2.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Revisor2.Model.Data
{
    public class Bypass
    {
        public Guid Id { get; set; }
        public Guid MonthId { get; set; }
        public Month Month { get; set; }

        public DateOnly BypassDate { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        ICollection<Contribution> Contributions { get; set; }
        ICollection<PersonTime> PersonTimes { get; set; }
        public bool IsComplited { get; set; }
        public string Description { get; set; }
    }
}
