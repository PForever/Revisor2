using FilterLibrary;
using FilterLibrary.FilterHelp;
using FilterLibrary.SortableBindingList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SystemHelpers;

namespace WinFormsView.Help
{
    public static class WinFormsHelper
    {
        public static DataGridViewColumn[] CreateColumns<T>(params BindingSource[] sourses)
        {
            var s = sourses.ToDictionary(s => s.DataSource.GetType().GetGenericArguments()[0]);
            return (from p in typeof(T).GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)
            where p.GetCustomAttributes(typeof(NonDisplayAttribute), false).Length == 0
            let displayName = (p.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault() as DisplayNameAttribute)?.Name ?? p.Name
            select p.PropertyType switch
            {
                var t when t == typeof(bool) || t == typeof(bool?) =>  (DataGridViewColumn)CreateCheckBoxColumn(p.Name, displayName),
                var t when t.IsSimleType() || !s.ContainsKey(p.PropertyType) => CreateTextColumn(p.Name, displayName),
                _ => CreateComboBoxColumn(p.Name, displayName, s[p.PropertyType])
            }).ToArray();
        }
        public static DataGridViewTextBoxColumn CreateTextColumn(string propertyName, string displayName, bool readOnly = true, DataGridViewAutoSizeColumnMode autoSizeMode = DataGridViewAutoSizeColumnMode.AllCells)
        {
            return new DataGridViewTextBoxColumn()
            {
                Name = propertyName,
                HeaderText = displayName,
                DataPropertyName = propertyName,
                AutoSizeMode = autoSizeMode,
                ReadOnly = readOnly,
            };
        }
        public static DataGridViewCheckBoxColumn CreateCheckBoxColumn(string propertyName, string displayName, bool readOnly = true, DataGridViewAutoSizeColumnMode autoSizeMode = DataGridViewAutoSizeColumnMode.AllCells)
        {
            return new DataGridViewCheckBoxColumn()
            {
                Name = propertyName,
                HeaderText = displayName,
                DataPropertyName = propertyName,
                AutoSizeMode = autoSizeMode,
                ReadOnly = readOnly,
            };
        }
        public static DataGridViewComboBoxColumn CreateComboBoxColumn(string propertyName, string displayName, object dataSource, bool readOnly = true, DataGridViewAutoSizeColumnMode autoSizeMode = DataGridViewAutoSizeColumnMode.AllCells)
        {
            return new DataGridViewComboBoxColumn()
            {
                Name = propertyName,
                HeaderText = displayName,
                DataPropertyName = propertyName,
                AutoSizeMode = autoSizeMode,
                ReadOnly = readOnly,
                DataSource = dataSource,
            };
        }
        //public static DataGridViewComboBoxColumn CreateCheckBoxColumn(string propertyName, string displayName, object dataSource, string displayMember = "Name", string valueMember = "Id", bool readOnly = true, DataGridViewAutoSizeColumnMode autoSizeMode = DataGridViewAutoSizeColumnMode.AllCells)
        //{
        //    return new DataGridViewComboBoxColumn()
        //    {
        //        Name = propertyName,
        //        HeaderText = displayName,
        //        DataPropertyName = propertyName,
        //        DisplayMember = displayMember,
        //        ValueMember = valueMember,
        //        AutoSizeMode = autoSizeMode,
        //        ReadOnly = readOnly,
        //        DataSource = dataSource,
        //    };
        //}
        public static void OpenFilterEdit(IDynamicFiltrable list, PropertiesFilter filter)
        {
            if (filter == null) return;
            var filterEditor = new FilterEditor(filter);
            switch (filterEditor.ShowDialog())
            {
                case DialogResult.OK:
                    list.ApplyFilter(filter);
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    list.RemoveFilter();
                    break;
            }
        }
        public static SortableBindingList<T> ToSortableBindingList<T>(this IList<T> src) => new SortableBindingList<T>(src);
        public static SortableBindingList<T> ToSortableBindingList<T>(this IEnumerable<T> src) => new SortableBindingList<T>(src.ToList());
        public static void SetSeleted<T>(this DataGridView dgv, T data, Func<T, T, bool> comparer)
        {
            var row = dgv.Rows.Cast<DataGridViewRow>().First(r => comparer((T)r.DataBoundItem, data));
            row.Selected = true;
        }
        public static void SetSeleted<T>(this DataGridView dgv, T data) where T : IEquatable<T>
        {
            var row = dgv.Rows.Cast<DataGridViewRow>().First(r => data.Equals((IEquatable<T>)r.DataBoundItem));
            row.Selected = true;
        }
        //public static Binding GetBinding(string propertyName, object dataSource, string dataMember, object @default)
        //{
        //    var binding = new Binding(propertyName, dataSource, dataMember, true);
        //    var provider = new BindingProvider(@default);
        //    binding.Format += provider.OnFormat;
        //    binding.Parse += provider.OnParse;
        //    return binding;
        //}

        public static void SetNullubleBinding(this Control control, string propertyName, object dataSource, string dataMember, object defaultMember)
        {
            var binding = new Binding(propertyName, dataSource, dataMember);
            control.DataBindings.Add(binding);
            var provider = new BindingProvider(defaultMember);
            binding.Format += provider.OnFormat;
            binding.Parse += provider.OnParse;
        }

        public static void SetNullubleBinding(this Control control, string propertyName, object dataSource, object defaultMember)
        {
            var binding = new Binding(propertyName, dataSource, "");
            control.DataBindings.Add(binding);
            var provider = new BindingProvider(defaultMember);
            binding.Format += provider.OnFormat;
            binding.Parse += provider.OnParse;
        }

        class BindingProvider
        {
            private object _defatultMember;
            public BindingProvider(object defatultMember)
            {
                _defatultMember = defatultMember;
            }

            public void OnParse(object sender, ConvertEventArgs e)
            {
                if (e.Value != null && e.Value.Equals(_defatultMember)) e.Value = null;
            }

            public void OnFormat(object sender, ConvertEventArgs e)
            {
                //if (e.Value != null && e.Value.Equals(_defatultMember)) e.Value = null;
                if (e.Value == null) e.Value = _defatultMember;
            }
        }
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
