using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace курсовая2
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (textBox1.Text.Equals("postgres") && textBox2.Text.Equals("English56"))
            {
                this.Hide();
                Form1 frm = new Form1(textBox1.Text, textBox2.Text);
                frm.ShowDialog();
            } else
            {
                MessageBox.Show("Неверные данные");
            }
        }
    }
}
