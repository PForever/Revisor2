using DynamicFilter.Abstract;
using DynamicFilterControls;
using FilterLibrary.FilterHelp;
using FilterLibrary.SortableBindingList;
using Revisor2.Model.Repositories;
using Revisor2.Model.ViewModels;
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
using WinFormsView;

namespace WinFormsView.Lists
{
    public partial class Peoples : Form
    {
        private readonly PeopleRepository _repository;
        private PropertiesFilter _docFilters;

        private IOperand Filter { get; set; }
        private Expression<Func<PersonVm, bool>> Predicate { get; set; }

        public Peoples()
        {
            _repository = new PeopleRepository();
            var poeople = GetPeople();
            OnStart(poeople);
        }

        private IList<PersonVm> GetPeople()
        {
            return _repository.GetPeoples();
        }

        private void OnStart(IList<PersonVm> people)
        {
            InitializeComponent();
            InitializeComponentCustom();
            Fill(people);
        }

        private void InitializeComponentCustom()
        {
            InitColumns();
            //btFilter.Container.Components.OfType<Control>().ForEach(c => c.Cursor = System.Windows.Forms.Cursors.Arrow);
            //btFilterClear.Container.Components.OfType<Control>().ForEach(c => c.Cursor = System.Windows.Forms.Cursors.Arrow);
        }

        private void Fill(IList<PersonVm> people)
        {
            sbPeople.DataSource = people.ToSortableBindingList();
            _docFilters = new PropertiesFilter(dgvPeople.Columns.Cast<DataGridViewColumn>());
        }

        private void InitColumns()
        {
            dgvPeople.DataSource = sbPeople;
        }

        private void OnEdit(object sender, EventArgs e)
        {
            if (dgvPeople.SelectedRows.Count == 0) return;
            var person = dgvPeople.SelectedRows[0].DataBoundItem as PersonVm;
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
            var filterForm = Filter == null ? new DynamicFilterForm(_repository.DtoType, dgvPeople.Columns) : new DynamicFilterForm(_repository.DtoType, dgvPeople.Columns, Filter);
            if (filterForm.ShowDialog() == DialogResult.OK)
            {
                Filter = filterForm.Result;
                //Predicate = Filter?.Calculate() as Expression<Func<PersonVm, bool>>;
                //var filter = Predicate.Compile();
                var people = _repository.GetPeoples(Filter?.Calculate()).ToSortableBindingList();
                Fill(people);
            }
        }
    }
}
