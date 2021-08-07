using DataLodaer;
using Revisor2.Model;
using System;
using System.IO;

namespace Revisor2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var dbExelPath = @"L:\Обзвон BD.xlsx";
            var listExelPath = @"L:\Lists Db.xlsx";

            Loader.UploadAddresses(listExelPath);
            Loader.UploadBooks(listExelPath);
            Loader.UploadPapers(listExelPath);
            Loader.UploadSubscribes(listExelPath);
            Loader.UploadMonths(listExelPath);
            Loader.UploadOrgPeople(listExelPath);
            Loader.UploadOrgStates(listExelPath);
            Loader.UploadSosialStatus(listExelPath);
            Loader.UploadPlaces(listExelPath);
            Loader.UploadCallResultTypes(listExelPath);
            Loader.UploadEventTypes(listExelPath);
            Loader.UploadEventRoles(listExelPath);
            Loader.UploadEventResultTypes(listExelPath);
            Loader.UploadWorkTypes(listExelPath);

            Loader.UploadRoomPerson(dbExelPath);

            Loader.LoadPersonRoomToPerson();

            //Loader.UploadContributions(@"C:\Users\igor_\OneDrive\Рабочий стол\Оргработа\Обзвон\Обзвон.xlsx");
            //Exporter.ExportToRoomTable();
        }
    }
}
