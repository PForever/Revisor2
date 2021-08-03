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

namespace WinFormsView.Cards
{
    public partial class PersonCard : Form
    {
        private readonly PersonM _person;
        private readonly PeopleRepository _peopleRepository;

        private void OnStart()
        {
            InitializeComponent();
            CustomInitialize();
            FillDataSources(_peopleRepository);
        }

        private void CustomInitialize()
        {
            bsSosialStatus.DataSource = typeof(SosialSatusM);
            bsInviter.DataSource = typeof(OrgPersonM);
            bsInvitePlace.DataSource = typeof(PlaceVm);
            bsOrgState.DataSource = typeof(OrgStateM);
            bsWorkType.DataSource = typeof(WorkTypeM);
            bsCallResult.DataSource = typeof(CallResultM);
            bsMeetPerson.DataSource = typeof(OrgPersonM);
            bsAddress.DataSource = typeof(AddressM);

            cbSosialStatus.DataSource = bsSosialStatus;
            cbInviter.DataSource = bsInviter;
            cbInvitePlace.DataSource = bsInvitePlace;
            cbOrgState.DataSource = bsOrgState;
            cbWorkType.DataSource = bsWorkType;
            cbCallResult.DataSource = bsCallResult;
            cbMeetPerson.DataSource = bsMeetPerson;
            cbAddress.DataSource = bsAddress;

            cbSosialStatus.DisplayMember = nameof(SosialSatusM.Name);
            cbSosialStatus.ValueMember = nameof(SosialSatusM.Name);

            cbInviter.DisplayMember = nameof(OrgPersonM.Name);
            cbInviter.ValueMember = nameof(OrgPersonM.Name);

            cbInvitePlace.DisplayMember = nameof(PlaceVm.Name);
            cbInvitePlace.ValueMember = nameof(PlaceVm.Name);

            cbOrgState.DisplayMember = nameof(OrgStateM.Name);
            cbOrgState.ValueMember = nameof(OrgStateM.Name);

            cbWorkType.DisplayMember = nameof(WorkTypeM.Name);
            cbWorkType.ValueMember = nameof(WorkTypeM.Name);

            cbCallResult.DisplayMember = nameof(CallResultM.Name);
            cbCallResult.ValueMember = nameof(CallResultM.Name);

            cbMeetPerson.DisplayMember = nameof(OrgPersonM.Name);
            cbMeetPerson.ValueMember = nameof(OrgPersonM.Name);

            cbAddress.DisplayMember = nameof(AddressM.Name);
            cbAddress.ValueMember = nameof(AddressM.Name);
        }

        public PersonCard(PeopleRepository peopleRepository) : this(new PersonM(-1), peopleRepository)
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
            bsSosialStatus.DataSource = _peopleRepository.GetSosialSatus().StartWith(new SosialSatusM(-1) { Name = "Нет"}).ToList();
            bsInviter.DataSource = _peopleRepository.GetOrgPeople().StartWith(new OrgPersonM(-1) { Name = "Нет" }).ToList();
            bsInvitePlace.DataSource = _peopleRepository.GetPlaces().StartWith(new PlaceVm(-1) { Name = "Нет" }).ToList();
            bsOrgState.DataSource = _peopleRepository.GetOrgStates().StartWith(new OrgStateM(-1) { Name = "Нет" }).ToList();
            bsWorkType.DataSource = _peopleRepository.GetWorkTypes().StartWith(new WorkTypeM(-1) { Name = "Нет" }).ToList();
            bsCallResult.DataSource = _peopleRepository.GetCallResults().StartWith(new CallResultM(-1) { Name = "Нет" }).ToList();
            bsMeetPerson.DataSource = _peopleRepository.GetOrgPeople().StartWith(new OrgPersonM(-1) { Name = "Нет" }).ToList();
            bsAddress.DataSource = _peopleRepository.GetAddresses().StartWith(new AddressM(-1) { Name = "Нет" }).ToList();

            cbSosialStatus.SetNullubleBinding(nameof(ComboBox.SelectedValue), bsSosialStatus, nameof(SosialSatusM.Name), new SosialSatusM(-1) { Name = "Нет" });
            cbInviter.SetNullubleBinding(nameof(ComboBox.SelectedValue), bsInviter, nameof(OrgPersonM.Name), new OrgPersonM(-1) { Name = "Нет" });
            cbInvitePlace.SetNullubleBinding(nameof(ComboBox.SelectedValue), bsInvitePlace, nameof(PlaceVm.Name), new PlaceVm(-1) { Name = "Нет" });
            cbOrgState.SetNullubleBinding(nameof(ComboBox.SelectedValue), bsOrgState, nameof(OrgStateM.Name), new OrgStateM(-1) { Name = "Нет" });
            cbWorkType.SetNullubleBinding(nameof(ComboBox.SelectedValue), bsWorkType, nameof(WorkTypeM.Name), new WorkTypeM(-1) { Name = "Нет" });
            cbCallResult.SetNullubleBinding(nameof(ComboBox.SelectedValue), bsCallResult, nameof(CallResultM.Name), new CallResultM(-1) { Name = "Нет" });
            cbMeetPerson.SetNullubleBinding(nameof(ComboBox.SelectedValue), bsMeetPerson, nameof(OrgPersonM.Name), new OrgPersonM(-1) { Name = "Нет" });
            cbAddress.SetNullubleBinding(nameof(ComboBox.SelectedValue), bsAddress, nameof(AddressM.Name), new AddressM(-1) { Name = "Нет" });
        }

        private void Fill(PersonM person)
        {
            bsPerson.DataSource = person;

            SetBinding(tbName, nameof(TextBox.Text), nameof(person.Name));
            SetBinding(tbDiscription, nameof(TextBox.Text), nameof(person.Discription));
            SetBinding(tbPorch, nameof(TextBox.Text), nameof(person.Porch));

            SetBinding(chbIsRoom, nameof(CheckBox.Checked), nameof(person.IsRoom));

            ////SetBinding(cbSosialStatus, nameof(ComboBox.SelectedValue), nameof(person.SosialStatus));
            ////SetBinding(cbInviter, nameof(ComboBox.SelectedValue), nameof(person.Inviter));
            ////SetBinding(cbInvitePlace, nameof(ComboBox.SelectedValue), nameof(person.IvitePlace));
            ////SetBinding(cbLastPaper, nameof(ComboBox.SelectedValue), nameof(person.LastPaper));
            ////SetBinding(cbOrgState, nameof(ComboBox.SelectedValue), nameof(person.OrgState));
            ////SetBinding(cbWorkType, nameof(ComboBox.SelectedValue), nameof(person.WorkType));
            ////SetBinding(cbCallResult, nameof(ComboBox.SelectedValue), nameof(person.CallResult));
            ////SetBinding(cbMeetPerson, nameof(ComboBox.SelectedValue), nameof(person.MeetPerson));
            ////SetBinding(cbAddress, nameof(ComboBox.SelectedValue), nameof(person.Address));

            SetNullubleDateTimeBinding(dtpInviteDate, nameof(DateTimePicker.Value), nameof(person.InviteDate));
            SetNullubleDateTimeBinding(dtpCallDate, nameof(DateTimePicker.Value), nameof(person.CallDate));
            SetNullubleDateTimeBinding(dtpMeetDate, nameof(DateTimePicker.Value), nameof(person.MeetDate));



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
