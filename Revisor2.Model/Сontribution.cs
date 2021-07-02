using System;
using System.ComponentModel.DataAnnotations;

namespace Revisor2.Model
{
    public class Contribution
    {
        [Key]
        public int Id { get; set; }
        public RoomPerson RoomPerson { get; set; }
        public int RoomPersonId { get; set; }
        public DateTime Month { get; set; }
        public string Result { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}