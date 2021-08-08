using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Models
{
    public class BookResultM : DomainModelBase<ValueResultM, Guid>
    {
        public BookResultM() { }
        public BookResultM(Guid id, DateTime date, BookM book) : base(id)
        {
            _Date = date;
            _Book = book;
        }
        private DateTime _Date;
        public DateTime Date { get => _Date; set => Set(ref _Date, value); }
        public ContributionM Contribution { get; set; }
        private BookM _Book;
        public BookM Book { get => _Book; set => SetVm(ref _Book, value); }
        public override string DisplayMember => $"{Book.Name} - {Date}";
    }
}
