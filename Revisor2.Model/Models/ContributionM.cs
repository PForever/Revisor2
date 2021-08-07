using Revisor2.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Revisor2.Model.Models
{
    public class ContributionM : DomainModelBase<ContributionM, Guid>
    {
        public ContributionM() 
        {
        }
        public ContributionM(Guid id) : base(id) { }
        public PersonM Person { get; set; }
        public OrgPersonM MeetPerson { get; set; }
        public MonthM Month { get; set; }
        public DomainModelCollection<ValueResultM, ContributionM> ValueResults { get; set; }
        public DomainModelCollection<BookResultM, ContributionM> BookResults { get; set; }
        public DomainModelCollection<PaperResultM, ContributionM> PaperResults { get; set; }
        public DomainModelCollection<SubscribeResultM, ContributionM> SubscribeResults { get; set; }
        public string Description { get; set; }
        public override string DisplayMember => $"{Person.Name} - {Month.Name}";
    }
}
