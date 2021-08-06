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
    public partial class ContributionCard : Form
    {
        private readonly ContributionM _model;
        private readonly PeopleRepository _peopleRepository;
        private readonly IList<PersonM> _people;
        public ContributionCard(ContributionM model, IList<PersonM> people, PeopleRepository peopleRepository)
        {
            _model = model;
            _people = people;
            _peopleRepository = peopleRepository;
            InitializeComponent();
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            bsContribution.DataSource = typeof(ContributionM);
            //cbPerson.SetNullubleBinding(nameof(ContributionM.Id), bsPeople, new ContributionM(-1) { Name = "Нет" });
        }

        private void OnAddPerson(object sender, EventArgs e)
        {

        }
    }
}
