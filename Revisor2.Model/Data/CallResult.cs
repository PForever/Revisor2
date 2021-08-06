using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Data
{
    public class CallResultType
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
    }
    public class CallResult
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid? CallIventId { get; set; }
        public Event CallIvent { get; set; }
        public Guid CallResultTypeId { get; set; }
        public CallResultType CallResultType { get; set; }
    }
    public class Event
    {
        public Guid Id { get; set; }
        public DateOnly CallDate { get; set; }
        public Guid EventTypeId { get; set; }
        public EventType EventType { get; set; }
        public Guid EventRoleId { get; set; }
        public EventRole EventRole { get; set; }
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