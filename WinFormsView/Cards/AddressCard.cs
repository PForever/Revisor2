using Revisor2.Model.Models;
using Revisor2.Model.Repositories;
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

namespace WinFormsView.Cards
{
    public partial class AddressCard : Form
    {
        private readonly AddressM _model;
        private readonly AddressesRepository _repository;
        private readonly PeopleRepository _peopleRepository;

        public AddressCard(AddressM model, AddressesRepository repository, PeopleRepository peopleRepository)
        {
            InitializeComponent();
            InitializeComponentCustom();
            _model = model;
            _repository = repository;
            _peopleRepository = peopleRepository;
        }

        private void InitializeComponentCustom()
        {
            bsAddress.DataSource = typeof(AddressM);
            tbName.SetTextBoxBinding(bsAddress, nameof(AddressM.Name));
            tbDescription.SetTextBoxBinding(bsAddress, nameof(AddressM.Description));

            dgvBypass.DataSource = bsBypass;
            dgvBypass.Columns.AddRange(WinFormsHelper.CreateColumns<BypassM>());
            bsBypass.DataSource = _model;
            bsBypass.DataMember = nameof(AddressM.Bypasses);


            dgvPeople.DataSource = bsPeople;
            dgvPeople.Columns.AddRange(WinFormsHelper.CreateColumns<PersonM>());
            bsPeople.DataSource = _model;
            bsPeople.DataMember = nameof(AddressM.People);

            dgvPorch.DataSource = bsPorch;
            dgvPorch.Columns.AddRange(WinFormsHelper.CreateColumns<PorchM>());
            bsPorch.DataSource = _model;
            bsPorch.DataMember = nameof(AddressM.Porches);
        }

        protected override void OnLoad(EventArgs e)
        {
            Fill();
            base.OnLoad(e);
        }

        private void Fill()
        {
            bsAddress.DataSource = _model;
        }

        private void OnAddPorch(object sender, EventArgs e)
        {
            var model = new PorchM(Guid.NewGuid());
            var card = new PorchCard(model, _model, _repository);
            if (card.ShowDialog() == DialogResult.OK) bsPorch.Add(model);
            dgvPorch.Refresh();
        }

        private void OnChangePorch(object sender, EventArgs e)
        {
            //консолидация?
            var model = dgvPorch.GetCurrent<PorchM>();
            var card = new PorchCard(model, _model, _repository);
            if (card.ShowDialog() == DialogResult.OK) dgvPorch.Refresh();
            //else model.Cancel();
        }

        private void OnRemovePorch(object sender, EventArgs e)
        {
            var model = dgvPorch.GetCurrent<PorchM>();
            _repository.Remove(model);
            bsPorch.Remove(model);
            dgvPorch.Refresh();
        }

        private void OnAddPerson(object sender, EventArgs e)
        {
            var model = new PersonM();
            var card = new PersonCard(model, _peopleRepository);
            if (card.ShowDialog() == DialogResult.OK) bsPeople.Add(model);
            dgvPeople.Refresh();
        }

        private void OnChangePerson(object sender, EventArgs e)
        {
            var model = dgvPeople.GetCurrent<PersonM>();
            var card = new PersonCard(model, _peopleRepository);
            if (card.ShowDialog() == DialogResult.OK) dgvPeople.Refresh();
        }

        private void OnRemovePerson(object sender, EventArgs e)
        {
            var model = dgvPeople.GetCurrent<PersonM>();
            _repository.Remove(_model, model);
            bsPeople.Remove(model);
            dgvPeople.Refresh();
        }

        private void OnAddBypass(object sender, EventArgs e)
        {
            var model = new BypassM(Guid.NewGuid());
            var card = new BypassCard(model, _peopleRepository);
            if (card.ShowDialog() == DialogResult.OK) bsBypass.Add(model);
            dgvBypass.Refresh();
        }

        private void OnChangeBypass(object sender, EventArgs e)
        {
            var model = dgvBypass.GetCurrent<BypassM>();
            var card = new BypassCard(model, _peopleRepository);
            if (card.ShowDialog() == DialogResult.OK) dgvBypass.Refresh();
        }

        private void OnRemoveBypass(object sender, EventArgs e)
        {
            var model = dgvBypass.GetCurrent<BypassM>();
            _repository.Remove(model);
            bsBypass.Remove(model);
            dgvBypass.Refresh();
        }
    }
}
