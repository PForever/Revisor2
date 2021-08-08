using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class BookM : DomainModelBase<BookM, Guid>
    {

        public BookM() { }

        public BookM(Guid id, string name, string shortName, string author, int price, int year, string description) : base(id)
        {
            _Name = name;
            _ShortName = shortName;
            _Author = author;
            _Price = price;
            _Year = year;
            _Description = description;
        }

        private string _Name;
        public string Name { get => _Name; set => Set(ref _Name, value); }
        private string _ShortName;
        public string ShortName { get => _ShortName; set => Set(ref _ShortName, value); }
        private string _Author;
        public string Author { get => _Author; set => Set(ref _Author, value); }
        private int _Price;
        public int Price { get => _Price; set => Set(ref _Price, value); }
        private string _ISBN;
        public string ISBN { get => _ISBN; set => Set(ref _ISBN, value); }
        private int _Year;
        public int Year { get => _Year; set => Set(ref _Year, value); }
        private string _Description;
        public string Description { get => _Description; set => Set(ref _Description, value); }
        public override string DisplayMember => Name;
    }
}
