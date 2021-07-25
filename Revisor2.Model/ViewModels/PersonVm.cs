using System;
using System.Collections.Generic;

namespace Revisor2.Model.ViewModels
{
    public class PersonVm : ViewModelBase<PersonVm, int>
    {
        public PersonVm(int id) : base(id) { }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string SosialStatus { get; set; }
        public string Inviter { get; set; }
        public string IvitePlace { get; set; }
        public DateTime? InviteDate { get; set; }
        public int? PaperCount { get; set; }
        public int? LastPaper { get; set; }
        public int? LastСontribution { get; set; }
        public string OrgState { get; set; }
        public long? PhoneNumber { get; set; }
        public string Discription { get; set; }
        public bool? IsRoom { get; set; }
        public string WorkType { get; set; }
        public DateTime? CallDate { get; set; }
        public DateTime? MeetDate { get; set; }
        public int? DisconnectsCount { get; set; }
        public int? CallsCount { get; set; }
        public string CallResult { get; set; }
        public string MeetPerson { get; set; }
        public AddressVm Address { get; set; }
        public int? Room { get; set; }
        public int? Floor { get; set; }
        public string Porch { get; set; }
        public ICollection<ContributionVm> Contributions { get; set; }

        public override string DisplayMember => Name;
    }
}
