using Revisor2.Model.Infrastructure;
using System;

namespace DataLodaer.SrcDtos
{
    public class MonthRow
    {
        public Guid Id { get; set; }
        public string Name {  get; init; }
        public DateTime DateStart { get; init; }
        public DateTime DateFinish { get; init; }
    }
}