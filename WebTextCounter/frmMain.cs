﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebTextCounter.Service;

namespace TextCounter
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            var textCounter = new WebTextCounterService();
            grdTextCounter.DataSource = textCounter.GetData(edtWebAddress.Text);
        }
    }
}
