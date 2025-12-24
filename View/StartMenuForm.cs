using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace elephantocracy.View
{
    public partial class StartMenuForm : Form
    {
        private bool IsWASD = true;

        public StartMenuForm()
        {
            InitializeComponent();
        }

        private void btn1LVL_Click(object sender, EventArgs e)
        {
            var LVL = new GameForm(1, IsWASD);
            LVL.Show();
            this.Hide();
        }
        private void btn2LVL_Click(object sender, EventArgs e)
        {
            var LVL = new GameForm(2, IsWASD);
            LVL.Show();
            this.Hide();
        }

        private void btn3LVL_Click(object sender, EventArgs e)
        {
            var LVL = new GameForm(3, IsWASD);
            LVL.Show();
            this.Hide();
        }

        private void StartMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cbIsWASD_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbIsWASD.Checked) IsWASD = true;
            else IsWASD = false;
        }
    }
}
