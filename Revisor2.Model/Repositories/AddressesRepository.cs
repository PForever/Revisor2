using Microsoft.EntityFrameworkCore;
using Revisor2.Model.Data;
using Revisor2.Model.Models;
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
        public ICollection<AddressM> GetAddresses()
        {
            using var context = new RevisorContext();
            return new List<AddressM>(); //TODO заглушка
            return context.Addresses.AsEnumerable().Select(a => new AddressM (a.Id) { Name = a.Name }).ToList();
        }
        public void Remove(PorchM porch)
        {
            using var context = new RevisorContext();
            context.Entry(porch).State = EntityState.Deleted;
            context.SaveChanges();
        }
        public void Remove(BypassM bypass)
        {
            using var context = new RevisorContext();
            context.Entry(bypass).State = EntityState.Deleted;
            context.SaveChanges();
        }
        public void Remove(AddressM address, PersonM person)
        {
            using var context = new RevisorContext();
            var model = context.Addresses.Find(address.Id);
            //model.RoomPeople.Remove(persom);
            context.SaveChanges();
        }

        public void Add(AddressM model)
        {
            throw new NotImplementedException();
        }

        public void Remove(AddressM model)
        {
            throw new NotImplementedException();
        }
    }
}
