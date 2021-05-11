using System;
using System.ComponentModel;

namespace DataLodaer
{
    public class RoomPersonRow
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Возраст")]
        public int? Age { get; set; }
        [DisplayName("Социальное положение")]
        public string SosialStatus { get; set; }
        [DisplayName("Кто взял")]
        public string Inviter { get; set; }
        [DisplayName("Где взят")]
        public string IvitePlace { get; set; }
        [DisplayName("Когда взял")]
        public DateTime? InviteDate { get; set; }
        [DisplayName("газет")]
        public int? PaperCount { get; set; }
        [DisplayName("Газета")]
        public int? LastPaper { get; set; }
        [DisplayName("Взнос")]
        public int? LastСontribution { get; set; }
        [DisplayName("Связь с НП")]
        public string OrgState { get; set; }
        [DisplayName("Номер телефона")]
        public long? PhoneNumber { get; set; }
        [DisplayName("комментарии")]
        public string Discription { get; set; }
        [DisplayName("кв")]
        public string IsRoom { get; set; }
        [DisplayName("тип")]
        public string WorkType { get; set; }
        [DisplayName("Когда звонить")]
        public DateTime? CallDate { get; set; }
        [DisplayName("Когда встреча")]
        public DateTime? MeetDate { get; set; }
        [DisplayName("Неответов")]
        public int? DisconnectsCount { get; set; }
        [DisplayName("Звонков")]
        public int? CallsCount { get; set; }
        [DisplayName("Результат обзвона")]
        public string CallResult { get; set; }
        [DisplayName("Кто проводит")]
        public string MeetPerson { get; set; }
        [DisplayName("Адрес")]
        public string Address { get; set; }
        [DisplayName("Квартира")]
        public int? Room { get; set; }
        [DisplayName("Этаж")]
        public int? Floor { get; set; }
        [DisplayName("Подъезд")]
        public string Porch { get; set; }
    }
}
