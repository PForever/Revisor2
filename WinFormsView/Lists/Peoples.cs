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
        public Peoples()
        {
            var poeople = GetPeople();
            OnStart(poeople);
        }

        private IList<PersonVm> GetPeople()
        {
            using (var repository = new PeopleRepository())
            {
                return repository.GetPeoples();
            }
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
            var card = new PersonCard(person);
            card.ShowDialog();
        }
    }
}
