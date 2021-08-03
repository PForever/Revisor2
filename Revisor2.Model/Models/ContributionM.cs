using System;

namespace Revisor2.Model.Models
{
    public class ContributionM
    {
        public int Id { get; set; }
        public int RoomPersonId { get; set; }
        public DateTime Month { get; set; }
        public string Result { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
    public class ResultTypeVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
