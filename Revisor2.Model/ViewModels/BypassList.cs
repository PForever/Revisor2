using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisor2.Model.ViewModels
{
    public class BypassListVm
    {
        public ObservableCollection<BypassVm> Bypasses { get; }
        public BypassVm Create() => new BypassVm();
    }
    public class PeopleVm
    {
        public ObservableCollection<PersonVm> Bypasses { get; }
        public BypassVm Create() => new BypassVm();
    }
}
