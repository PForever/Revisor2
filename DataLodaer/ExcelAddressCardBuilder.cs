using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DataLodaer
{
    class ExcelAddressCardBuilder
    {
        private readonly ExcelWorksheet _worksSheet;
        private static readonly int ColumntCount = 17;
        private int _index = 1;
        private readonly CellInfo[] _previously = new CellInfo[ColumntCount];
        private readonly Dictionary<(int Column, int Row), int> _mergeRanges = new();

        public ExcelAddressCardBuilder(ExcelWorksheet worksSheet)
        {
            _worksSheet = worksSheet;
        }
        public void AddAddress(string header)
        {
            _index++;
            var renge = _worksSheet.Cells[_index, 1, _index, ColumntCount];
            renge.Merge = true;
            renge.Value = header;
            _index++;
        }

        public void AddHeaders(DateTime currentMonth)
        {
            var month1 = currentMonth.AddMonths(-7).ToString("MMM");
            var month2 = currentMonth.AddMonths(-6).ToString("MMM");
            var month3 = currentMonth.AddMonths(-5).ToString("MMM");
            var month4 = currentMonth.AddMonths(-4).ToString("MMM");
            var month5 = currentMonth.AddMonths(-3).ToString("MMM");
            var month6 = currentMonth.AddMonths(-2).ToString("MMM");
            var month7 = currentMonth.AddMonths(-1).ToString("MMM");
            var month8 = currentMonth.ToString("MMM");
            Append(new CellInfo[] {
                new("Парадная"), new("Этаж"), new("Квартира"), new("Имя"), new("Возраст"), new("Соц.п."),
                new(month1), new(month2), new(month3), new(month4), new(month5), new(month6), new(month7), new(month8),
                new("Телефон"), new("ПИ"), new("Комментарий", isAutoFit: false, width: 80)});
        }
        public void AddPerson(PersonInRooms person)
        {
            Append(new CellInfo[] { 
                new(person.Porch, true),
                new(person.Floor.ToString(), true),
                new(person.Room.ToString(), true),
                new(person.Name),
                new(person.Age?.ToString()),
                new(person.SosialStatus),
                new(person.Contribution1),
                new(person.Contribution2),
                new(person.Contribution3),
                new(person.Contribution4),
                new(person.Contribution5),
                new(person.Contribution6),
                new(person.Contribution7),
                new(person.Contribution8),
                new(person.PhoneNumber?.ToString("+7(000)000-00-00")),
                new(person.LastPaper?.ToString()),
                new(person.Discription, isAutoFit: false, wrapText: true),
            });
        }

        private void Append(CellInfo[] cellInfos)
        {
            if (cellInfos.Length != ColumntCount) throw new ArgumentOutOfRangeException($"array must have length equals to {ColumntCount}");
            for (int i = 0; i < ColumntCount; i++)
            {
                int columnIndex = i + 1;
                var cell = _worksSheet.Cells[_index, columnIndex];
                cell.Value = cellInfos[i].Value;
                cell.Style.WrapText = cellInfos[i].WrapText;
                if (cellInfos[i].IsAutoFit) _worksSheet.Column(columnIndex).AutoFit();//cell.AutoFitColumns();
                if (cellInfos[i].Width.HasValue) _worksSheet.Column(columnIndex).Width = cellInfos[i].Width.Value;
                if (cellInfos[i].IsMerge && _previously[i].IsMerge && cellInfos[i].Value == _previously[i].Value)
                {
                    var key = (columnIndex, _index - 1);
                    if(_mergeRanges.ContainsKey(key))
                    {
                        var len = _mergeRanges[key];
                        _mergeRanges.Remove(key);
                        _mergeRanges.Add((columnIndex, _index), len + 1);
                    }
                    else
                    {
                        _mergeRanges.Add((columnIndex, _index), 1);
                    }
                    //if(_worksSheet.Cells[_index - 1, columnIndex].Merge)
                    //{
                    //    var idx = _worksSheet.GetMergeCellId(_index - 1, columnIndex);
                    //    _worksSheet.Cells[_worksSheet.MergedCells[idx - 1]].Merge = false;
                    //}
                    //_worksSheet.Cells[_index - 1, columnIndex, _index, columnIndex].Merge = true;
                }
            }

            cellInfos.CopyTo(_previously, 0);
            _index++;
        }
        public void MergeEquals()
        {
            foreach(var knp in _mergeRanges)
            {
                _worksSheet.Cells[knp.Key.Row - knp.Value, knp.Key.Column, knp.Key.Row, knp.Key.Column].Merge = true;
            }
        }
        struct CellInfo
        {
            public string Value;
            public bool IsMerge;
            public bool IsAutoFit;
            public bool WrapText;
            public double? Width;

            public CellInfo(string value, bool isMerge = false, bool isAutoFit = true, bool wrapText = false, double? width = null)
            {
                Value = value;
                IsMerge = isMerge;
                IsAutoFit = isAutoFit;
                WrapText = wrapText;
                Width = width;
            }
        }
    }
}
