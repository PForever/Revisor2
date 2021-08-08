using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class PaperM : DomainModelBase<PaperM, Guid>
    {
        public PaperM() { }
        public PaperM(Guid id, string name, int number) : base(id)
        {
            _Name = name;
            _Number = number;
        }
        private string _Name;
        public string Name { get => _Name; set => Set(ref _Name, value); }
        private int _Number;
        public int Number { get => _Number; set => Set(ref _Number, value); }
        public override string DisplayMember => Number.ToString();
    }
}