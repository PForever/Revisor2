using Microsoft.EntityFrameworkCore;
using Revisor2.Model.Data;
using Revisor2.Model.Infrastructure;
using Revisor2.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemHelpers;

namespace Revisor2.Model.Repositories
{
    public static class PersonMapFromModel
    {
        private static void Remove<T>(T src, DbContext context) => context.Entry(src).State = EntityState.Deleted;
        private static T InsertOrUpdate<T, TModel>(T entity, TModel model, DbContext context) where TModel : IViewModelBase, IHasId
            where T : class
        {
            var entry = context.Entry(entity);
            if (!model.IsChanged && !model.IsNew) entry.State = EntityState.Unchanged;
            else entry.State = model.IsNew ? EntityState.Added : EntityState.Modified;
            return entry.Entity;
            //if (entry.State != EntityState.Detached) return entity;
            //var entry = context.Entry(entity) ?? context.Set<T>().Add(entity);
            //if (model.IsNew) return entity;
            //else
            //{
            //    entry.State = EntityState.Modified;
            //    return entity;
            //}
        }
        public static Person Map(PersonM src, RevisorContext context)
        {
            var person = InsertOrUpdate(new Person
            {
                Id = src.Id,
                Name = src.Name,
                SourceId = src.SourceId,
                Age = src.Age,
                SosialStatus = src.SosialStatus.Convert(x => Map(x, context)),
                Inviter = src.Inviter.Convert(x => Map(x, context)),
                InvitePlace = src.InvitePlace.Convert(x => Map(x, context)),
                InviteDate = src.InviteDate.ToDate(),
                Papers = src.Papers.Changed().ForEachConvert(x => Map(x, context)).ToList(),
                Books = src.Books.Changed().ForEachConvert(x => Map(x, context)).ToList(),
                Subscribes = src.Subscribes.Changed().ForEachConvert(x => Map(x, context)).ToList(),
                OrgState = src.OrgState.Convert(x => Map(x, context)),
                PhoneNumber = src.PhoneNumber,
                Description = src.Description,
                IsRoom = src.IsRoom,
                WorkType = src.WorkType.Convert(x => Map(x, context)),
                CallDate = src.CallDate.ToDate(),
                MeetDate = src.MeetDate.ToDate(),
                MeetPerson = src.MeetPerson.Convert(x => Map(x, context)),
                Address = src.Address.Convert(x => Map(x, context)),
                Room = src.Room,
                Floor = src.Floor,
                Porch = src.Porch,
                //Calls
                //Events
            }
            .Transform(p => p.Calls = src.Calls.Changed().ForEachConvert(x => Map(x, context)).ToList())
            .Transform(p => p.Events = src.Events.Changed().ForEachConvert(x => Map(x, context)).ToList())
            .Transform(p => p.Contributions = src.Contributions.Changed().ForEachConvert(x => Map(x, context)).ToList())
            , src, context);
            return person;
            //if (src.Papers.RemovedCount > 0) person.Papers.Remove(src.Papers.Select(s => new Paper { Id = s.Id }));
        }

        private static OrgPerson Map(OrgPersonM src, RevisorContext context) => InsertOrUpdate(new OrgPerson() { Id = src.Id, ShortName = src.ShortName }, src, context);
        private static Place Map(PlaceM src, RevisorContext context) => InsertOrUpdate(new Place() { Id = src.Id, Name = src.Name }, src, context);
        private static OrgState Map(OrgStateM src, RevisorContext context) => InsertOrUpdate(new OrgState() { Id = src.Id, Name = src.Name }, src, context);
        private static WorkType Map(WorkTypeM src, RevisorContext context) => InsertOrUpdate(new WorkType() { Id = src.Id, Name = src.Name }, src, context);
        private static Address Map(AddressM src, RevisorContext context) => InsertOrUpdate(new Address() { Id = src.Id, Name = src.Name }, src, context);
        private static SosialStatus Map(SosialStatusM src, RevisorContext context) => InsertOrUpdate(new SosialStatus() { Id = src.Id, Name = src.Name }, src, context);
        private static Contribution Map(ContributionM src, RevisorContext context) =>
            InsertOrUpdate(new Contribution()
            {
                Id = src.Id,
                MeetPerson = src.MeetPerson.Convert(x => Map(x, context)),
                Description = src.Description,
                Month = src.Month.Convert(x => Map(x, context)),
            }
            .Transform(d => d.BookResults = src.BookResults.Changed().ForEachConvert(x => Map(x, context)).ToList())
            .Transform(d => d.SubscribeResults = src.SubscribeResults.Changed().ForEachConvert(x => Map(x, context)).ToList())
            .Transform(d => d.ValueResults = src.ValueResults.Changed().ForEachConvert(x => Map(x, context)).ToList())
            .Transform(d => d.PaperResults = src.PaperResults.Changed().ForEachConvert(x => Map(x, context)).ToList())
            , src, context);

        private static BookResult Map(BookResultM src, RevisorContext context)
        {
            return InsertOrUpdate(new BookResult()
            {
                Id = src.Id,
                Book = src.Book.Convert(x => Map(x, context)),
                Date = src.Date.ToDate(),
            }, src, context);
        }

        private static SubscribeResult Map(SubscribeResultM src, RevisorContext context)
        {
            return InsertOrUpdate(new SubscribeResult()
            {
                Id = src.Id,
                Subscribe = src.Subscribe.Convert(x => Map(x, context)),
                Date = src.Date.ToDate(),
                Value = src.Value,
            }, src, context);
        }
        //TODO решить проблемы как рекурсивных вычислений, так и повторных созданий фабрикой. Фабрика хранит коллекцию с Id, методы создания принимают флаг reload
        //TODO Но надо подумать как не выгружать дерево на каждый чих
        //TODO Возможно, имеет смысл вообще убить модель до уровня отображаемых примитивов + Id, и подргужать только в карточках. Но что делать с фильтрами? Фильтр по бд-структуре? Как вариант.
        private static ValueResult Map(ValueResultM src, RevisorContext context)
        {
            return InsertOrUpdate(new ValueResult()
            {
                Id = src.Id,
                Date = src.Date.ToDate(),
                Value = src.Value,
            }, src, context);
        }
        private static PaperResult Map(PaperResultM src, RevisorContext context)
        {
            return InsertOrUpdate(new PaperResult()
            {
                Id = src.Id,
                Date = src.Date.ToDate(),
                Paper = src.Paper.Convert(x => Map(x, context)),
            }, src, context);
        }
        private static Month Map(MonthM src, RevisorContext context)
        {
            return InsertOrUpdate(new Month()
            {
                Id = src.Id,
                Name = src.Name,
                DateFinish = src.DateFinish.ToDate(),
                DateStart = src.DateStart.ToDate(),
            }, src, context);
        }

        private static Book Map(BookM src, RevisorContext context)
        {
            return InsertOrUpdate(new Book()
            {
                Id = src.Id,
                Name = src.Name,
                Description = src.Description,
                Price = src.Price,
                ShortName = src.ShortName,
            }, src, context);
        }
        private static Subscribe Map(SubscribeM src, RevisorContext context)
        {
            return InsertOrUpdate(new Subscribe()
            {
                Id = src.Id,
                Name = src.Name,
            }, src, context);
        }
        private static Paper Map(PaperM src, RevisorContext context)
        {
            return InsertOrUpdate(new Paper()
            {
                Id = src.Id,
                Name = src.Name,
                Number = src.Number,
            }, src, context);
        }


        private static CallEventResult Map(CallEventResultM src, RevisorContext context) =>
            InsertOrUpdate(new CallEventResult()
            {
                Id = src.Id,
                Caller = src.Caller.Convert(x => Map(x, context)),
                CallEvent = src.CallEvent.Convert(x => Map(x, context)),
            }
            .Transform(d => d.CallTargetResults = src.CallTargetResults.Changed().ForEachConvert(x => Map(x, context)).ToList())
            , src, context);

        private static CallEvent Map(CallEventM src, RevisorContext context) =>
            InsertOrUpdate(new CallEvent()
            {
                Id = src.Id,
                CallDate = src.CallDate.ToDate(),
                //TODO
            }, src, context);
        private static CallTargetResult Map(CallTargetResultM src, RevisorContext context) =>
            InsertOrUpdate(new CallTargetResult()
            {
                Id = src.Id,
                CallResultType = src.CallResultType.Convert(x => Map(x, context)),
                Target = src.Target.Convert(x => Map(x, context)),
            }, src, context);
        private static CallResultType Map(CallResultTypeM src, RevisorContext context) =>
            InsertOrUpdate(new CallResultType()
            {
                Id = src.Id,
                Name = src.Name,
            }, src, context);
        private static Event Map(EventM src, RevisorContext context) =>
            InsertOrUpdate(new Event()
            {
                Id = src.Id,
                CallDate = src.CallDate.ToDate(),
                EventType = src.EventType.Convert(x => Map(x, context)),
                //TODO
            }, src, context);
        private static EventType Map(EventTypeM src, RevisorContext context) => InsertOrUpdate(new EventType()
        {
            Name = src.Name,
        }, src, context);


        private static PersonEventResult Map(PersonEventResultM src, RevisorContext context) =>
            InsertOrUpdate(new PersonEventResult()
            {
                Id = src.Id,
                Event = src.Event.Convert(x => Map(x, context)),
                EventRole = src.EventRole.Convert(x => Map(x, context)),
                EventResultType = src.EventResultType.Convert(x => Map(x, context)),
            }, src, context);
        private static EventResultType Map(EventResultTypeM src, RevisorContext context) => InsertOrUpdate(new EventResultType()
        {
            Id = src.Id,
            Name = src.Name,
        }, src, context);

        private static EventRole Map(EventRoleM src, RevisorContext context) =>
        InsertOrUpdate(new EventRole() 
        {
            Id = src.Id,
            Name = src.Name,
        }, src, context);
    }
}
