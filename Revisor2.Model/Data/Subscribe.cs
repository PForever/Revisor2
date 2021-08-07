using Revisor2.Model.Infrastructure;
using System;
using System.Collections.Generic;

namespace Revisor2.Model.Data
{
    public class Subscribe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public ICollection<Person> People { get; set; }
    }
}
