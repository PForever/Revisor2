using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class BookResultM : DomainModelBase<ValueResultM, Guid>
    {
        public BookResultM() { }
        public BookResultM(Guid id) : base(id) { }
        public DateOnly Date { get; set; }
        public ContributionM Contribution { get; set; }
        public BookM Book { get; set; }
        public override string DisplayMember => $"{Book.Name} - {Date}";
    }
}
