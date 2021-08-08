using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisor2.Model.Models
{
    public class BypassListVm
    {
        public ObservableCollection<BypassM> Bypasses { get; }
        public BypassM Create() => new BypassM();
    }
    public class PeopleVm
    {
        public ObservableCollection<PersonM> Bypasses { get; }
        public BypassM Create() => new BypassM();
    }
}
