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
        public PersonM MeetPerson { get; set; }
        public MonthM Month { get; set; }
        public ViewModelCollection<ValueResultM, ContributionM> ValueResults { get; set; }
        public ViewModelCollection<BookResultM, ContributionM> BookResults { get; set; }
        public ViewModelCollection<PaperResultM, ContributionM> PaperResults { get; set; }
        public ViewModelCollection<SubscribeM, ContributionM> Subscribes { get; set; }
        public string Description { get; set; }
        public override string DisplayMember => $"{Person.Name} - {Month.Name}";
    }
}
