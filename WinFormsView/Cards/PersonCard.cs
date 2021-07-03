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
    public partial class PersonCard : Form
    {
        private void OnStart()
        {
            InitializeComponent();
        }
        public PersonCard() : this(new PersonVm())
        {
            OnStart();
        }
        public PersonCard(PersonVm person)
        {
            Fill(person);
        }

        private void Fill(PersonVm person)
        {
            bsPerson.DataSource = person;

            SetBinding(tbName, nameof(TextBox.Text), nameof(person.Name));
            SetBinding(tbDiscription, nameof(TextBox.Text), nameof(person.Name));

            SetBinding(chbIsRoom, nameof(TextBox.Text), nameof(person.Name));

            SetBinding(cbSosialStatus, nameof(ComboBox.SelectedValue), nameof(person.Name));
            SetBinding(cbInviter, nameof(ComboBox.SelectedValue), nameof(person.Name));
            SetBinding(cbInvitePlace, nameof(ComboBox.SelectedValue), nameof(person.Name));
            SetBinding(cbLastPaper, nameof(ComboBox.SelectedValue), nameof(person.Name));
            SetBinding(cbOrgState, nameof(ComboBox.SelectedValue), nameof(person.Name));
            SetBinding(cbWorkType, nameof(ComboBox.SelectedValue), nameof(person.Name));
            SetBinding(cbCallResult, nameof(ComboBox.SelectedValue), nameof(person.Name));
            SetBinding(cbMeetPerson, nameof(ComboBox.SelectedValue), nameof(person.Name));
            SetBinding(cbAddress, nameof(ComboBox.SelectedValue), nameof(person.Name));

            SetBinding(dtpInviteDate, nameof(DateTimePicker.Value), nameof(person.Name));
            SetBinding(dtpCallDate, nameof(DateTimePicker.Value), nameof(person.Name));
            SetBinding(dtpMeetDate, nameof(DateTimePicker.Value), nameof(person.Name));

            SetBinding(mtbAge, nameof(MaskedTextBox.Text), nameof(person.Name));
            SetBinding(mtbPaperCount, nameof(MaskedTextBox.Text), nameof(person.Name));
            SetBinding(mtbLastContribution, nameof(MaskedTextBox.Text), nameof(person.Name));
            SetBinding(mtbPhoneNumber, nameof(MaskedTextBox.Text), nameof(person.Name));
            SetBinding(mtbDisconnectsCount, nameof(MaskedTextBox.Text), nameof(person.Name));
            SetBinding(mtbCallsCount, nameof(MaskedTextBox.Text), nameof(person.Name));

            SetBinding(mtbRoom, nameof(MaskedTextBox.Text), nameof(person.Name));
            SetBinding(mtbFloor, nameof(MaskedTextBox.Text), nameof(person.Name));
            SetBinding(mtbPorch, nameof(MaskedTextBox.Text), nameof(person.Name));
        }
        public void SetBinding(Control control, string propertyName, string memeberName)
        {
            control.DataBindings.Add(new Binding(propertyName, bsPerson, memeberName));
        }
    }
    public static class WinFormsHelper
    {
        public static void SetBinding(this Control control, string propertyName, object dataSource, string memeberName)
        {
            control.DataBindings.Add(new Binding(propertyName, dataSource, memeberName));
        }
    }
}
