using DataLodaer.SrcDtos;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeOpenXml;
using Revisor2.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SystemHelpers;

namespace DataLodaer
{
    public static class Loader
    {
        static Loader()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            TypeAdapterConfig<RoomPersonRow, RoomPerson>.NewConfig().Map(dest => dest.IsRoom, src => !string.IsNullOrEmpty(src.IsRoom)).Compile();
            TypeAdapterConfig<DateTime, DateOnly>.NewConfig().MapWith(src => src.ToDate()).Compile();
        }

        public static void LoadPersonRoomToPerson()
        {
            Console.WriteLine($"Загрузка Person");
            using var context = new RevisorContext();
            var dtoList = context.RoomPeople.ToDictionary(a => a.Id);

            var addresses = context.Addresses.ToDictionary(a => a.Name, StringComparer.OrdinalIgnoreCase);
            var papers = context.Papers.ToDictionary(a => a.Number);
            var months = context.Months.ToDictionary(m => m.DateStart);
            var orgPeople = context.OrgPeople.ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);
            var orgStates = context.OrgStates.ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);
            var sosialStatus = context.SosialStatus.ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);
            var places = context.Places.ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);
            var callResultTypes = context.CallResultTypes.ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);
            var workTypes = context.WorkTypes.ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);

            var people = (from p in dtoList.Values
                          select new Person
                          {
                              Id = Guid.NewGuid(),
                              Address = addresses.GetValueOrDefault(p.Address),
                              Age = p.Age,
                              CallDate = p.CallDate.ToDate(),
                              CallsCount = p.CallsCount ?? default,
                              CallResults = callResultTypes.GetValueOrDefault(p.CallResult) is { } result ? new[] { new CallResult { Id = Guid.NewGuid(), CallResultType = result } } : default,
                              Description = p.Description,
                              DisconnectsCount = p.DisconnectsCount ?? default,
                              Floor = p.Floor,
                              InviteDate = p.InviteDate.ToDate(),
                              InvitePlace = places.GetValueOrDefault(p.IvitePlace),
                              Inviter = orgPeople.GetValueOrDefault(p.Inviter),
                              IsRoom = p.IsRoom ?? default,
                              MeetDate = p.MeetDate.ToDate(),
                              MeetPerson = orgPeople.GetValueOrDefault(p.MeetPerson),
                              Name = p.Name,
                              OrgState = orgStates.GetValueOrDefault(p.OrgState),
                              Papers = p.LastPaper is { } number ? new[] { papers.GetValueOrDefault(number) } : default,
                              Contributions = p.LastСontribution is { } value ? new[] { new Contribution { Id = Guid.NewGuid(),
                                                                                             ValueResults = new[] {  new ValueResult {Id = Guid.NewGuid(), Date = new DateOnly(2020, 1, 1), Value = value } },
                                                                                             Month = months[new DateOnly(2020, 1, 1)]
                                                                                            }} : default,
                              PhoneNumber = p.PhoneNumber,
                              Porch = p.Porch,
                              Room = p.Room,
                              SosialStatus = sosialStatus.GetValueOrDefault(p.SosialStatus),
                              Source = p,
                              WorkType = workTypes.GetValueOrDefault(p.WorkType),
                          }).ToList();
            context.People.AddRange(people);
            context.SaveChanges();
        }

        public static void UploadRoomPerson(string path)
        {
            Console.WriteLine($"Загрузка RoomPerson");
            var list = GetRoomPersonRowsFromExcel(path);
            var restult = list.Select(r => r.Adapt<RoomPerson>()).ToList();
            using var context = new RevisorContext();
            var ids = context.RoomPeople.ToDictionary(r => r.Id);
            foreach (var r in restult) _ = ids.ContainsKey(r.Id) ? r.Adapt(ids[r.Id]) : context.RoomPeople.Add(r).Entity;
            context.SaveChanges();
        }
        public static void UploadContributions(string path)
        {
            Console.WriteLine($"Загрузка Contributions");
            var list = GetContributionRowsFromExcel(path);
            var restult = list.Select(r => r.Adapt<Contribution>()).ToList();
            using var context = new RevisorContext();
            var ids = context.Contributions.ToDictionary(r => r.Id);
            foreach (var r in restult) _ = ids.ContainsKey(r.Id) ? r.Adapt(ids[r.Id]) : context.Contributions.Add(r).Entity;
            context.SaveChanges();
        }
        
        public static void Upload<T, TDst, TKey>(string path, Func<TDst, TKey> selector) where T : class, new() where TDst : class
        {
            Console.WriteLine($"Загрузка {typeof(TDst).Name}");
            var list = GetRowsFromExcel<T>(path);
            var restult = list.Select(r => r.Adapt<TDst>()).ToList();
            using var context = new RevisorContext();
            var set = context.Set<TDst>();
            var ids = set.ToDictionary(r => selector(r));
            foreach (var r in restult) _ = selector(r) is var key && ids.ContainsKey(key) ? r.Adapt(ids[key]) : set.Add(r).Entity;
            context.SaveChanges();
        }
        public static void UploadLists(string path)
        {
            UploadAddresses(path);
            UploadBooks(path);
            UploadPapers(path);
            UploadSubscribes(path);
            UploadMonths(path);
            UploadOrgPeople(path);
            UploadOrgStates(path);
            UploadSosialStatus(path);
            UploadPlaces(path);
            UploadCallResultTypes(path);
            UploadEventTypes(path);
            UploadEventRole(path);
        }

        public static void UploadSosialStatus(string path) => Upload<SosialStatusRow, SosialStatus, Guid>(path, r => r.Id);
        public static void UploadOrgStates(string path) => Upload<OrgStateRow, OrgState, Guid>(path, r => r.Id);
        public static void UploadOrgPeople(string path) => Upload<OrgPersonRow, OrgPerson, Guid>(path, r => r.Id);
        public static void UploadMonths(string path) => Upload<MonthRow, Month, Guid>(path, r => r.Id);
        public static void UploadSubscribes(string path) => Upload<SubscribeRow, Subscribe, Guid>(path, r => r.Id);
        public static void UploadPapers(string path) => Upload<PaperRow, Paper, Guid>(path, r => r.Id);
        public static void UploadBooks(string path) => Upload<BookRow, Book, Guid>(path, r => r.Id);
        public static void UploadAddresses(string path) => Upload<AddressRow, Address, Guid>(path, r => r.Id);
        public static void UploadPlaces(string path) => Upload<PlaceRow, Place, Guid>(path, r => r.Id);
        public static void UploadCallResultTypes(string path) => Upload<CallResultTypeRow, CallResultType, Guid>(path, r => r.Id);
        public static void UploadEventTypes(string path) => Upload<EventTypeRow, EventType, Guid>(path, r => r.Id);
        public static void UploadEventRole(string path) => Upload<EventRoleRow, EventRole, Guid>(path, r => r.Id);

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
        private static ICollection<T> GetRowsFromExcel<T>(string path) where T : class, new()
        {
            var file = new FileInfo(path);
            using var exelPackage = new ExcelPackage(file);
            return exelPackage.Workbook.Worksheets[typeof(T).Name[0..^3]].GetTable<T>().ToList();
        }
    }
}
