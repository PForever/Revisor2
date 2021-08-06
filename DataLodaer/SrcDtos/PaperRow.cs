using Revisor2.Model.Infrastructure;
using System;

namespace DataLodaer.SrcDtos
{
    public class PaperRow
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
        public int Number { get; init; }
    }
}