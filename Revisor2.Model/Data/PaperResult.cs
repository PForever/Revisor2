using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Data
{
    public class PaperResult
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public Guid ContributionId { get; init; }
        public Contribution Contribution { get; init; }
        public Guid PaperId { get; set; }
        public Paper Paper { get; set; }
    }
}
