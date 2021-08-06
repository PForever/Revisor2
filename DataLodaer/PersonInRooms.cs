using System.ComponentModel;

namespace DataLodaer
{
    internal class PersonInRooms
    {
        [DisplayName("Адрес")]
        public string Address { get; set; }
        [DisplayName("Подъезд")]
        public string Porch { get; set; }
        [DisplayName("Квартира")]
        public int? Room { get; set; }
        [DisplayName("Этаж")]
        public int? Floor { get; set; }
        

        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Возраст")]
        public int? Age { get; set; }
        [DisplayName("Социальное положение")]
        public string SosialStatus { get; set; }
        [DisplayName("Кто взял")]
        public string Inviter { get; set; }

        public string Contribution1 { get; set; }
        public string Contribution2 { get; set; }
        public string Contribution3 { get; set; }
        public string Contribution4 { get; set; }
        public string Contribution5 { get; set; }
        public string Contribution6 { get; set; }
        public string Contribution7 { get; set; }
        public string Contribution8 { get; set; }

        [DisplayName("Номер телефона")]
        public long? PhoneNumber { get; set; }
        [DisplayName("Газета")]
        public int? LastPaper { get; set; }
        [DisplayName("Комментарий")]
        public string Description { get; set; }
        
    }
}