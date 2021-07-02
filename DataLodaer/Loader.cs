using Mapster;
using OfficeOpenXml;
using Revisor2.Model;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataLodaer
{
    public static class Loader
    {
        static Loader()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            TypeAdapterConfig<RoomPersonRow, RoomPerson>.NewConfig().Map(dest => dest.IsRoom, src => !string.IsNullOrEmpty(src.IsRoom)).Compile();
        }

        public static void UploadRoomPerson(string path)
        {
            var list = GetRoomPersonRowsFromExcel(path);
            var restult = list.Select(r => r.Adapt<RoomPerson>()).ToList();
            using var context = new RevisorContext();
            var ids = context.RoomPeople.Select(r => r.Id).ToHashSet();
            foreach (var r in restult) _ = ids.Contains(r.Id) ? context.RoomPeople.Update(r) : context.RoomPeople.Add(r);
            context.SaveChanges();
        }
        public static void UploadContributions(string path)
        {
            var list = GetContributionRowsFromExcel(path);
            var restult = list.Select(r => r.Adapt<Contribution>()).ToList();
            using var context = new RevisorContext();
            var ids = context.Contributions.Select(r => r.Id).ToHashSet();
            foreach (var r in restult) _ = ids.Contains(r.Id) ? context.Contributions.Update(r) : context.Contributions.Add(r);
            context.SaveChanges();
        }

        private static ICollection<RoomPersonRow> GetRoomPersonRowsFromExcel(string path)
        {
            var file = new FileInfo(path);
            //var file = new FileInfo(@"C:\Users\igor_\OneDrive\Рабочий стол\Seed\Revisor.xlsx");
            using var exelPackage = new ExcelPackage(file);
            return exelPackage.Workbook.Worksheets["Люди"].GetTable<RoomPersonRow>().ToList();
        }
        private static ICollection<ContributionRow> GetContributionRowsFromExcel(string path)
        {
            var file = new FileInfo(path);
            using var exelPackage = new ExcelPackage(file);
            return exelPackage.Workbook.Worksheets["Взносы"].GetTable<ContributionRow>().ToList();
        }
    }
}
