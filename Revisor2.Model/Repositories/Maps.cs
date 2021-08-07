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
    public static class Maps
    {
        public static PersonM Map(Person s)
        {
            return new PersonM
            {
                Name = s.Name,
                SourceId = s.SourceId,
                Age = s.Age,
                SosialStatus = s.SosialStatus.Convert(Map),
                Inviter = s.Inviter.Convert(Map),
                InvitePlace = s.InvitePlace.Convert(Map),
                InviteDate = s.InviteDate,
                Papers = s.Papers.ForEachConvert(Map).ToDomainModelCollection(),
                Books = s.Books.ForEachConvert(Map).ToDomainModelCollection(),
                Subscribes = s.Subscribes.ForEachConvert(Map).ToDomainModelCollection(),
                OrgState = s.OrgState.Convert(Map),
                PhoneNumber = s.PhoneNumber,
                Description = s.Description,
                IsRoom = s.IsRoom,
                WorkType = s.WorkType.Convert(Map),
                CallDate = s.CallDate,
                MeetDate = s.MeetDate,
                MeetPerson = s.MeetPerson.Convert(Map),
                Address = s.Address.Convert(Map),
                Room = s.Room,
                Floor = s.Floor,
                Porch = s.Porch,

                DisconnectsCount = s.Calls.Count(ss => ss.CallTargetResults.FirstOrDefault().Id == DomainDataHelper.NoResposed) is var count &&
                                                            (s.Source is null || s.Source.DisconnectsCount is null) ? count : Math.Max(s.Source.DisconnectsCount.Value, count),
                PaperCount = s.Papers.Count,
                LastPaper = s.Papers.LastOrDefault().Convert(ss => new PaperM { Id = ss.Id, Name = ss.Name, Number = ss.Number }),
            }
            .Transform(p => p.LastСontribution = s.Contributions.LastOrDefault().Convert(c => Map(c, p)))
            .Transform(p => p.Calls = s.Calls.ForEachConvert(Map).ToDomainModelCollection(p, (r, c) => r.Person = c))
            .Transform(p => p.Events = s.Events.ForEachConvert(Map).ToDomainModelCollection(p, (r, c) => r.Person = c))
            ;
        }

        private static OrgPersonM Map(OrgPerson ss) => new OrgPersonM(ss.Id) { ShortName = ss.ShortName };
        private static PlaceM Map(Place ss) => new PlaceM(ss.Id) { Name = ss.Name };
        private static OrgStateM Map(OrgState ss) => new OrgStateM(ss.Id) { Name = ss.Name };
        private static WorkTypeM Map(WorkType ss) => new WorkTypeM(ss.Id) { Name = ss.Name };
        private static AddressM Map(Address ss) => new AddressM(ss.Id) { Name = ss.Name };
        private static SosialStatusM Map(SosialStatus ss) => new SosialStatusM(ss.Id) { Name = ss.Name };
        private static ContributionM Map(Contribution src, PersonM person) => 
            new ContributionM(src.Id) 
            {
                MeetPerson = src.MeetPerson.Convert(Map),
                Description = src.Description,
                Month = src.Month.Convert(Map),
                Person = person,
            }
            .Transform(d => src.BookResults.ForEachConvert(Map).ToDomainModelCollection(d, (r, c) => r.Contribution = c))
            .Transform(d => src.SubscribeResults.ForEachConvert(Map).ToDomainModelCollection(d, (r, c) => r.Contribution = c))
            .Transform(d => src.ValueResults.ForEachConvert(Map).ToDomainModelCollection(d, (r, c) => r.Contribution = c))
            .Transform(d => src.PaperResults.ForEachConvert(Map).ToDomainModelCollection(d, (r, c) => r.Contribution = c))
            ;

        private static BookResultM Map(BookResult obj)
        {
            return new BookResultM(obj.Id)
            {
                Book = obj.Book.Convert(Map),
                Date = obj.Date,
            };
        }

        private static SubscribeResultM Map(SubscribeResult obj)
        {
            return new SubscribeResultM(obj.Id)
            {
                Subscribe = obj.Subscribe.Convert(Map),
                Date = obj.Date,
                Value = obj.Value,
            };
        }
        //TODO решить проблемы как рекурсивных вычислений, так и повторных созданий фабрикой. Фабрика хранит коллекцию с Id, методы создания принимают флаг reload
        //TODO Но надо подумать как не выгружать дерево на каждый чих
        //TODO Возможно, имеет смысл вообще убить модель до уровня отображаемых примитивов + Id, и подргужать только в карточках. Но что делать с фильтрами? Фильтр по бд-структуре? Как вариант.
        private static ValueResultM Map(ValueResult obj)
        {
            return new ValueResultM(obj.Id)
            {
                Date = obj.Date,
                Value = obj.Value,
            };
        }
        private static PaperResultM Map(PaperResult obj)
        {
            return new PaperResultM(obj.Id)
            {
                Date = obj.Date,
                Paper = obj.Paper.Convert(Map),
            };
        }
        private static MonthM Map(Month obj)
        {
            return new MonthM(obj.Id)
            {
                Name = obj.Name,
                DateFinish = obj.DateFinish,
                DateStart = obj.DateStart,
            };
        }

        private static BookM Map(Book obj)
        {
            return new BookM(obj.Id)
            {
                Name = obj.Name,
                Description = obj.Description,
                Price = obj.Price,
                ShortName = obj.ShortName,
            };
        }
        private static SubscribeM Map(Subscribe obj)
        {
            return new SubscribeM(obj.Id)
            {
                Name = obj.Name,
            };
        }
        private static PaperM Map(Paper obj)
        {
            return new PaperM(obj.Id)
            {
                Name = obj.Name,
                Number = obj.Number,
            };
        }


        private static CallEventResultM Map(CallEventResult src) =>
            new CallEventResultM(src.Id)
            {
                Caller = src.Caller.Convert(Map),
                CallEvent = src.CallEvent.Convert(Map),
            }
            .Transform(d => src.CallTargetResults.ForEachConvert(Map).ToDomainModelCollection(d, (r, c) => r.CallEventResult = c));

        private static CallEventM Map(CallEvent src) =>
            new CallEventM(src.Id)
            {
                CallDate = src.CallDate,
                //TODO
            };
        private static CallTargetResultM Map(CallTargetResult src) =>
            new CallTargetResultM(src.Id)
            {
                CallResultType = src.CallResultType.Convert(Map),
                Target = src.Target.Convert(Map),
            };
        private static CallResultTypeM Map(CallResultType src) =>
            new CallResultTypeM(src.Id)
            {
                Name = src.Name,
            };
        private static EventM Map(Event src) =>
            new EventM(src.Id)
            {
                CallDate = src.CallDate,
                EventType = src.EventType.Convert(Map),
                //TODO
            };
        private static EventTypeM Map(EventType src) => new EventTypeM(src.Id)
        {
            Name = src.Name,
        };


        private static PersonEventResultM Map(PersonEventResult src) =>
            new PersonEventResultM(src.Id)
            {
                Event = src.Event.Convert(Map),
                EventRole = src.EventRole.Convert(Map),
                EventResultType = src.EventResultType.Convert(Map),
            };
        private static EventResultTypeM Map(EventResultType src) => new EventResultTypeM(src.Id)
        {
            Name = src.Name,
        };

        private static EventRoleM Map(EventRole src) => new EventRoleM(src.Id)
        {
            Name = src.Name,
        };
    }
}
