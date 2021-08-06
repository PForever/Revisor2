using Revisor2.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Revisor2.Model.Data
{
    public class Address
    {
        public Guid Id { get; set; }
        public ICollection<Bypass> Bypasses { get; set; }
        public ICollection<Person> People { get; set; }
        public ICollection<Porch> Porches { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
