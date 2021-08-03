using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsView.Lists;

namespace WinFormsView
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnPeople(object sender, EventArgs e)
        {
            var card = new Peoples();
            card.Show();
        }

        private void OnAddresses(object sender, EventArgs e)
        {
            var card = new AddressesList();
            card.Show();
        }
    }
}
