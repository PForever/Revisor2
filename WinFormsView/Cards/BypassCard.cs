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

namespace WinFormsView.Cards
{
    public partial class BypassCard : Form
    {
        private readonly BypassM _model;
        private readonly PeopleRepository _peopleRepository;

        public BypassCard(BypassM model, PeopleRepository peopleRepository)
        {
            _model = model;
            InitializeComponent();
            _peopleRepository = peopleRepository;
        }

        private void OnAddContriburion(object sender, EventArgs e)
        {
            var model = new ContributionM();
            var card = new ContributionCard(model, _model.Address.People, _peopleRepository);
            if(card.ShowDialog() == DialogResult.OK)
            {
                
            }
        }
    }
}
