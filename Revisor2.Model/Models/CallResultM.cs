using Revisor2.Model.Infrastructure;
using System;
using System.Collections.Generic;

namespace Revisor2.Model.Models
{
    public class CallResultTypeM : DomainModelBase<CallResultTypeM, Guid>
    {
        public CallResultTypeM(Guid id) : base(id) { }
        public string Name { get; init; }
        public override string DisplayMember => Name;
    }
    public class EventResultTypeM : DomainModelBase<EventResultTypeM, Guid>
    {
        public EventResultTypeM(Guid id) : base(id) { }
        public string Name { get; init; }
        public override string DisplayMember => Name;
    }
    public class CallEventResultM : DomainModelBase<CallEventResultM, Guid>
    {
        public CallEventResultM(Guid id) : base(id) { }
        public PersonM Person { get; set; }
        public CallEventM CallEvent { get; set; }
        public ICollection<CallTargetResultM> CallTargetResults { get; set; }
        public OrgPersonM Caller { get; set; }
        string Description { get; set; }
        public override string DisplayMember => $"{Person.DisplayMember}: {CallEvent.DisplayMember}";
    }

    public class CallTargetResultM : DomainModelBase<CallTargetResultM, Guid>
    {
        public CallEventResultM CallEventResult { get; set; }
        public CallTargetResultM(Guid id) : base(id) { }
        public EventM Target { get; set; }
        public CallResultTypeM CallResultType { get; set; }
        public override string DisplayMember => $"{CallEventResult.Person.DisplayMember}: {Target.DisplayMember} - {CallResultType.DisplayMember}";
    }

    public class PersonEventResultM : DomainModelBase<PersonEventResultM, Guid>
    {
        public PersonEventResultM(Guid id) : base(id) { }
        public PersonM Person { get; set; }
        public EventM Event { get; set; }
        public EventRoleM EventRole { get; set; }
        public EventResultTypeM EventResultType { get; set; }
        string Description { get; set; }
        public override string DisplayMember => $"{Person.DisplayMember}: {Event.DisplayMember} - {EventResultType.DisplayMember})";
    }
    public class OrgPersonEventResultM : DomainModelBase<OrgPersonEventResultM, Guid>
    {
        public OrgPersonEventResultM(Guid id) : base(id) { }
        public OrgPersonM OrgPerson { get; set; }
        public EventM Event { get; set; }
        public EventRoleM EventRole { get; set; }
        public TimeOnly? Time { get; set; }
        string Description { get; set; }
        public override string DisplayMember => $"{OrgPerson.DisplayMember}: {Event.DisplayMember} - {Time})";
    }
    public class CallEventM : DomainModelBase<CallEventM, Guid>
    {
        public CallEventM(Guid id) : base(id) { }
        public DateOnly CallDate { get; set; }
        public ICollection<OrgPersonEventResultM> OrgPeopleResults { get; set; }
        public ICollection<CallEventResultM> Results { get; set; }
        public override string DisplayMember => $"Обзвон ({CallDate})";
    }
    public class EventM : DomainModelBase<EventM, Guid>
    {
        public EventM(Guid id) : base(id) { }
        public DateOnly CallDate { get; set; }
        public EventTypeM EventType { get; set; }
        public ICollection<OrgPersonEventResultM> OrgPeopleResults { get; set; }
        public ICollection<PersonEventResultM> Results { get; set; }
        public override string DisplayMember => $"{EventType.DisplayMember} ({CallDate})";
    }
    public class EventRoleM : DomainModelBase<EventRoleM, Guid>
    {
        public EventRoleM(Guid id) : base(id) { }
        public string Name { get; set; }
        public override string DisplayMember => Name;
    }
    public class EventTypeM : DomainModelBase<EventTypeM, Guid>
    {
        public EventTypeM(Guid id) : base(id) { }
        public string Name { get; set; }
        public override string DisplayMember => Name;
    }
}