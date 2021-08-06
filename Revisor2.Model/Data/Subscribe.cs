using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Data
{
    public class Subscribe
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public string Name { get; set; }
    }
}
