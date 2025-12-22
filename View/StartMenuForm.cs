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
        public StartMenuForm()
        {
            InitializeComponent();
        }

        private void btn1LVL_Click(object sender, EventArgs e)
        {
            var LVL = new GameForm(1);
            LVL.Show();
            this.Hide();
        }
        private void btn2LVL_Click(object sender, EventArgs e)
        {
            var LVL = new GameForm(2);
            LVL.Show();
            this.Hide();
        }

        private void btn3LVL_Click(object sender, EventArgs e)
        {
            var LVL = new GameForm(3);
            LVL.Show();
            this.Hide();
        }

        private void StartMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
