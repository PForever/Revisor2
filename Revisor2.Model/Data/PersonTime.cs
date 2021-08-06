using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Data
{
    public class PersonTime
    {
        public Guid Id { get; set; }
        public Guid OrgPersonId { get; }
        public OrgPerson OrgPerson { get; }
        public TimeOnly Start { get; }
        public TimeOnly Finish { get; }
    }
}