using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class BookM : DomainModelBase<BookM, Guid>
    {
        public BookM() { }
        public BookM(Guid id) : base(id) { }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public override string DisplayMember => Name;
    }
}
