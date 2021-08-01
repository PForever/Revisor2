using Revisor2.Model.Repositories;
using Revisor2.Model.ViewModels;
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
        private readonly PersonVm _person;
        private readonly PeopleRepository _peopleRepository;

        private void OnStart()
        {
            InitializeComponent();
            CustomInitialize();
            FillDataSources(_peopleRepository);
        }

        private void CustomInitialize()
        {
            bsSosialStatus.DataSource = typeof(SosialSatusVm);
            bsInviter.DataSource = typeof(OrgPersonVm);
            bsInvitePlace.DataSource = typeof(PlaceVm);
            bsOrgState.DataSource = typeof(OrgStateVm);
            bsWorkType.DataSource = typeof(WorkTypeVm);
            bsCallResult.DataSource = typeof(CallResultVm);
            bsMeetPerson.DataSource = typeof(OrgPersonVm);
            bsAddress.DataSource = typeof(AddressVm);

            cbSosialStatus.DataSource = bsSosialStatus;
            cbInviter.DataSource = bsInviter;
            cbInvitePlace.DataSource = bsInvitePlace;
            cbOrgState.DataSource = bsOrgState;
            cbWorkType.DataSource = bsWorkType;
            cbCallResult.DataSource = bsCallResult;
            cbMeetPerson.DataSource = bsMeetPerson;
            cbAddress.DataSource = bsAddress;

            cbSosialStatus.DisplayMember = nameof(SosialSatusVm.Name);
            cbSosialStatus.ValueMember = nameof(SosialSatusVm.Name);

            cbInviter.DisplayMember = nameof(OrgPersonVm.Name);
            cbInviter.ValueMember = nameof(OrgPersonVm.Name);

            cbInvitePlace.DisplayMember = nameof(PlaceVm.Name);
            cbInvitePlace.ValueMember = nameof(PlaceVm.Name);

            cbOrgState.DisplayMember = nameof(OrgStateVm.Name);
            cbOrgState.ValueMember = nameof(OrgStateVm.Name);

            cbWorkType.DisplayMember = nameof(WorkTypeVm.Name);
            cbWorkType.ValueMember = nameof(WorkTypeVm.Name);

            cbCallResult.DisplayMember = nameof(CallResultVm.Name);
            cbCallResult.ValueMember = nameof(CallResultVm.Name);

            cbMeetPerson.DisplayMember = nameof(OrgPersonVm.Name);
            cbMeetPerson.ValueMember = nameof(OrgPersonVm.Name);

            cbAddress.DisplayMember = nameof(AddressVm.Name);
            cbAddress.ValueMember = nameof(AddressVm.Name);
        }

        public PersonCard(PeopleRepository peopleRepository) : this(new PersonVm(-1), peopleRepository)
        {
        }
        public PersonCard(PersonVm person, PeopleRepository peopleRepository)
        {
            _person = person;
            _peopleRepository = peopleRepository;
            OnStart();
            Fill(person);
        }

        private void FillDataSources(PeopleRepository _peopleRepository)
        {
            bsSosialStatus.DataSource = _peopleRepository.GetSosialSatus().StartWith(new SosialSatusVm(-1) { Name = "Нет"}).ToList();
            bsInviter.DataSource = _peopleRepository.GetOrgPeople().StartWith(new OrgPersonVm(-1) { Name = "Нет" }).ToList();
            bsInvitePlace.DataSource = _peopleRepository.GetPlaces().StartWith(new PlaceVm(-1) { Name = "Нет" }).ToList();
            bsOrgState.DataSource = _peopleRepository.GetOrgStates().StartWith(new OrgStateVm(-1) { Name = "Нет" }).ToList();
            bsWorkType.DataSource = _peopleRepository.GetWorkTypes().StartWith(new WorkTypeVm(-1) { Name = "Нет" }).ToList();
            bsCallResult.DataSource = _peopleRepository.GetCallResults().StartWith(new CallResultVm(-1) { Name = "Нет" }).ToList();
            bsMeetPerson.DataSource = _peopleRepository.GetOrgPeople().StartWith(new OrgPersonVm(-1) { Name = "Нет" }).ToList();
            bsAddress.DataSource = _peopleRepository.GetAddresses().StartWith(new AddressVm(-1) { Name = "Нет" }).ToList();

            cbSosialStatus.SetNullubleBinding(nameof(ComboBox.SelectedValue), bsSosialStatus, nameof(SosialSatusVm.Name), new SosialSatusVm(-1) { Name = "Нет" });
            cbInviter.SetNullubleBinding(nameof(ComboBox.SelectedValue), bsInviter, nameof(OrgPersonVm.Name), new OrgPersonVm(-1) { Name = "Нет" });
            cbInvitePlace.SetNullubleBinding(nameof(ComboBox.SelectedValue), bsInvitePlace, nameof(PlaceVm.Name), new PlaceVm(-1) { Name = "Нет" });
            cbOrgState.SetNullubleBinding(nameof(ComboBox.SelectedValue), bsOrgState, nameof(OrgStateVm.Name), new OrgStateVm(-1) { Name = "Нет" });
            cbWorkType.SetNullubleBinding(nameof(ComboBox.SelectedValue), bsWorkType, nameof(WorkTypeVm.Name), new WorkTypeVm(-1) { Name = "Нет" });
            cbCallResult.SetNullubleBinding(nameof(ComboBox.SelectedValue), bsCallResult, nameof(CallResultVm.Name), new CallResultVm(-1) { Name = "Нет" });
            cbMeetPerson.SetNullubleBinding(nameof(ComboBox.SelectedValue), bsMeetPerson, nameof(OrgPersonVm.Name), new OrgPersonVm(-1) { Name = "Нет" });
            cbAddress.SetNullubleBinding(nameof(ComboBox.SelectedValue), bsAddress, nameof(AddressVm.Name), new AddressVm(-1) { Name = "Нет" });
        }

        private void Fill(PersonVm person)
        {
            bsPerson.DataSource = person;

            SetBinding(tbName, nameof(TextBox.Text), nameof(person.Name));
            SetBinding(tbDiscription, nameof(TextBox.Text), nameof(person.Discription));
            SetBinding(tbPorch, nameof(TextBox.Text), nameof(person.Porch));

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
