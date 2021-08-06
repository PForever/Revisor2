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
        public string SosialStatus { get; set; }
        public string Inviter { get; set; }
        public string InvitePlace { get; set; }
        public DateOnly? InviteDate { get; set; }
        public int? PaperCount { get; set; }
        public int? LastPaper { get; set; }
        public int? LastСontribution { get; set; }
        public string OrgState { get; set; }
        public long? PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool IsRoom { get; set; }
        public WorkTypeM WorkType { get; set; }
        public DateOnly? CallDate { get; set; }
        public DateOnly? MeetDate { get; set; }
        public int DisconnectsCount { get; set; }
        public int CallsCount { get; set; }
        public string CallResult { get; set; }
        public string MeetPerson { get; set; }
        public AddressM Address { get; set; }
        public int? Room { get; set; }
        public int? Floor { get; set; }
        public string Porch { get; set; }
        public ViewModelCollection<ContributionM, PersonM> Contributions { get; set; }

        public override string DisplayMember => Name;
    }
}
