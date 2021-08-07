using Mapster;
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
    public static class MapProvider
    {
        static MapProvider()
        {
            TypeAdapterConfig<Person, PersonM>.NewConfig().MapToConstructor(true).Map("Id", "Id")
                .Map(m => m.PaperCount, p => Math.Max(p.Source.PaperCount ?? 0, p.Papers.Count) )
                .Map(m => m.LastPaper, p => p.Papers.LastOrDefault())
                .Map(m => m.LastСontribution, p => p.Contributions.LastOrDefault())
                .Compile();

            TypeAdapterConfig<Person, PersonM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<SosialStatus, SosialStatusM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<OrgPerson, OrgPersonM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<Place, PlaceM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<OrgState, OrgStateM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<WorkType, WorkTypeM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<CallResultType, CallResultTypeM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<Address, AddressM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<Paper, PaperM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<Contribution, ContributionM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();

            TypeAdapterConfig<CallEvent, CallEventM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<CallEventResult, CallEventResultM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<CallTargetResult, CallTargetResultM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<EventResultType, EventResultTypeM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<PersonEventResult, PersonEventResultM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<OrgPersonEventResult, OrgPersonEventResultM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<EventResultType, EventResultTypeM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<Event, EventM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<EventRole, EventRoleM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();
            TypeAdapterConfig<EventType, EventTypeM>.NewConfig().MapToConstructor(true).Map("Id", "Id").Compile();

            //TypeAdapterConfig<DateTime, DateOnly>.NewConfig().MapWith(src => src.ToDate()).Compile();
        }
    }
    public class PeopleRepository
    {
        private List<PersonM> _people;
        private List<SosialStatusM> _sosialStatus;
        private List<OrgPersonM> _orgPeople;
        private List<PlaceM> _places;
        private List<OrgStateM> _orgStates;
        private List<WorkTypeM> _workTypes;
        private List<CallResultTypeM> _callResults;
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
            if (predicate != null) res = res.Where(predicate);
            return res.ToList().Select(p => p.Adapt<PersonM>());
        }

        public IList<SosialStatusM> GetSosialSatus() => _sosialStatus ??= GetPeoples().Select(p => p.SosialStatus).ToList();
        public IList<OrgPersonM> GetOrgPeople() => _orgPeople ??= GetPeoples().Select(p => p.Inviter).ToList();
        public IList<PlaceM> GetPlaces() => _places ??= GetPeoples().Select(p => p.InvitePlace).ToList();
        public IList<OrgStateM> GetOrgStates() => _orgStates ??= GetPeoples().Select(p => p.OrgState).ToList();
        public IList<WorkTypeM> GetWorkTypes() => _workTypes ??= GetPeoples().Select(p => p.WorkType).ToList();
        //public IList<CallResultTypeM> GetCallResults() => _callResults ??= GetPeoples().Select(p => p.LatCallResult).ToList();
        //public IList<AddressVm> GetAddresses() => _addresses ??= GetPeoples().Select(p => p.Address).Where(p => p is not null).Distinct().OrderBy(p => p).Select((p, i) => new AddressVm(i) { Name = p.Name }).ToList();
        public IList<AddressM> GetAddresses()
        {
            using var context = new RevisorContext();
            IQueryable<RoomPerson> res = context.RoomPeople;
            return res.Where(p => !string.IsNullOrEmpty(p.Address)).Select(p => p.Address).Distinct().AsEnumerable().Select((a, i) => (Address: a, Id: i))
                .Select(a => new AddressM(Guid.NewGuid()) { Name = a.Address }).ToList();

        }

        public void SavePerson(PersonM person)
        {
            using var context = new RevisorContext();
            var model = context.RoomPeople.FirstOrDefault(m => m.Id == person.SourceId) ?? context.RoomPeople.Add(new RoomPerson()).Entity;
            _ = person.Adapt(model);
            var result = context.SaveChanges();
            person.SourceId = model.Id;
        }
    }
}
