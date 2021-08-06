using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Data
{
    public class Month
    {
        public Guid Id { get; set; }
        public string Name {  get; init; }
        public DateOnly DateStart { get; init; }
        public DateOnly DateFinish { get; init; }
    }
}