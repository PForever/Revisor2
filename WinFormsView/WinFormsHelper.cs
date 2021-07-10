using FilterLibrary;
using FilterLibrary.FilterHelp;
using FilterLibrary.SortableBindingList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinFormsView;

namespace WinFormsView
{
    public static class WinFormsHelper
    {
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
