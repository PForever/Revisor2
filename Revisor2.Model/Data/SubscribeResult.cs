using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Data
{
    public class SubscribeResult
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public Guid ContributionId { get; init; }
        public Contribution Contribution { get; init; }
        public Guid SubscribeId { get; init; }
        public Subscribe Subscribe { get; init; }
        public int Value { get; set; }
    }
}
