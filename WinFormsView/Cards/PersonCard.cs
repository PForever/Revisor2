using Revisor2.Model.Repositories;
using Revisor2.Model.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemHelpers;
using WinFormsView.Help;
using System;

namespace WinFormsView.Cards
{
    public partial class PersonCard : Form
    {
        private readonly PersonM _person;
        private readonly PeopleRepository _peopleRepository;

        private void OnStart()
        {
            InitializeComponent();
            Load += OnLoaded;
        }

        private void OnLoaded(object sender, EventArgs e)
        {
            CustomInitialize();
            FillDataSources(_peopleRepository);
        }

        private void CustomInitialize()
        {
            bsSosialStatus.DataSource = typeof(SosialStatusM);
            bsInviter.DataSource = typeof(OrgPersonM);
            bsInvitePlace.DataSource = typeof(PlaceM);
            bsOrgState.DataSource = typeof(OrgStateM);
            bsWorkType.DataSource = typeof(WorkTypeM);
            bsCallResult.DataSource = typeof(CallEventResultM);
            bsMeetPerson.DataSource = typeof(OrgPersonM);
            bsAddress.DataSource = typeof(AddressM);

            bsContributions.DataSource = typeof(PersonM);
            bsContributions.DataMember = nameof(PersonM.Contributions);
            bsPapers.DataSource = typeof(PersonM);
            bsPapers.DataMember = nameof(PersonM.Papers);
            bsCalls.DataSource = typeof(PersonM);
            bsCalls.DataMember = nameof(PersonM.Calls);

            dgvCalls.DataSource = bsCalls;
            dgvCalls.Columns.AddRange(WinFormsHelper.CreateColumns<CallEventResultM>());
            dgvPapers.DataSource = bsPapers;
            dgvPapers.Columns.AddRange(WinFormsHelper.CreateColumns<PaperM>());
            dgvContributions.DataSource = bsContributions;
            dgvContributions.Columns.AddRange(WinFormsHelper.CreateColumns<ContributionM>());

            //cbSosialStatus.DataSource = bsSosialStatus;
            //cbInviter.DataSource = bsInviter;
            //cbInvitePlace.DataSource = bsInvitePlace;
            //cbOrgState.DataSource = bsOrgState;
            //cbWorkType.DataSource = bsWorkType;
            //cbCallResult.DataSource = bsCallResult;
            //cbMeetPerson.DataSource = bsMeetPerson;
            //cbAddress.DataSource = bsAddress;


            //cbSosialStatus.DisplayMember = nameof(SosialStatusM.Name);
            //cbSosialStatus.ValueMember = nameof(SosialStatusM.Name);

            //cbInviter.DisplayMember = nameof(OrgPersonM.Name);
            //cbInviter.ValueMember = nameof(OrgPersonM.Name);

            //cbInvitePlace.DisplayMember = nameof(PlaceM.Name);
            //cbInvitePlace.ValueMember = nameof(PlaceM.Name);

            //cbOrgState.DisplayMember = nameof(OrgStateM.Name);
            //cbOrgState.ValueMember = nameof(OrgStateM.Name);

            //cbWorkType.DisplayMember = nameof(WorkTypeM.Name);
            //cbWorkType.ValueMember = nameof(WorkTypeM.Name);

            //cbCallResult.DisplayMember = nameof(CallResultM.Name);
            //cbCallResult.ValueMember = nameof(CallResultM.Name);

            //cbMeetPerson.DisplayMember = nameof(OrgPersonM.Name);
            //cbMeetPerson.ValueMember = nameof(OrgPersonM.Name);

            //cbAddress.DisplayMember = nameof(AddressM.Name);
            //cbAddress.ValueMember = nameof(AddressM.Name);
        }

        public PersonCard(PeopleRepository peopleRepository) : this(new PersonM(), peopleRepository)
        {
        }
        public PersonCard(PersonM person, PeopleRepository peopleRepository)
        {
            _person = person;
            _peopleRepository = peopleRepository;
            OnStart();
            Fill(person);
        }

        private void FillDataSources(PeopleRepository _peopleRepository)
        {
            //bsCallResult.DataSource = _peopleRepository.GetCallResults();

            bsSosialStatus.DataSource = _peopleRepository.GetSosialSatus();
            bsInviter.DataSource = _peopleRepository.GetOrgPeople();
            bsInvitePlace.DataSource = _peopleRepository.GetPlaces();
            bsOrgState.DataSource = _peopleRepository.GetOrgStates();
            bsWorkType.DataSource = _peopleRepository.GetWorkTypes();
            bsMeetPerson.DataSource = _peopleRepository.GetOrgPeople();
            bsAddress.DataSource = _peopleRepository.GetAddresses();
        }

        private void Fill(PersonM person)
        {
            bsPerson.DataSource = person;

            bsCalls.DataSource = bsPerson;
            bsPapers.DataSource = bsPerson;
            bsContributions.DataSource = bsPerson;

            SetBinding(tbName, nameof(TextBox.Text), nameof(person.Name));
            SetBinding(tbDescription, nameof(TextBox.Text), nameof(person.Description));
            SetBinding(tbPorch, nameof(TextBox.Text), nameof(person.Porch));

            SetBinding(chbIsRoom, nameof(CheckBox.Checked), nameof(person.IsRoom));

            SetNullubleDateTimeBinding(dtpInviteDate, nameof(DateTimePicker.Value), nameof(person.InviteDate));
            SetNullubleDateTimeBinding(dtpCallDate, nameof(DateTimePicker.Value), nameof(person.CallDate));
            SetNullubleDateTimeBinding(dtpMeetDate, nameof(DateTimePicker.Value), nameof(person.MeetDate));

            //cbCallResult.SetNullubleComboBinding(bsPerson, nameof(PersonM.CallResult), new CallResultM(-1) { Name = "Нет" }, bsCallResult);
            cbSosialStatus.SetNullubleComboBinding(bsPerson, nameof(PersonM.SosialStatus), new SosialStatusM() { Name = "Нет" }, bsSosialStatus);
            cbInviter.SetNullubleComboBinding(bsPerson, nameof(PersonM.Inviter), new OrgPersonM() { ShortName = "Нет" }, bsInviter);
            cbInvitePlace.SetNullubleComboBinding(bsPerson, nameof(PersonM.InvitePlace), new PlaceM() { Name = "Нет" }, bsInvitePlace);
            cbOrgState.SetNullubleComboBinding(bsPerson, nameof(PersonM.OrgState), new OrgStateM() { Name = "Нет" }, bsOrgState);
            cbWorkType.SetNullubleComboBinding(bsPerson, nameof(PersonM.WorkType), new WorkTypeM() { Name = "Нет" }, bsWorkType);
            cbMeetPerson.SetNullubleComboBinding(bsPerson, nameof(PersonM.MeetPerson), new OrgPersonM() { ShortName = "Нет" }, bsMeetPerson);
            cbAddress.SetNullubleComboBinding(bsPerson, nameof(PersonM.Address), new AddressM() { Name = "Нет" }, bsAddress);

            SetNullubleNumericUpDownBinding(nudPaperCount, chbPaperCount, nameof(person.PaperCount));
            SetNullubleNumericUpDownBinding(nudAge, chbAge, nameof(person.Age));
            SetNullubleNumericUpDownBinding(nudLastContribution, chbLastContribution, nameof(person.LastСontribution));
            SetNullubleNumericUpDownBinding(nudLastPaper, chbLastPaper, nameof(person.LastPaper));
            SetNullubleNumericUpDownBinding(nudRoom, chbRoom, nameof(person.Room));
            SetNullubleNumericUpDownBinding(nudFloor, chbFloor, nameof(person.Floor));


            SetBinding(nudDisconnectsCount, nameof(NumericUpDown.Value), nameof(person.DisconnectsCount));
            SetBinding(nudCallsCount, nameof(NumericUpDown.Value), nameof(person.CallsCount));

            SetBinding(mtbPhoneNumber, nameof(MaskedTextBox.Text), nameof(person.PhoneNumber));
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

        private void OnSave(object sender, System.EventArgs e)
        {
            _peopleRepository.SavePerson(_person);
        }
    }
}
