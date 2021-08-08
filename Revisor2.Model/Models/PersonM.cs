using Revisor2.Model.Infrastructure;
using System;
using System.Collections.Generic;
using SystemHelpers;

namespace Revisor2.Model.Models
{
    public class PersonM : DomainModelBase<PersonM, Guid>
    {

        public PersonM() { }
        public PersonM(Guid id) : base(id) { }

        public PersonM(Guid id, string name, int? sourceId, int? age, SosialStatusM sosialStatus, OrgPersonM inviter, PlaceM invitePlace, 
            DateTime? inviteDate, OrgStateM orgState, long? phoneNumber, string description, bool isRoom, WorkTypeM workType, 
            DateTime? callDate, DateTime? meetDate, OrgPersonM meetPerson, AddressM address, int? room, int? floor, string porch, 
            int disconnectsCount, int callsCount, int? paperCount, int? lastPaper, int? lastСontribution) : this(id)
        {
            _Name = name;
            _SourceId = sourceId;
            _Age = age;
            _SosialStatus = sosialStatus;
            _Inviter = inviter;
            _InvitePlace = invitePlace;
            _InviteDate = inviteDate;
            _OrgState = InitVm(orgState, nameof(OrgState));
            _PhoneNumber = phoneNumber;
            _Description = description;
            _IsRoom = isRoom;
            _WorkType = InitVm(workType, nameof(WorkType));
            _CallDate = callDate;
            _MeetDate = meetDate;
            _MeetPerson = meetPerson;
            _Address = address;
            _Room = room;
            _Floor = floor;
            _Porch = porch;
            _DisconnectsCount = disconnectsCount;
            _CallsCount = callsCount;
            _PaperCount = paperCount;
            _LastPaper = lastPaper;
            _LastСontribution = lastСontribution;
        }

        private string _Name;
        public string Name { get => _Name; set => Set(ref _Name, value); }
        private int? _SourceId;
        public int? SourceId { get => _SourceId; set => Set(ref _SourceId, value); }
        private int? _Age;
        public int? Age { get => _Age; set => Set(ref _Age, value); }
        private SosialStatusM _SosialStatus;
        public SosialStatusM SosialStatus { get => _SosialStatus; set => SetVm(ref _SosialStatus, value); }
        private OrgPersonM _Inviter;
        public OrgPersonM Inviter { get => _Inviter; set => SetVm(ref _Inviter, value); }
        private PlaceM _InvitePlace;
        public PlaceM InvitePlace { get => _InvitePlace; set => SetVm(ref _InvitePlace, value); }
        private DateTime? _InviteDate;
        public DateTime? InviteDate { get => _InviteDate; set => Set(ref _InviteDate, value); }
        public DomainModelCollection<PaperM> Papers { get; set; }
        public DomainModelCollection<BookM> Books { get; set; }
        public DomainModelCollection<SubscribeM> Subscribes { get; set; }
        public DomainModelCollection<ContributionM, PersonM> Contributions { get; set; }
        public DomainModelCollection<CallEventResultM, PersonM> Calls { get; set; }
        public DomainModelCollection<PersonEventResultM, PersonM> Events { get; set; }
        private OrgStateM _OrgState;
        public OrgStateM OrgState { get => _OrgState; set => SetVm(ref _OrgState, value); }
        private long? _PhoneNumber;
        public long? PhoneNumber { get => _PhoneNumber; set => Set(ref _PhoneNumber, value); }
        private string _Description;
        public string Description { get => _Description; set => Set(ref _Description, value); }
        private bool _IsRoom;
        public bool IsRoom { get => _IsRoom; set => Set(ref _IsRoom, value); }
        private WorkTypeM _WorkType;
        public WorkTypeM WorkType { get => _WorkType; set => SetVm(ref _WorkType, value); }
        private DateTime? _CallDate;
        public DateTime? CallDate { get => _CallDate; set => Set(ref _CallDate, value); }
        private DateTime? _MeetDate;
        public DateTime? MeetDate { get => _MeetDate; set => Set(ref _MeetDate, value); }
        private OrgPersonM _MeetPerson;
        public OrgPersonM MeetPerson { get => _MeetPerson; set => SetVm(ref _MeetPerson, value); }
        private AddressM _Address;
        public AddressM Address { get => _Address; set => SetVm(ref _Address, value); }
        private int? _Room;
        public int? Room { get => _Room; set => Set(ref _Room, value); }
        private int? _Floor;
        public int? Floor { get => _Floor; set => Set(ref _Floor, value); }
        private string _Porch;
        public string Porch { get => _Porch; set => Set(ref _Porch, value); }


        private int _DisconnectsCount;
        public int DisconnectsCount { get => _DisconnectsCount; set => Set(ref _DisconnectsCount, value); }
        private int _CallsCount;
        public int CallsCount { get => _CallsCount; set => Set(ref _CallsCount, value); }
        private int? _PaperCount;
        public int? PaperCount { get => _PaperCount; set => Set(ref _PaperCount, value); }
        private int? _LastPaper;
        public int? LastPaper { get => _LastPaper; set => Set(ref _LastPaper, value); }
        private int? _LastСontribution;
        public int? LastСontribution { get => _LastСontribution; set => Set(ref _LastСontribution, value); }
        public override string DisplayMember => Name;
    }
}
