﻿using Revisor2.Model.Models;
using Revisor2.Model.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsView.Cards
{
    public partial class BypassCard : Form
    {
        public BypassCard(BypassM model, AddressM address, AddressesRepository repository)
        {
            InitializeComponent();
        }
    }
}