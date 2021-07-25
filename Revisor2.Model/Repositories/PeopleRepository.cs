using Revisor2.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Revisor2.Model.Repositories
{
    public class PeopleRepository
    {
        private List<PersonVm> _people;
        private List<SosialSatusVm> _sosialStatus;
        private List<OrgPersonVm> _orgPeople;
        private List<PlaceVm> _places;
        private List<OrgStateVm> _orgStates;
        private List<WorkTypeVm> _workTypes;
        private List<CallResultVm> _callResults;
        private List<AddressVm> _addresses;

        public Type DtoType => typeof(RoomPerson);

        public PeopleRepository()
        {
        }
        public void Invalidate()
        {
            _people = null;
            _sosialStatus = null;
            _orgPeople = null;
            _places = null;
            _orgStates = null;
            _workTypes = null;
            _callResults = null;
            _addresses = null;
        }
        public IList<PersonVm> GetPeoples(LambdaExpression predicate)
        {
            return GetData(predicate as Expression<Func<RoomPerson, bool>>).ToList();
        }
        public IList<PersonVm> GetPeoples()
        {
            return _people ??= GetPeoplesInternal();
        }

        private List<PersonVm> GetPeoplesInternal()
        {
            return GetData(null).ToList();
        }

        private static IEnumerable<PersonVm> GetData(Expression<Func<RoomPerson, bool>> predicate)
        {
            using var context = new RevisorContext();
            IQueryable<RoomPerson> res = context.RoomPeople;
            var addreses = res.Where(p => !string.IsNullOrEmpty(p.Address)).Select(p => p.Address).Distinct().AsEnumerable().Select((a, i) => (Address: a, Id: i))
                .ToDictionary(a => a.Address, a => new AddressVm(a.Id) { Name = a.Address }, StringComparer.OrdinalIgnoreCase);
            if (predicate != null) res = res.Where(predicate);
            return res.ToList().Select(p =>
                           new PersonVm(p.Id)
                           {
                               Age = p.Age,
                               Address = string.IsNullOrEmpty(p.Address) ? null : addreses[p.Address],
                               CallDate = p.CallDate,
                               CallResult = p.CallResult,
                               CallsCount = p.CallsCount,
                               Contributions = p.Contributions?.Select(p => new ContributionVm
                               {
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
                           });
        }

        public IList<SosialSatusVm> GetSosialSatus() => _sosialStatus ??= GetPeoples().Select(p => p.SosialStatus).Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().OrderBy(p => p).Select((p, i) => new SosialSatusVm(i) { Name = p }).ToList();
        public IList<OrgPersonVm> GetOrgPeople() => _orgPeople ??= GetPeoples().Select(p => p.Inviter).Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().OrderBy(p => p).Select((p, i) => new OrgPersonVm(i) { Name = p }).ToList();
        public IList<PlaceVm> GetPlaces() => _places ??= GetPeoples().Select(p => p.IvitePlace).Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().OrderBy(p => p).Select(p => new PlaceVm(-1) { Name = p }).ToList();
        public IList<OrgStateVm> GetOrgStates() => _orgStates ??= GetPeoples().Select(p => p.OrgState).Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().OrderBy(p => p).Select((p, i) => new OrgStateVm(i) { Name = p }).ToList();
        public IList<WorkTypeVm> GetWorkTypes() => _workTypes ??= GetPeoples().Select(p => p.WorkType).Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().OrderBy(p => p).Select((p, i) => new WorkTypeVm(i) { Name = p }).ToList();
        public IList<CallResultVm> GetCallResults() => _callResults ??= GetPeoples().Select(p => p.CallResult).Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().OrderBy(p => p).Select((p, i) => new CallResultVm(i) { Name = p }).ToList();
        //public IList<AddressVm> GetAddresses() => _addresses ??= GetPeoples().Select(p => p.Address).Where(p => p is not null).Distinct().OrderBy(p => p).Select((p, i) => new AddressVm(i) { Name = p.Name }).ToList();
        public IList<AddressVm> GetAddresses()
        {
            using var context = new RevisorContext();
            IQueryable<RoomPerson> res = context.RoomPeople;
            return res.Where(p => !string.IsNullOrEmpty(p.Address)).Select(p => p.Address).Distinct().AsEnumerable().Select((a, i) => (Address: a, Id: i))
                .Select(a => new AddressVm(a.Id) { Name = a.Address }).ToList();

        }

        public void SavePerson(PersonVm person)
        {
            using var context = new RevisorContext();
            var model = context.RoomPeople.Find(person.Id) ?? new RoomPerson();
            model.Name = person.Name;
            model.Address = person.Address.Name;
            model.Age = person.Age;
            model.CallDate = person.CallDate;
            model.CallResult = person.CallResult;
            model.CallsCount = person.CallsCount;
            model.DisconnectsCount = person.DisconnectsCount;
            model.Discription = person.Discription;
            model.Floor = person.Floor;
            model.InviteDate = person.InviteDate;
            model.Inviter = person.Inviter;
            model.IsRoom = person.IsRoom;
            model.IvitePlace = person.IvitePlace;
            model.LastPaper = person.LastPaper;
            model.LastСontribution = person.LastСontribution;
            model.MeetDate = person.MeetDate;
            model.MeetPerson = person.MeetPerson;
            model.OrgState = person.OrgState;
            model.PaperCount = person.PaperCount;
            model.PhoneNumber = person.PhoneNumber;
            model.Porch = person.Porch;
            model.Room = person.Room;
            model.SosialStatus = person.SosialStatus;
            model.WorkType = person.WorkType;

            var result = context.SaveChanges();
            person.Id = model.Id;
        }
    }
}
