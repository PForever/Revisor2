using DataLodaer;
using Revisor2.Model;
using System;

namespace Revisor2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Loader.Upload(@"C:\Users\igor_\OneDrive\Рабочий стол\Оргработа\Обзвон\Обзвон.xlsx");

            //using var context = new RevisorContext();
            //context.RoomPeople.Add(new RoomPerson
            //{
            //    Id = 1,
            //    Address = "sdfdf",
            //    Age = 12,
            //    CallDate = DateTime.Now,
            //    CallResult = "OK",
            //    CallsCount = 2,
            //    DisconnectsCount = 2,
            //    Discription = "sdsd",
            //    Floor = 34,
            //    InviteDate = DateTime.Now.AddDays(-1),
            //    Inviter = "ИГ",
            //    IsRoom = true,
            //    IvitePlace = "Мендеева",
            //    LastPaper = 74
            //});
            //context.SaveChanges();
        }
    }
}
