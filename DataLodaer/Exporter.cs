using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Revisor2.Model;
using Revisor2.Model.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SystemHelpers;

namespace DataLodaer
{
    public static class Exporter
    {
        public static void ExportToRoomTable()
        {
            var currentMonth = new DateTime(2021, 5, 1);
            var list = GetRowsFromDb(currentMonth, "Менделеева 3").ToList();

            var file = new FileInfo(@"D:\Downloads\Export.xlsx");
            using var exelPackage = new ExcelPackage();
            var workSheet = exelPackage.Workbook.Worksheets.Add("Address");
            var cardBuilder = new ExcelAddressCardBuilder(workSheet);
            list.ForEach(l => PrintAddresTable(l.Key, l, cardBuilder, currentMonth));
            exelPackage.SaveAs(file);
        }
        public static void ExportToRoomTable(string downloadPath, DateTime currentMonth, IList<int> ids)
        {
            var list = GetRowsFromDb(currentMonth, ids).ToList();
            var path = Path.Combine(downloadPath, $"Export{DateTime.Now:yyyy.MM.dd HH-mm-ss}.xlsx");
            Directory.CreateDirectory(downloadPath);
            var file = new FileInfo(path);
            using var exelPackage = new ExcelPackage();
            var workSheet = exelPackage.Workbook.Worksheets.Add("Address");
            var cardBuilder = new ExcelAddressCardBuilder(workSheet);
            list.ForEach(l => PrintAddresTable(l.Key, l, cardBuilder, currentMonth));
            SetPrintSettings(exelPackage.Workbook.Worksheets[0]);
            exelPackage.SaveAs(file);
            OpenExcel(path);
        }

        private static void OpenExcel(string path)
        {
            var info = new ProcessStartInfo(path) { UseShellExecute = true };
            Process.Start(info);
        }

        private static void SetPrintSettings(ExcelWorksheet worksheet)
        {
            worksheet.PrinterSettings.PaperSize = ePaperSize.A4;
            worksheet.PrinterSettings.Orientation = eOrientation.Landscape;
            worksheet.PrinterSettings.HorizontalCentered = true;
            worksheet.PrinterSettings.FitToPage = true;
            worksheet.PrinterSettings.FitToWidth = 1;
            worksheet.PrinterSettings.FitToHeight = 0;
            worksheet.PrinterSettings.ShowGridLines = true;
        }

        static Exporter()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        private static void PrintAddresTable(string address, IEnumerable<PersonInRooms> people, ExcelAddressCardBuilder cardBuilder, DateTime currentMonth)
        {
            cardBuilder.AddAddress(address);
            cardBuilder.AddHeaders(currentMonth);
            people.OrderBy(p => p.Porch).ThenByDescending(p => p.Room).ForEach(p => cardBuilder.AddPerson(p));
            cardBuilder.MergeEquals();
        }

        private static IEnumerable<IGrouping<string, PersonInRooms>> GetRowsFromDb(DateTime currentMonth, IList<int> ids)
        {
            var month1 = currentMonth.AddMonths(-7);
            var month2 = currentMonth.AddMonths(-6);
            var month3 = currentMonth.AddMonths(-5);
            var month4 = currentMonth.AddMonths(-4);
            var month5 = currentMonth.AddMonths(-3);
            var month6 = currentMonth.AddMonths(-2);
            var month7 = currentMonth.AddMonths(-1);
            var month8 = currentMonth;
            using var context = new RevisorContext();
            var peoples = (from person in context.RoomPeople/*.Include(p => p.Contributions)*/
                           where ids.Contains(person.Id)
                           select person).ToList();
            var list = from p in peoples
                       let pir = new PersonInRooms
                       {
                           Address = p.Address,
                           Floor = p.Floor,
                           Room = p.Room,
                           Porch = p.Porch,
                           Name = p.Name,
                           Age = p.Age,
                           SosialStatus = p.SosialStatus,
                           Inviter = p.Inviter,
                           //Contribution1 = p.Contributions.Where(c => c.Month == month1).Select(c => c.Result).FirstOrDefault(),
                           //Contribution2 = p.Contributions.Where(c => c.Month == month2).Select(c => c.Result).FirstOrDefault(),
                           //Contribution3 = p.Contributions.Where(c => c.Month == month3).Select(c => c.Result).FirstOrDefault(),
                           //Contribution4 = p.Contributions.Where(c => c.Month == month4).Select(c => c.Result).FirstOrDefault(),
                           //Contribution5 = p.Contributions.Where(c => c.Month == month5).Select(c => c.Result).FirstOrDefault(),
                           //Contribution6 = p.Contributions.Where(c => c.Month == month6).Select(c => c.Result).FirstOrDefault(),
                           //Contribution7 = p.Contributions.Where(c => c.Month == month7).Select(c => c.Result).FirstOrDefault(),
                           //Contribution8 = p.Contributions.Where(c => c.Month == month8).Select(c => c.Result).FirstOrDefault(),
                           PhoneNumber = p.PhoneNumber,
                           LastPaper = p.LastPaper,
                           Description = p.Description,
                       }
                       group pir by p.Address;
            return list;
        }

        private static IEnumerable<IGrouping<string, PersonInRooms>> GetRowsFromDb(DateTime currentMonth, params string[] addresses)
        {
            var month1 = currentMonth.AddMonths(-7);
            var month2 = currentMonth.AddMonths(-6);
            var month3 = currentMonth.AddMonths(-5);
            var month4 = currentMonth.AddMonths(-4);
            var month5 = currentMonth.AddMonths(-3);
            var month6 = currentMonth.AddMonths(-2);
            var month7 = currentMonth.AddMonths(-1);
            var month8 = currentMonth;
            using var context = new RevisorContext();
            var peoples = (from person in context.RoomPeople/*.Include(p => p.Contributions)*/
                           where addresses.Contains(person.Address)
                           select person).ToList();
            var list = from p in peoples
                       let pir = new PersonInRooms
                       {
                           Address = p.Address,
                           Floor = p.Floor,
                           Room = p.Room,
                           Porch = p.Porch,
                           Name = p.Name,
                           Age = p.Age,
                           SosialStatus = p.SosialStatus,
                           Inviter = p.Inviter,
                           //Contribution1 = p.Contributions.Where(c => c.Month == month1).Select(c => c.Result).FirstOrDefault(),
                           //Contribution2 = p.Contributions.Where(c => c.Month == month2).Select(c => c.Result).FirstOrDefault(),
                           //Contribution3 = p.Contributions.Where(c => c.Month == month3).Select(c => c.Result).FirstOrDefault(),
                           //Contribution4 = p.Contributions.Where(c => c.Month == month4).Select(c => c.Result).FirstOrDefault(),
                           //Contribution5 = p.Contributions.Where(c => c.Month == month5).Select(c => c.Result).FirstOrDefault(),
                           //Contribution6 = p.Contributions.Where(c => c.Month == month6).Select(c => c.Result).FirstOrDefault(),
                           //Contribution7 = p.Contributions.Where(c => c.Month == month7).Select(c => c.Result).FirstOrDefault(),
                           //Contribution8 = p.Contributions.Where(c => c.Month == month8).Select(c => c.Result).FirstOrDefault(),
                           PhoneNumber = p.PhoneNumber,
                           LastPaper = p.LastPaper,
                           Description = p.Description,
                       } group pir by p.Address;
            return list;
        }
    }
}
