using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Data
{
    public class Porch
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
        public int? OrderNumber { get; init; }
        public int? FirstRoom { get; init; }
        public int? LastRoom { get; init; }
        public int? Floor { get; init; }
    }
}
