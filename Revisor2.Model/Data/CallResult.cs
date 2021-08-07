using System;
using System.Collections.Generic;

namespace Revisor2.Model.Data
{
    public class CallResultType
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
    }
    public class EventResultType
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
    }
    public class CallEventResult
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid? CallEventId { get; set; }
        public CallEvent CallEvent { get; set; }
        public ICollection<CallTargetResult> CallTargetResults { get; set; }
        public Guid? CallerId { get; set; }
        public OrgPerson Caller { get; set; }
        string Description { get; set; }
    }

    public class CallTargetResult
    {
        public Guid Id { get; set; }
        public Guid CallEventResultId { get; set; }
        public CallEventResult CallEventResult { get; set; }
        public Guid? TargetId { get; set; }
        public Event Target { get; set; }
        public Guid CallResultTypeId { get; set; }
        public CallResultType CallResultType { get; set; }
    }

    public class PersonEventResult
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public Guid EventRoleId { get; set; }
        public EventRole EventRole { get; set; }
        public Guid EventResultTypeId { get; set; }
        public EventResultType EventResultType { get; set; }
        string Description { get; set; }
    }
    public class OrgPersonEventResult
    {
        public Guid Id { get; set; }
        public Guid OrgPersonId { get; set; }
        public OrgPerson OrgPerson { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public Guid EventRoleId { get; set; }
        public EventRole EventRole { get; set; }
        public TimeOnly? Time { get; set; }
        string Description { get; set; }
    }
    public class CallEvent
    {
        public Guid Id { get; set; }
        public DateOnly CallDate { get; set; }
        public ICollection<OrgPersonEventResult> OrgPeopleResults { get; set; }
        public ICollection<CallEventResult> Results { get; set; }
    }
    public class Event
    {
        public Guid Id { get; set; }
        public DateOnly CallDate { get; set; }
        public Guid EventTypeId { get; set; }
        public EventType EventType { get; set; }
        public ICollection<OrgPersonEventResult> OrgPeopleResults { get; set; }
        public ICollection<PersonEventResult> Results { get; set; }
    }
    public class EventRole
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class EventType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}