using Revisor2.Model.Infrastructure;
using System;

namespace DataLodaer.SrcDtos
{
    public class BookRow
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
    }
}
