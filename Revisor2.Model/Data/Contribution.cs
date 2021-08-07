using System;
using System.Collections.Generic;

namespace Revisor2.Model.Data
{
    public class Contribution
    {
        public Guid Id { get; set; }

        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid? MeetPersonId { get; set; }
        public OrgPerson MeetPerson { get; set; }
        public Guid MonthId { get; set; }
        public Month Month { get; set; }
        public ICollection<ValueResult> ValueResults { get; set; }
        public ICollection<BookResult> BookResults { get; set; }
        public ICollection<PaperResult> PaperResults { get; set; }
        public ICollection<Subscribe> Subscribes { get; set; }
        public string Description { get; set; }
    }
}
