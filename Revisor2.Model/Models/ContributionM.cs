using Revisor2.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Revisor2.Model.Models
{
    public class ContributionM : DomainModelBase<ContributionM, Guid>
    {
        public ContributionM() 
        {
        }
        public ContributionM(Guid id, OrgPersonM meetPerson, MonthM month, string description) : base(id)
        {
            _MeetPerson = meetPerson;
            _Month = month;
            _Description = description;
        }
        public PersonM Person { get; set; }
        private OrgPersonM _MeetPerson;
        public OrgPersonM MeetPerson { get => _MeetPerson; set => SetVm(ref _MeetPerson, value); }
        private MonthM _Month;
        public MonthM Month { get => _Month; set => SetVm(ref _Month, value); }
        public DomainModelCollection<ValueResultM, ContributionM> ValueResults { get; set; }
        public DomainModelCollection<BookResultM, ContributionM> BookResults { get; set; }
        public DomainModelCollection<PaperResultM, ContributionM> PaperResults { get; set; }
        public DomainModelCollection<SubscribeResultM, ContributionM> SubscribeResults { get; set; }
        private string _Description;
        public string Description { get => _Description; set => Set(ref _Description, value); }
        public override string DisplayMember => $"{Month} {ValueResults?.Select(r => r.Value).DefaultIfEmpty().Sum()}";
    }
}
