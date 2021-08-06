using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Data
{
    public class BookResult
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public Guid ContributionId { get; set; }
        public Contribution Contribution { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
