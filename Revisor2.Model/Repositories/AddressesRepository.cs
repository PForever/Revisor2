using Microsoft.EntityFrameworkCore;
using Revisor2.Model.Data;
using Revisor2.Model.Infrastructure;
using Revisor2.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemHelpers;

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
            return context.Addresses
                .Include(a => a.People)
                .Include(a => a.Bypasses)
                .Include(a => a.Porches)
                .AsEnumerable()
                .Select(a => 
                        new AddressM (a.Id, a.Name, a.Description)
                        .Transform(m => m.People = a.People.Select(s => new PersonM
                                                                            (
                                                                                s.Id,
                                                                                s.Name,
                                                                                s.SourceId,
                                                                                s.Age,
                                                                                null,
                                                                                null,
                                                                                null,
                                                                                s.InviteDate.ToDateTime(),
                                                                                null,
                                                                                s.PhoneNumber,
                                                                                s.Description,
                                                                                s.IsRoom,
                                                                                null,
                                                                                s.CallDate.ToDateTime(),
                                                                                s.MeetDate.ToDateTime(),
                                                                                null,
                                                                                null,
                                                                                s.Room,
                                                                                s.Floor,
                                                                                s.Porch,
                                                                                0,
                                                                                0,
                                                                                null,
                                                                                null,
                                                                                null
                                                                            )).ToDomainModelCollection()
                        )
                )
                .OrderBy(a => a.Name).ToList();
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
