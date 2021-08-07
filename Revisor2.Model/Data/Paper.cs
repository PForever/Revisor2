using Revisor2.Model.Infrastructure;
using System;
using System.Collections.Generic;

namespace Revisor2.Model.Data
{
    public class Paper
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
        public int Number { get; init; }
        public ICollection<Person> People { get; set; }
    }
}