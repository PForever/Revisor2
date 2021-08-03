using DataLodaer;
using DynamicFilter.Abstract;
using DynamicFilterControls;
using FilterLibrary.FilterHelp;
using FilterLibrary.SortableBindingList;
using Revisor2.Model.Repositories;
using Revisor2.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemHelpers;
using WinFormsView.Help;
using WinFormsView.Cards;

namespace WinFormsView.Lists
{
    public partial class Peoples : Form
    {
        private readonly PeopleRepository _repository;
        private PropertiesFilter _docFilters;

        private IOperand Filter { get; set; }
        private Expression<Func<PersonM, bool>> Predicate { get; set; }

        public Peoples()
        {
            _repository = new PeopleRepository();
            var poeople = GetPeople();
            OnStart(poeople);
        }

        private IList<PersonM> GetPeople()
        {
            return _repository.GetPeoples();
        }

        private void OnStart(IList<PersonM> people)
        {
            InitializeComponent();
            InitializeComponentCustom();
            Fill(people);
        }

        private void InitializeComponentCustom()
        {
            InitColumns();
            dgvPeople.DataError += OnDataErrors;
            //btFilter.Container.Components.OfType<Control>().ForEach(c => c.Cursor = System.Windows.Forms.Cursors.Arrow);
            //btFilterClear.Container.Components.OfType<Control>().ForEach(c => c.Cursor = System.Windows.Forms.Cursors.Arrow);
        }

        private void OnDataErrors(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void Fill(IList<PersonM> people)
        {
            bsPeople.DataSource = people.ToSortableBindingList();
            bsAddresses.DataSource = _repository.GetAddresses()/*.StartWith(NoValue)*/.ToList();
            _docFilters = new PropertiesFilter(dgvPeople.Columns.Cast<DataGridViewColumn>());
        }

        private void InitColumns()
        {
            dgvPeople.AutoGenerateColumns = false;
            bsAddresses.DataSource = _repository.GetAddresses();
            var columns = WinFormsHelper.CreateColumns<PersonM>(bsAddresses);
            dgvPeople.Columns.AddRange(columns);
            dgvPeople.DataSource = bsPeople;
        }

        private void OnEdit(object sender, EventArgs e)
        {
            if (dgvPeople.SelectedRows.Count == 0) return;
            var person = dgvPeople.SelectedRows[0].DataBoundItem as PersonM;
            var card = new PersonCard(person, _repository);
            card.ShowDialog();
        }

        private void OnAdd(object sender, EventArgs e)
        {
            var card = new PersonCard(_repository);
            card.ShowDialog();
        }

        private async void OnClear(object sender, EventArgs e)
        {
            Filter = null;
            Predicate = null;
            //await UpdateDataAsync();
            var people = _repository.GetPeoples(null).ToSortableBindingList();
            Fill(people);
        }

        private async void OnFilter(object sender, EventArgs e)
        {
            var filterForm = Filter == null ? new DynamicFilterForm(typeof(PersonM), dgvPeople.Columns) : new DynamicFilterForm(typeof(PersonM), dgvPeople.Columns, Filter);
            if (filterForm.ShowDialog() == DialogResult.OK)
            {
                Filter = filterForm.Result;
                //Predicate = Filter?.Calculate() as Expression<Func<PersonVm, bool>>;
                //var filter = Predicate.Compile();
                Predicate = Filter?.Calculate().Reduce() as Expression<Func<PersonM, bool>>;
                var filter = Predicate.Compile();
                var people = _repository.GetPeoples().Where(filter).ToSortableBindingList();
                Fill(people);
            }
        }

        private void OnPrint(object sender, EventArgs e)
        {
            if (dgvPeople.SelectedCells.Count == 0) return;
            var person = dgvPeople.SelectedCells.Cast<DataGridViewCell>()
                .Where(c => c.RowIndex != -1)
                .Select(c => c.RowIndex)
                .Distinct()
                .Select(i => dgvPeople.Rows[i])
                .Cast<DataGridViewRow>()
                .Select(r => r.DataBoundItem as PersonM)
                .Select(p => p.Id)
                .ToList();
            Exporter.ExportToRoomTable(@"D:\Downloads\", DateTime.Now, person);
        }
    }
}
