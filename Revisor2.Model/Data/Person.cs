using Revisor2.Model.Infrastructure;
using Revisor2.Model.Models;
using System;
using System.Collections.Generic;
using SystemHelpers;

namespace Revisor2.Model.Data
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? SourceId { get; set; }
        public RoomPerson Source { get; set; }
        public int? Age { get; set; }
        public Guid? SosialStatusId { get; set; }
        public SosialStatus SosialStatus { get; set; }
        public int InviterId { get; set; }
        public OrgPerson Inviter { get; set; }
        public Place InvitePlace { get; set; }
        public DateOnly? InviteDate { get; set; }
        public ICollection<Paper> Papers { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<Subscribe> Subscribes { get; set; }
        public ICollection<Contribution> Contributions { get; set; }
        public string OrgState { get; set; }
        public long? PhoneNumber { get; set; }
        public string Discription { get; set; }
        public bool IsRoom { get; set; }
        public string WorkType { get; set; }
        public DateOnly? CallDate { get; set; }
        public DateOnly? MeetDate { get; set; }
        public int DisconnectsCount { get; set; }
        public int CallsCount { get; set; }
        public string CallResult { get; set; }
        public string MeetPerson { get; set; }
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }
        public int? Room { get; set; }
        public int? Floor { get; set; }
        public string Porch { get; set; }
    }
}
