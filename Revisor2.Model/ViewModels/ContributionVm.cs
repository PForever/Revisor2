using System;

namespace Revisor2.Model.ViewModels
{
    public class ContributionVm
    {
        public int Id { get; set; }
        public int RoomPersonId { get; set; }
        public DateTime Month { get; set; }
        public string Result { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
