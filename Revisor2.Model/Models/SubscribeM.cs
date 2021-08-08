using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class SubscribeM : DomainModelBase<SubscribeM, Guid>
    {
        public SubscribeM() { }
        public SubscribeM(Guid id, string name, int value) : base(id)
        {
            _value = value;
            _Name = name;
        }
        private string _Name;
        private int _value;

        public string Name { get => _Name; set => Set(ref _Name, value); }
        public int Value { get => _value; set => Set(ref _value, value); }
        public override string DisplayMember => Name;
    }
}
