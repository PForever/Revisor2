using Revisor2.Model.Repositories;
using Revisor2.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsView.Help;
using WinFormsView.Cards;

namespace WinFormsView.Lists
{
    public partial class AddressesList : Form
    {
        private AddressesRepository _repository;
        private PeopleRepository _peopleRepository;

        public AddressesList()
        {
            InitializeComponent();
            InitializeComponentCustom();
            Shown += OnShownAsync;
        }

        private void OnShownAsync(object sender, EventArgs e)
        {
            _repository = new AddressesRepository();
            _peopleRepository = new PeopleRepository();
            Fill(_repository.GetAddresses().OrderBy(a => a.Name).ToList());
        }

        private void Fill(ICollection<AddressM> address)
        {
            bsAddresses.DataSource = address;
        }

        private void InitializeComponentCustom()
        {
            dgvAddresses.AutoGenerateColumns = false;
            dgvAddresses.Columns.AddRange(WinFormsHelper.CreateColumns<AddressM>());
        }

        private void OnAdd(object sender, EventArgs e)
        {
            var model = new AddressM(-1);
            var card = new AddressCard(model, _repository, _peopleRepository);
            if(card.ShowDialog() == DialogResult.OK)
            {
                _repository.Add(model);
                bsAddresses.Add(model);
                dgvAddresses.Refresh();
            }
        }

        private void OnChange(object sender, EventArgs e)
        {
            var model = dgvAddresses.GetCurrent<AddressM>();
            if (model == null) return;
            var card = new AddressCard(model, _repository, _peopleRepository);
            if (card.ShowDialog() == DialogResult.OK)
            {
                bsAddresses.Add(model);
                dgvAddresses.Refresh();
            }
            //else model.Cancel();
        }

        private void OnDelete(object sender, EventArgs e)
        {
            var model = dgvAddresses.GetCurrent<AddressM>();
            if (model == null) return;
            _repository.Remove(model);
            bsAddresses.Add(model);
            dgvAddresses.Refresh();
        }
    }
}
