﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo01_EF
{
    public partial class frmDemo02 : Form
    {
        public frmDemo02()
        {
            InitializeComponent();
        }

        private DataDemoEntities model = new DataDemoEntities();

        private void frmDemo02_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = model.Categories.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDemo02_Edit frm = new frmDemo02_Edit();
            frm.CategoryID = -1;
            frm.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                frmDemo02_Edit frm = new frmDemo02_Edit();
                frm.CategoryID = (dataGridView1.SelectedRows[0].DataBoundItem as Category).CategoryID;
                frm.ShowDialog();
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                model.DeleteObject(dataGridView1.SelectedRows[0].DataBoundItem as Category);
                model.SaveChanges();
                LoadData();
            }
        }
    }
}
