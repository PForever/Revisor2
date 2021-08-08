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
    public static class PersonMapToModel
    {
        public static PersonM Map(Person s)
        {
            return new PersonM
            (
                s.Id,
                s.Name,
                s.SourceId,
                s.Age,
                s.SosialStatus.Convert(Map),
                s.Inviter.Convert(Map),
                s.InvitePlace.Convert(Map),
                s.InviteDate.ToDateTime(),
                s.OrgState.Convert(Map),
                s.PhoneNumber,
                s.Description,
                s.IsRoom,
                s.WorkType.Convert(Map),
                s.CallDate.ToDateTime(),
                s.MeetDate.ToDateTime(),
                s.MeetPerson.Convert(Map),
                s.Address.Convert(Map),
                s.Room,
                s.Floor,
                s.Porch,
                s.Calls.Count(ss => ss.CallTargetResults.FirstOrDefault()?.Id == DomainDataHelper.NoResposed) is var disCount &&
                                                            s.Source.DisconnectsCount is null ?
                                                            disCount : Math.Max(s.Source.DisconnectsCount.Value, disCount),
                s.Calls.Count is var count &&
                                s.Source.CallsCount is null ?
                                count : Math.Max(s.Source.CallsCount.Value, count),
                s.Papers.Count,
                s.Papers.LastOrDefault()?.Number,
                s.Contributions.OrderBy(c => c.Month.DateStart).LastOrDefault()?
                                    .ValueResults.Select(r => r.Value).DefaultIfEmpty().Sum()
            )
            {
                Papers = s.Papers.ForEachConvert(Map).ToDomainModelCollection(),
                Books = s.Books.ForEachConvert(Map).ToDomainModelCollection(),
                Subscribes = s.Subscribes.ForEachConvert(Map).ToDomainModelCollection(),
            }
            .Transform(p => p.Calls = s.Calls.ForEachConvert(Map).ToDomainModelCollection(p, (r, c) => r.Person = c))
            .Transform(p => p.Events = s.Events.ForEachConvert(Map).ToDomainModelCollection(p, (r, c) => r.Person = c))
            .Transform(p => p.Contributions = s.Contributions.ForEachConvert(Map).ToDomainModelCollection(p, (r, c) => r.Person = c))
            ;
        }

        private static OrgPersonM Map(OrgPerson ss) => new OrgPersonM(ss.Id, ss.ShortName);
        private static PlaceM Map(Place ss) => new PlaceM(ss.Id, ss.Name);
        private static OrgStateM Map(OrgState ss) => new OrgStateM(ss.Id, ss.Name);
        private static WorkTypeM Map(WorkType ss) => new WorkTypeM(ss.Id, ss.Name);
        private static AddressM Map(Address ss) => new AddressM(ss.Id, ss.Name, ss.Description);
        private static SosialStatusM Map(SosialStatus ss) => new SosialStatusM(ss.Id, ss.Name);
        private static ContributionM Map(Contribution src) => 
            new ContributionM(src.Id,
                src.MeetPerson.Convert(Map),
                src.Month.Convert(Map),
                src.Description
            )
            .Transform(d => d.BookResults = src.BookResults.ForEachConvert(Map).ToDomainModelCollection(d, (r, c) => r.Contribution = c))
            .Transform(d => d.SubscribeResults = src.SubscribeResults.ForEachConvert(Map).ToDomainModelCollection(d, (r, c) => r.Contribution = c))
            .Transform(d => d.ValueResults = src.ValueResults.ForEachConvert(Map).ToDomainModelCollection(d, (r, c) => r.Contribution = c))
            .Transform(d => d.PaperResults = src.PaperResults.ForEachConvert(Map).ToDomainModelCollection(d, (r, c) => r.Contribution = c))
            ;

        private static BookResultM Map(BookResult obj)
        {
            return new BookResultM(obj.Id,
                obj.Date.ToDateTime(),
                obj.Book.Convert(Map)
            );
        }

        private static SubscribeResultM Map(SubscribeResult obj)
        {
            return new SubscribeResultM(obj.Id,
                obj.Date.ToDateTime(),
                obj.Subscribe.Convert(Map),
                obj.Value
            );
        }
        //TODO решить проблемы как рекурсивных вычислений, так и повторных созданий фабрикой. Фабрика хранит коллекцию с Id, методы создания принимают флаг reload
        //TODO Но надо подумать как не выгружать дерево на каждый чих
        //TODO Возможно, имеет смысл вообще убить модель до уровня отображаемых примитивов + Id, и подргужать только в карточках. Но что делать с фильтрами? Фильтр по бд-структуре? Как вариант.
        private static ValueResultM Map(ValueResult obj)
        {
            return new ValueResultM(obj.Id,
                obj.Date.ToDateTime(),
                obj.Value
            );
        }
        private static PaperResultM Map(PaperResult obj)
        {
            return new PaperResultM(obj.Id,
                obj.Date.ToDateTime(),
                obj.Paper.Convert(Map)
            );
        }
        private static MonthM Map(Month obj)
        {
            return new MonthM(obj.Id,
            
                obj.Name,
                obj.DateStart.ToDateTime(),
                obj.DateFinish.ToDateTime()
            );
        }

        private static BookM Map(Book obj)
        {
            return new BookM(obj.Id,
                obj.Name,
                obj.ShortName,
                obj.Author,
                obj.Price,
                obj.Year,
                obj.Description
            );
        }
        private static SubscribeM Map(Subscribe obj)
        {
            return new SubscribeM(obj.Id, obj.Name, obj.Value);
        }
        private static PaperM Map(Paper obj)
        {
            return new PaperM
            (
                obj.Id,
                obj.Name,
                obj.Number
            );
        }


        private static CallEventResultM Map(CallEventResult src) =>
            new CallEventResultM
            (
                src.Id,
                src.CallEvent.Convert(Map),
                src.Caller.Convert(Map),
                src.Description
            )
            .Transform(d => d.CallTargetResults = src.CallTargetResults.ForEachConvert(Map).ToDomainModelCollection(d, (r, c) => r.CallEventResult = c));

        private static CallEventM Map(CallEvent src) =>
            new CallEventM
            (
                src.Id,
                src.CallDate.ToDateTime()
                //TODO
            );
        private static CallTargetResultM Map(CallTargetResult src) =>
            new CallTargetResultM
            (
                src.Id,
                src.Target.Convert(Map),
                src.CallResultType.Convert(Map)
            );
        private static CallResultTypeM Map(CallResultType src) =>
            new CallResultTypeM
            (
                src.Id,
                src.Name
            );
        private static EventM Map(Event src) =>
            new EventM
            (
                src.Id,
                src.CallDate.ToDateTime(),
                src.EventType.Convert(Map)
                //TODO
            );
        private static EventTypeM Map(EventType src) => new EventTypeM(src.Id, src.Name);


        private static PersonEventResultM Map(PersonEventResult src) =>
            new PersonEventResultM
            (
                src.Id,
                src.Event.Convert(Map),
                src.EventRole.Convert(Map),
                src.EventResultType.Convert(Map),
                src.Description
            );
        private static EventResultTypeM Map(EventResultType src) => new EventResultTypeM(src.Id, src.Name);

        private static EventRoleM Map(EventRole src) => new EventRoleM(src.Id, src.Name);
    }
}
