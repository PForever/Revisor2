using System;
using System.ComponentModel.DataAnnotations;

namespace Revisor2.Model
{
    public class RoomPerson
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string SosialStatus { get; set; }
        public string Inviter { get; set; }
        public string IvitePlace { get; set; }
        public DateTime? InviteDate  { get; set; }
        public int? PaperCount { get; set; }
        public int? LastPaper { get; set; }
        public int? LastСontribution { get; set; }
        public string OrgState  { get; set; }
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
        public string Address { get; set; }
        public int? Room { get; set; }
        public int? Floor { get; set; }
        public string Porch { get; set; }
    }
}