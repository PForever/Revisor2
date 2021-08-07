using Revisor2.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Revisor2.Model.Data
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? SourceId { get; set; }
        [InverseProperty(nameof(OrgPerson.Person))]
        public virtual OrgPerson OrgPersonNavigation { get; set; }
        public RoomPerson Source { get; set; }
        public int? Age { get; set; }
        public Guid? SosialStatusId { get; set; }
        public SosialStatus SosialStatus { get; set; }
        public Guid? InviterId { get; set; }
        [ForeignKey(nameof(InviterId))]
        public OrgPerson Inviter { get; set; }
        public Guid? InvitePlaceId { get; set; }
        public Place InvitePlace { get; set; }
        public DateOnly? InviteDate { get; set; }
        public ICollection<Paper> Papers { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<Subscribe> Subscribes { get; set; }
        public ICollection<Contribution> Contributions { get; set; }
        public ICollection<CallEventResult> Calls { get; set; }
        public ICollection<PersonEventResult> Events { get; set; }
        public Guid? OrgStateId { get; set; }
        public OrgState OrgState { get; set; }
        public long? PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool IsRoom { get; set; }
        public Guid? WorkTypeId { get; set; }
        public WorkType WorkType { get; set; }
        public DateOnly? CallDate { get; set; }
        public DateOnly? MeetDate { get; set; }
        public Guid? MeetPersonId { get; set; }
        [ForeignKey(nameof(MeetPersonId))]
        public OrgPerson MeetPerson { get; set; }
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }
        public int? Room { get; set; }
        public int? Floor { get; set; }
        public string Porch { get; set; }
    }
}
