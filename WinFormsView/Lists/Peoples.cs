using Revisor2.Model.Repositories;
using Revisor2.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsView.Lists
{
    public partial class Peoples : Form
    {
        private readonly PeopleRepository _repository;

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
            InitColumns();
            Fill(people);
        }

        private void Fill(IList<PersonVm> people)
        {
            sbPeople.DataSource = people;
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
    }
}
