using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Data
{
    public class ValueResult
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public Guid ContributionId { get; init; }
        public Contribution Contribution { get; init; }
        public int Value { get; set; }
    }
}
