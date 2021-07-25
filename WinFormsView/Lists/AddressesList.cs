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
    public partial class AddressesList : Form
    {
        private AddressesRepository _repository;

        public AddressesList()
        {
            InitializeComponent();
            InitializeComponentCustom();
            Shown += OnShownAsync;
        }

        private void OnShownAsync(object sender, EventArgs e)
        {
            _repository = new AddressesRepository();
            Fill(_repository.GetAddresses().OrderBy(a => a.Name).ToList());
        }

        private void Fill(ICollection<AddressVm> address)
        {
            bsAddresses.DataSource = address;
        }

        private void InitializeComponentCustom()
        {

        }

        private void OnAdd(object sender, EventArgs e)
        {

        }

        private void OnCard(object sender, EventArgs e)
        {

        }

        private void OnDelete(object sender, EventArgs e)
        {

        }
    }
}
