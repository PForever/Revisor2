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
        }
        public PersonCard(PersonVm person)
        {
            OnStart();
            Fill(person);
        }

        private void Fill(PersonVm person)
        {
            bsPerson.DataSource = person;

            SetBinding(tbName, nameof(TextBox.Text), nameof(person.Name));
            SetBinding(tbDiscription, nameof(TextBox.Text), nameof(person.Discription));

            SetBinding(chbIsRoom, nameof(CheckBox.Checked), nameof(person.IsRoom));

            //SetBinding(cbSosialStatus, nameof(ComboBox.SelectedValue), nameof(person.SosialStatus));
            //SetBinding(cbInviter, nameof(ComboBox.SelectedValue), nameof(person.Inviter));
            //SetBinding(cbInvitePlace, nameof(ComboBox.SelectedValue), nameof(person.IvitePlace));
            //SetBinding(cbLastPaper, nameof(ComboBox.SelectedValue), nameof(person.LastPaper));
            //SetBinding(cbOrgState, nameof(ComboBox.SelectedValue), nameof(person.OrgState));
            //SetBinding(cbWorkType, nameof(ComboBox.SelectedValue), nameof(person.WorkType));
            //SetBinding(cbCallResult, nameof(ComboBox.SelectedValue), nameof(person.CallResult));
            //SetBinding(cbMeetPerson, nameof(ComboBox.SelectedValue), nameof(person.MeetPerson));
            //SetBinding(cbAddress, nameof(ComboBox.SelectedValue), nameof(person.Address));

            SetNullubleDateTimeBinding(dtpInviteDate, nameof(DateTimePicker.Value), nameof(person.InviteDate));
            SetNullubleDateTimeBinding(dtpCallDate, nameof(DateTimePicker.Value), nameof(person.CallDate));
            SetNullubleDateTimeBinding(dtpMeetDate, nameof(DateTimePicker.Value), nameof(person.MeetDate));

            mtbAge.Mask = "00000";
            mtbLastContribution.Mask = "00000";
            mtbPhoneNumber.Mask = "00000";
            mtbDisconnectsCount.Mask = "00000";
            mtbCallsCount.Mask = "00000";
            mtbRoom.Mask = "00000";
            mtbFloor.Mask = "00000";
            mtbPorch.Mask = "00000";

            SetNullubleNumericUpDownBinding(nudPaperCount, chbPaperCount, nameof(person.PaperCount));
            
            SetBinding(mtbAge, nameof(MaskedTextBox.Text), nameof(person.Age));
            SetBinding(mtbLastContribution, nameof(MaskedTextBox.Text), nameof(person.LastСontribution));
            SetBinding(mtbPhoneNumber, nameof(MaskedTextBox.Text), nameof(person.PhoneNumber));
            SetBinding(mtbDisconnectsCount, nameof(MaskedTextBox.Text), nameof(person.DisconnectsCount));
            SetBinding(mtbCallsCount, nameof(MaskedTextBox.Text), nameof(person.CallsCount));
            SetBinding(mtbRoom, nameof(MaskedTextBox.Text), nameof(person.Room));
            SetBinding(mtbFloor, nameof(MaskedTextBox.Text), nameof(person.Floor));
            SetBinding(mtbPorch, nameof(MaskedTextBox.Text), nameof(person.Porch));
        }
        public void SetBinding(Control control, string propertyName, string memeberName)
        {
            control.SetBinding(propertyName, bsPerson, memeberName);
        }
        public void SetNullubleDateTimeBinding(DateTimePicker control, string propertyName, string memeberName)
        {
            control.SetNullubleDateTimeBinding(propertyName, bsPerson, memeberName);
        }
        public void SetNullubleNumericUpDownBinding(NumericUpDown control, CheckBox checkBox, string memeberName)
        {
            control.SetNullubleNumericUpDownBinding(checkBox, bsPerson, memeberName);
        }
    }
    public static class WinFormsHelper
    {
        public static void SetBinding(this Control control, string propertyName, object dataSource, string memeberName)
        {
            control.DataBindings.Add(new Binding(propertyName, dataSource, memeberName));
        }
        public static void SetNullubleDateTimeBinding(this DateTimePicker control, string propertyName, object dataSource, string memeberName)
        {
            var binding = new Binding(propertyName, dataSource, memeberName, true);
            var provider = new DateTimeBindingProvider(control);
            binding.Parse += provider.OnParse;
            binding.Format += provider.OnFormat;
            control.DataBindings.Add(binding);
        }
        class DateTimeBindingProvider
        {
            private readonly DateTimePicker _dateTimePicker;
            public DateTimeBindingProvider(DateTimePicker dateTimePicker)
            {
                _dateTimePicker = dateTimePicker;
            }

            public void OnFormat(object sender, ConvertEventArgs e)
            {
                if (e.Value is null)
                {
                    e.Value = _dateTimePicker.Value;
                    _dateTimePicker.Checked = false;
                }
            }

            public void OnParse(object sender, ConvertEventArgs e)
            {
                if (_dateTimePicker.Checked) return;
                e.Value = default(DateTime?);
            }
        }

        public static void SetNullubleNumericUpDownBinding(this NumericUpDown control, CheckBox checkBox, object dataSource, string memeberName)
        {
            var binding = new Binding(nameof(NumericUpDown.Value), dataSource, memeberName, true);
            var provider = new NumericUpDownBindingProvider(control, checkBox, binding);
            binding.Parse += provider.OnParse;
            binding.Format += provider.OnFormat;
            checkBox.CheckStateChanged += provider.OnCheckedChanged;
            control.DataBindings.Add(binding);
        }

        class NumericUpDownBindingProvider
        {
            private readonly NumericUpDown _numericUpDown;
            private readonly CheckBox _checkBox;
            private readonly Binding _binding;

            public NumericUpDownBindingProvider(NumericUpDown numericUpDown, CheckBox checkBox, Binding binding)
            {
                _numericUpDown = numericUpDown;
                _checkBox = checkBox;
                _binding = binding;
            }

            public void OnFormat(object sender, ConvertEventArgs e)
            {
                if (e.Value is null)
                {
                    e.Value = _numericUpDown.Value;
                    if (_checkBox.Checked) _checkBox.Checked = false;
                    else _numericUpDown.Enabled = false;
                }
                else _checkBox.Checked = true;
            }

            public void OnParse(object sender, ConvertEventArgs e)
            {
                if (_checkBox.Checked)
                {
                    e.Value = _numericUpDown.Value;
                }
                else
                {
                    e.Value = null;//default(DateTime?);
                }
            }

            public void OnFormatCheckBox(object sender, ConvertEventArgs e)
            {
                if (e.Value is null)
                {
                    e.Value = false;
                }
                else
                {
                    e.Value = true;
                }
            }
            internal void OnCheckedChanged(object sender, EventArgs e)
            {
                _numericUpDown.Enabled = _checkBox.Checked;
                //_numericUpDown.Value = _numericUpDown.Value;
                _binding.WriteValue();
            }
        }

    }
}
