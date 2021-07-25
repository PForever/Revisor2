using Revisor2.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisor2.Model.Repositories
{
    public class AddressesRepository
    {
        public AddressesRepository()
        {
        }
        public ICollection<AddressVm> GetAddresses()
        {
            using var context = new RevisorContext();
            return context.Addresses.AsEnumerable().Select(a => new AddressVm (a.Id) { Name = a.Name }).ToList();
        }
    }
}
