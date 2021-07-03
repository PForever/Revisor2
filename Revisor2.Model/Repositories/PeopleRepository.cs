using Revisor2.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisor2.Model.Repositories
{
    public class PeopleRepository : IDisposable, IAsyncDisposable
    {
        readonly RevisorContext _context = new();
        public PeopleRepository()
        {
        }

        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }

        public IList<PersonVm>GetPeoples()
        {
            return _context.RoomPeople.ToList().Select(p =>
                new PersonVm
                {
                    Id = p.Id,
                    Age = p.Age,
                    Address = p.Address,
                    CallDate = p.CallDate,
                    CallResult = p.CallResult,
                    CallsCount = p.CallsCount,
                    Contributions = p.Contributions?.Select(p => new ContributionVm { 
                                                                    Id = p.Id,
                                                                    Description = p.Description,
                                                                    Month = p.Month,
                                                                    Result = p.Result,
                                                                    RoomPersonId = p.RoomPersonId,
                                                                    Type = p.Type
                                                                }).ToList(),
                    DisconnectsCount = p.DisconnectsCount,
                    Discription = p.Discription,
                    Floor = p.Floor,
                    InviteDate = p.InviteDate,
                    PaperCount = p.PaperCount,
                    Inviter = p.Inviter,
                    IsRoom = p.IsRoom,
                    IvitePlace = p.IvitePlace,
                    LastPaper = p.LastPaper,
                    LastСontribution = p.LastСontribution,
                    MeetDate = p.MeetDate,
                    MeetPerson = p.MeetPerson,
                    Name = p.Name,
                    OrgState = p.OrgState,
                    PhoneNumber = p.PhoneNumber,
                    Porch = p.Porch,
                    Room = p.Room,
                    SosialStatus = p.SosialStatus,
                    WorkType = p.WorkType
                }).ToList();
        }

        public ValueTask DisposeAsync()
        {
            return ((IAsyncDisposable)_context).DisposeAsync();
        }
    }
}
