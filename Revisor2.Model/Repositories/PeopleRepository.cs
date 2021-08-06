using Revisor2.Model.Data;
using Revisor2.Model.Infrastructure;
using Revisor2.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SystemHelpers;

namespace Revisor2.Model.Repositories
{
    public class PeopleRepository
    {
        private List<PersonM> _people;
        private List<SosialSatusM> _sosialStatus;
        private List<OrgPersonM> _orgPeople;
        private List<PlaceM> _places;
        private List<OrgStateM> _orgStates;
        private List<WorkTypeM> _workTypes;
        private List<CallResultM> _callResults;
        private List<AddressM> _addresses;

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
        public IList<PersonM> GetPeoples(LambdaExpression predicate)
        {
            return GetData(predicate as Expression<Func<RoomPerson, bool>>).ToList();
        }
        public IList<PersonM> GetPeoples()
        {
            return _people ??= GetPeoplesInternal();
        }

        private List<PersonM> GetPeoplesInternal()
        {
            return GetData(null).ToList();
        }

        private static IEnumerable<PersonM> GetData(Expression<Func<RoomPerson, bool>> predicate)
        {
            using var context = new RevisorContext();
            IQueryable<RoomPerson> res = context.RoomPeople;
            var addreses = res.Where(p => !string.IsNullOrEmpty(p.Address)).Select(p => p.Address).Distinct().AsEnumerable().Select((a, i) => (Address: a, Id: i))
                .ToDictionary(a => a.Address, a => new AddressM(a.Id) { Name = a.Address }, StringComparer.OrdinalIgnoreCase);
            if (predicate != null) res = res.Where(predicate);
            return res.ToList().Select(p =>
                           new PersonM(Guid.NewGuid())
                           {
                               SourceId = p.Id,
                               Age = p.Age,
                               Address = string.IsNullOrEmpty(p.Address) ? null : addreses[p.Address],
                               CallDate = p.CallDate.ToDate(),
                               CallResult = p.CallResult,
                               CallsCount = p.CallsCount ?? 0,
                               
                               DisconnectsCount = p.DisconnectsCount ?? 0,
                               Discription = p.Discription,
                               Floor = p.Floor,
                               InviteDate = p.InviteDate.ToDate(),
                               PaperCount = p.PaperCount,
                               Inviter = p.Inviter,
                               IsRoom = p.IsRoom ?? false,
                               InvitePlace = p.IvitePlace,
                               LastPaper = p.LastPaper,
                               LastСontribution = p.LastСontribution,
                               MeetDate = p.MeetDate.ToDate(),
                               MeetPerson = p.MeetPerson,
                               Name = p.Name,
                               OrgState = p.OrgState,
                               PhoneNumber = p.PhoneNumber,
                               Porch = p.Porch,
                               Room = p.Room,
                               SosialStatus = p.SosialStatus,
                               WorkType = p.WorkType
                           }.Transform(m => m.Contributions = p.Contributions?
                                                               .Select(p => new ContributionM(Guid.NewGuid())
                                                                                       {
                                                                                           Person = m,
                                                                                           Description = p.Description,
                                                                                           //Month = p.Month,
                                                                                       }.Transform(cm => cm.BookResults = Array.Empty<BookResultM>().ToViewModelCollection(cm, (c, p) => c.Contribution = p))
                                                               )
                                                               .ToViewModelCollection(m, (c, p) => c.Person = p)));
        }

        public IList<SosialSatusM> GetSosialSatus() => _sosialStatus ??= GetPeoples().Select(p => p.SosialStatus).Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().OrderBy(p => p).Select((p, i) => new SosialSatusM(i) { Name = p }).ToList();
        public IList<OrgPersonM> GetOrgPeople() => _orgPeople ??= GetPeoples().Select(p => p.Inviter).Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().OrderBy(p => p).Select((p, i) => new OrgPersonM(i) { Name = p }).ToList();
        public IList<PlaceM> GetPlaces() => _places ??= GetPeoples().Select(p => p.InvitePlace).Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().OrderBy(p => p).Select(p => new PlaceM(-1) { Name = p }).ToList();
        public IList<OrgStateM> GetOrgStates() => _orgStates ??= GetPeoples().Select(p => p.OrgState).Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().OrderBy(p => p).Select((p, i) => new OrgStateM(i) { Name = p }).ToList();
        public IList<WorkTypeM> GetWorkTypes() => _workTypes ??= GetPeoples().Select(p => p.WorkType).Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().OrderBy(p => p).Select((p, i) => new WorkTypeM(i) { Name = p }).ToList();
        public IList<CallResultM> GetCallResults() => _callResults ??= GetPeoples().Select(p => p.CallResult).Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().OrderBy(p => p).Select((p, i) => new CallResultM(i) { Name = p }).ToList();
        //public IList<AddressVm> GetAddresses() => _addresses ??= GetPeoples().Select(p => p.Address).Where(p => p is not null).Distinct().OrderBy(p => p).Select((p, i) => new AddressVm(i) { Name = p.Name }).ToList();
        public IList<AddressM> GetAddresses()
        {
            using var context = new RevisorContext();
            IQueryable<RoomPerson> res = context.RoomPeople;
            return res.Where(p => !string.IsNullOrEmpty(p.Address)).Select(p => p.Address).Distinct().AsEnumerable().Select((a, i) => (Address: a, Id: i))
                .Select(a => new AddressM(a.Id) { Name = a.Address }).ToList();

        }

        public void SavePerson(PersonM person)
        {
            using var context = new RevisorContext();
            var model = context.RoomPeople.FirstOrDefault(m => m.Id == person.SourceId) ?? context.RoomPeople.Add(new RoomPerson()).Entity;
            model.Name = person.Name;
            model.Address = person.Address.Name;
            model.Age = person.Age;
            model.CallDate = person.CallDate.ToDateTime();
            model.CallResult = person.CallResult;
            model.CallsCount = person.CallsCount;
            model.DisconnectsCount = person.DisconnectsCount;
            model.Discription = person.Discription;
            model.Floor = person.Floor;
            model.InviteDate = person.InviteDate.ToDateTime();
            model.Inviter = person.Inviter;
            model.IsRoom = person.IsRoom;
            model.IvitePlace = person.InvitePlace;
            model.LastPaper = person.LastPaper;
            model.LastСontribution = person.LastСontribution;
            model.MeetDate = person.MeetDate.ToDateTime();
            model.MeetPerson = person.MeetPerson;
            model.OrgState = person.OrgState;
            model.PaperCount = person.PaperCount;
            model.PhoneNumber = person.PhoneNumber;
            model.Porch = person.Porch;
            model.Room = person.Room;
            model.SosialStatus = person.SosialStatus;
            model.WorkType = person.WorkType;

            var result = context.SaveChanges();
            person.SourceId = model.Id;
        }
    }
}
