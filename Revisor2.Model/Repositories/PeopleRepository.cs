using Mapster;
using Microsoft.EntityFrameworkCore;
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
        public static void SetMap()
        {
            var ctor = typeof(PersonM).GetConstructor(new[] { typeof(Guid) });
            TypeAdapterConfig<Person, PersonM>.NewConfig()
                .ConstructUsing(dto => new PersonM(dto.Id))
                .MapToConstructor(ctor).Map("Id", "Id")
                .Map(m => m.PaperCount, p => Math.Max(p.Source.PaperCount ?? 0, p.Papers.Count) )
                .Map(m => m.LastPaper, p => p.Papers.LastOrDefault())
                .Map(m => m.LastСontribution, p => p.Contributions.LastOrDefault())
                .Compile();
            TypeAdapterConfig<SosialStatus, SosialStatusM>.NewConfig().ConstructUsing(dto => new SosialStatusM(dto.Id)).MapToConstructor(typeof(SosialStatusM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
            TypeAdapterConfig<OrgPerson, OrgPersonM>.NewConfig().ConstructUsing(dto => new OrgPersonM(dto.Id)).MapToConstructor(typeof(OrgPersonM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
            TypeAdapterConfig<Place, PlaceM>.NewConfig().ConstructUsing(dto => new PlaceM(dto.Id)).MapToConstructor(typeof(PlaceM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
            TypeAdapterConfig<OrgState, OrgStateM>.NewConfig().ConstructUsing(dto => new OrgStateM(dto.Id)).MapToConstructor(typeof(OrgStateM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
            TypeAdapterConfig<WorkType, WorkTypeM>.NewConfig().ConstructUsing(dto => new WorkTypeM(dto.Id)).MapToConstructor(typeof(WorkTypeM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
            TypeAdapterConfig<CallResultType, CallResultTypeM>.NewConfig().ConstructUsing(dto => new CallResultTypeM(dto.Id)).MapToConstructor(typeof(CallResultTypeM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
            TypeAdapterConfig<Address, AddressM>.NewConfig().ConstructUsing(dto => new AddressM(dto.Id)).MapToConstructor(typeof(AddressM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
            TypeAdapterConfig<Paper, PaperM>.NewConfig().ConstructUsing(dto => new PaperM(dto.Id)).MapToConstructor(typeof(PaperM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
            TypeAdapterConfig<Contribution, ContributionM>.NewConfig().ConstructUsing(dto => new ContributionM(dto.Id)).MapToConstructor(typeof(ContributionM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();

            TypeAdapterConfig<CallEvent, CallEventM>.NewConfig().ConstructUsing(dto => new CallEventM(dto.Id)).MapToConstructor(typeof(CallEventM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
            TypeAdapterConfig<CallEventResult, CallEventResultM>.NewConfig().ConstructUsing(dto => new CallEventResultM(dto.Id)).MapToConstructor(typeof(CallEventResultM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
            TypeAdapterConfig<CallTargetResult, CallTargetResultM>.NewConfig().ConstructUsing(dto => new CallTargetResultM(dto.Id)).MapToConstructor(typeof(CallTargetResultM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
            TypeAdapterConfig<EventResultType, EventResultTypeM>.NewConfig().ConstructUsing(dto => new EventResultTypeM(dto.Id)).MapToConstructor(typeof(EventResultTypeM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
            TypeAdapterConfig<PersonEventResult, PersonEventResultM>.NewConfig().ConstructUsing(dto => new PersonEventResultM(dto.Id)).MapToConstructor(typeof(PersonEventResultM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
            TypeAdapterConfig<OrgPersonEventResult, OrgPersonEventResultM>.NewConfig().ConstructUsing(dto => new OrgPersonEventResultM(dto.Id)).MapToConstructor(typeof(OrgPersonEventResultM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
            TypeAdapterConfig<EventResultType, EventResultTypeM>.NewConfig().ConstructUsing(dto => new EventResultTypeM(dto.Id)).MapToConstructor(typeof(EventResultTypeM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
            TypeAdapterConfig<Event, EventM>.NewConfig().ConstructUsing(dto => new EventM(dto.Id)).MapToConstructor(typeof(EventM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
            TypeAdapterConfig<EventRole, EventRoleM>.NewConfig().ConstructUsing(dto => new EventRoleM(dto.Id)).MapToConstructor(typeof(EventRoleM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
            TypeAdapterConfig<EventType, EventTypeM>.NewConfig().ConstructUsing(dto => new EventTypeM(dto.Id)).MapToConstructor(typeof(EventTypeM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id").Compile();
        }
        //public static TypeAdapterSetter<TSource, TDest> GetDefaultAdapter<TSource, TDest>() => TypeAdapterConfig<TSource, TDest>.NewConfig().ConstructUsing(dto => SystemHelper.ActivateInstance new SosialStatusM(dto.Id)).MapToConstructor(typeof(SosialStatusM).GetConstructor(new[] { typeof(Guid) })).Map("Id", "Id")
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

        static PeopleRepository()
        {
            MapProvider.SetMap();
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
            return GetData(predicate as Expression<Func<Person, bool>>).ToList();
        }
        public IList<PersonM> GetPeoples()
        {
            return _people ??= GetPeoplesInternal();
        }

        private List<PersonM> GetPeoplesInternal()
        {
            return GetData(null).ToList();
        }

        private static IEnumerable<PersonM> GetData(Expression<Func<Person, bool>> predicate)
        {
            using var context = new RevisorContext();
            IQueryable<Person> res = context.People
                .Include(p => p.OrgPersonNavigation)
                .Include(p => p.Source)
                .Include(p => p.SosialStatus)
                .Include(p => p.Inviter)
                .Include(p => p.InvitePlace)
                .Include(p => p.Papers)
                .Include(p => p.Books)
                .Include(p => p.Subscribes)
                .Include(p => p.Contributions)
                .Include(p => p.Calls).ThenInclude(c => c.CallTargetResults).ThenInclude(t => t.CallResultType)
                .Include(p => p.Events)
                .Include(p => p.OrgState)
                .Include(p => p.WorkType)
                .Include(p => p.MeetPerson)
                .Include(p => p.Address)
                ;
            if (predicate != null) res = res.Where(predicate);
            var list = res.ToList();
            //return list.Select(p => p.Adapt<PersonM>());
            return list.Select(s => Maps.Map(s));
        }

        public IList<SosialStatusM> GetSosialSatus() => _sosialStatus ??= GetPeoples().Select(p => p.SosialStatus).NotNull().Distinct().OrderBy(a => a.Name).ToList();
        public IList<OrgPersonM> GetOrgPeople() => _orgPeople ??= GetPeoples().Select(p => p.Inviter).NotNull().Distinct().OrderBy(a => a.ShortName).ToList();
        public IList<PlaceM> GetPlaces() => _places ??= GetPeoples().Select(p => p.InvitePlace).NotNull().Distinct().OrderBy(a => a.Name).ToList();
        public IList<OrgStateM> GetOrgStates() => _orgStates ??= GetPeoples().Select(p => p.OrgState).NotNull().Distinct().OrderBy(a => a.Name).ToList();
        public IList<WorkTypeM> GetWorkTypes() => _workTypes ??= GetPeoples().Select(p => p.WorkType).NotNull().Distinct().OrderBy(a => a.Name).ToList();
        //public IList<CallResultTypeM> GetCallResults() => _callResults ??= GetPeoples().Select(p => p.LatCallResult).ToList();
        //public IList<AddressVm> GetAddresses() => _addresses ??= GetPeoples().Select(p => p.Address).Where(p => p is not null).Distinct().OrderBy(p => p).Select((p, i) => new AddressVm(i) { Name = p.Name }).ToList();
        public IList<AddressM> GetAddresses() => _addresses ??= GetPeoples().Select(p => p.Address).NotNull().Distinct().OrderBy(a => a.Name).ToList();

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
