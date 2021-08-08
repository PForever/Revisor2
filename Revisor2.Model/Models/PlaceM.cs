using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class PlaceM : DomainModelBase<PlaceM, Guid>
    {
        public PlaceM() { }
        public PlaceM(Guid id, string name) : base(id)
        {
            _Name = name;
        }
        private string _Name;
        public string Name { get => _Name; set => Set(ref _Name, value); }

        public override string DisplayMember => Name;
    }
}