using Revisor2.Model.Infrastructure;
using System;
using System.Collections.Generic;
using SystemHelpers;

namespace Revisor2.Model.Models
{
    public class PersonM : DomainModelBase<PersonM, Guid>
    {
        public PersonM() { }
        public PersonM(Guid id) : base(id) { }
        public string Name { get; set; }
        public int? SourceId { get; set; }
        public int? Age { get; set; }
        public SosialStatusM SosialStatus { get; set; }
        public OrgPersonM Inviter { get; set; }
        public PlaceM InvitePlace { get; set; }
        public DateOnly? InviteDate { get; set; }
        public ICollection<PaperM> Papers { get; set; }
        public ICollection<BookM> Books { get; set; }
        public ICollection<SubscribeM> Subscribes { get; set; }
        public ICollection<ContributionM> Contributions { get; set; }
        public ICollection<CallEventResultM> Calls { get; set; }
        public ICollection<PersonEventResultM> Events { get; set; }
        public OrgStateM OrgState { get; set; }
        public long? PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool IsRoom { get; set; }
        public WorkTypeM WorkType { get; set; }
        public DateOnly? CallDate { get; set; }
        public DateOnly? MeetDate { get; set; }
        public OrgPersonM MeetPerson { get; set; }
        public AddressM Address { get; set; }
        public int? Room { get; set; }
        public int? Floor { get; set; }
        public string Porch { get; set; }


        public int? DisconnectsCount { get; set; }
        public int? PaperCount { get; set; }
        public PaperM LastPaper { get; set; }
        public ContributionM LastСontribution { get; set; }
        public override string DisplayMember => Name;
    }
}
