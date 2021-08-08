using Revisor2.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Revisor2.Model.Models
{
    public class CallResultTypeM : DomainModelBase<CallResultTypeM, Guid>
    {
        public CallResultTypeM() { }
        public CallResultTypeM(Guid id, string name) : base(id)
        {
            _Name = name;
        }
        private string _Name;
        public string Name { get => _Name; set => Set(ref _Name, value); }
        public override string DisplayMember => Name;
    }
    public class EventResultTypeM : DomainModelBase<EventResultTypeM, Guid>
    {
        public EventResultTypeM() { }
        public EventResultTypeM(Guid id, string name) : base(id)
        {
            _Name = name;
        }
        private string _Name;
        public string Name { get => _Name; set => Set(ref _Name, value); }
        public override string DisplayMember => Name;
    }
    public class CallEventResultM : DomainModelBase<CallEventResultM, Guid>
    {
        public CallEventResultM() { }
        public CallEventResultM(Guid id, CallEventM callEvent, OrgPersonM caller, string description) : base(id)
        {
            _CallEvent = callEvent;
            _Caller = caller;
            Description = description;
        }
        public PersonM Person { get; set; }
        private CallEventM _CallEvent;
        public CallEventM CallEvent { get => _CallEvent; set => SetVm(ref _CallEvent, value); }
        public DomainModelCollection<CallTargetResultM, CallEventResultM> CallTargetResults { get; set; }
        private OrgPersonM _Caller;
        public OrgPersonM Caller { get => _Caller; set => SetVm(ref _Caller, value); }
        public string Description { get; set; }
        public override string DisplayMember => $"{string.Join(", ", CallTargetResults?.Select(r => $"{r.Target?.DisplayMember ?? ""} {r.CallResultType.DisplayMember}"))}";
    }

    public class CallTargetResultM : DomainModelBase<CallTargetResultM, Guid>
    {
        public CallTargetResultM() { }
        public CallTargetResultM(Guid id, EventM target, CallResultTypeM callResultType) : base(id)
        {
            _Target = target;
            _CallResultType = callResultType;
        }
        public CallEventResultM CallEventResult { get; set; }
        private EventM _Target;
        public EventM Target { get => _Target; set => SetVm(ref _Target, value); }
        private CallResultTypeM _CallResultType;
        public CallResultTypeM CallResultType { get => _CallResultType; set => SetVm(ref _CallResultType, value); }
        public override string DisplayMember => $"{CallEventResult.Person.DisplayMember}: {Target.DisplayMember} - {CallResultType.DisplayMember}";
    }

    public class PersonEventResultM : DomainModelBase<PersonEventResultM, Guid>
    {
        public PersonEventResultM() { }
        public PersonEventResultM(Guid id, EventM @event, EventRoleM eventRole, EventResultTypeM eventResultType, string description) : base(id)
        {
            _Event = @event;
            _EventResultType = eventResultType;
            _description = description;
            _EventRole = eventRole;
        }
        public PersonM Person { get; set; }
        private EventM _Event;
        public EventM Event { get => _Event; set => SetVm(ref _Event, value); }
        private EventRoleM _EventRole;
        public EventRoleM EventRole { get => _EventRole; set => SetVm(ref _EventRole, value); }
        private EventResultTypeM _EventResultType;
        private string _description;

        public EventResultTypeM EventResultType { get => _EventResultType; set => SetVm(ref _EventResultType, value); }
        public string Description { get => _description; set => Set(ref _description, value); }
        public override string DisplayMember => $"{Person.DisplayMember}: {Event.DisplayMember} - {EventResultType.DisplayMember})";
    }
    public class OrgPersonEventResultM : DomainModelBase<OrgPersonEventResultM, Guid>
    {
        public OrgPersonEventResultM() { }
        public OrgPersonEventResultM(Guid id, EventM @event, EventRoleM eventRole, TimeOnly? time, string description) : base(id)
        {
            _Event = @event;
            _EventRole = eventRole;
            _Time = time;
            _description = description;
        }
        public OrgPersonM OrgPerson { get; set; }
        private EventM _Event;
        public EventM Event { get => _Event; set => SetVm(ref _Event, value); }
        private EventRoleM _EventRole;
        public EventRoleM EventRole { get => _EventRole; set => SetVm(ref _EventRole, value); }
        private TimeOnly? _Time;
        private string _description;

        public TimeOnly? Time { get => _Time; set => Set(ref _Time, value); }
        public string Description { get => _description; set => Set(ref _description, value); }
        public override string DisplayMember => $"{OrgPerson.DisplayMember}: {Event.DisplayMember} - {Time})";
    }
    public class CallEventM : DomainModelBase<CallEventM, Guid>
    {
        public CallEventM() { }
        public CallEventM(Guid id, DateTime callDate) : base(id)
        {
            _CallDate = callDate;
        }
        private DateTime _CallDate;
        public DateTime CallDate { get => _CallDate; set => Set(ref _CallDate, value); }
        public DomainModelCollection<OrgPersonEventResultM, CallEventM> OrgPeopleResults { get; set; }
        public DomainModelCollection<CallEventResultM, CallEventM> Results { get; set; }
        public override string DisplayMember => $"Обзвон ({CallDate})";
    }
    public class EventM : DomainModelBase<EventM, Guid>
    {
        public EventM() { }
        public EventM(Guid id, DateTime callDate, EventTypeM eventType) : base(id)
        {
            _CallDate = callDate;
            _EventType = eventType;
        }
        private DateTime _CallDate;
        public DateTime CallDate { get => _CallDate; set => Set(ref _CallDate, value); }
        private EventTypeM _EventType;
        public EventTypeM EventType { get => _EventType; set => SetVm(ref _EventType, value); }
        public DomainModelCollection<OrgPersonEventResultM, EventM> OrgPeopleResults { get; set; }
        public DomainModelCollection<PersonEventResultM, EventM> Results { get; set; }
        public override string DisplayMember => $"{EventType.DisplayMember} ({CallDate})";
    }
    public class EventRoleM : DomainModelBase<EventRoleM, Guid>
    {
        public EventRoleM() { }
        public EventRoleM(Guid id, string name) : base(id)
        {
            _Name = name;
        }
        private string _Name;
        public string Name { get => _Name; set => Set(ref _Name, value); }
        public override string DisplayMember => Name;
    }
    public class EventTypeM : DomainModelBase<EventTypeM, Guid>
    {
        public EventTypeM() { }
        public EventTypeM(Guid id, string name) : base(id)
        {
            _Name = name;
        }
        private string _Name;
        public string Name { get => _Name; set => Set(ref _Name, value); }
        public override string DisplayMember => Name;
    }
}