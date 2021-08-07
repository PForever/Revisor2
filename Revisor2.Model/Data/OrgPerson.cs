using Revisor2.Model.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Revisor2.Model.Data
{
    public class OrgPerson
    {
        public Guid Id { get; set; }
        public Guid? PersonId { get; set; }
        //[ForeignKey(nameof(PersonId))]
        //[InverseProperty(nameof(Person.OrgPersonNavigation))]
        public Person Person { get; set; }
        public string Name { get; init; }
        public string ShortName { get; init; }
    }
}