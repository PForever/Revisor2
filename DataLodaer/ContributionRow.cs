using System;
using System.ComponentModel;

namespace DataLodaer
{
    public class ContributionRow
    {
        public int Id { get; set; }
        [DisplayName("Человек")]
        public int RoomPersonId { get; set; }
        [DisplayName("Месячник")]
        public DateTime Month { get; set; }
        [DisplayName("Результат")]
        public string Result { get; set; }
        [DisplayName("Тип")]
        public string Type { get; set; }
        [DisplayName("Комментарий")]
        public string Description { get; set; }
    }
}
