using Revisor2.Model.Infrastructure;
using System;
using System.Collections.Generic;

namespace Revisor2.Model.Data
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public ICollection<Person> People { get; set; }
    }
}
