using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace курсовая2
{
    public partial class Добавить_Маршрут : Form
    {
        public NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=English56; Database=Zhd_vokzal");
        public string tb1;
        public string tb2;
        public string tb3;
        public string tb4;
        public string tb5;
        public Добавить_Маршрут()
        {
            InitializeComponent();
            DataTable dt = new DataTable();

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.""Marshrut""", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            cmd.Dispose();
            conn.Close();
        }
   

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.update_marshrut('" + tb1 + "','" + tb2 + "','" + tb3 + "','" + tb4 + "',"+tb5+");", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();
            cmd.Dispose();



            conn.Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            tb1 = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            tb2 = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            tb3 = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            tb4 = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            tb5 = textBox5.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            NpgsqlCommand cmd1 = new NpgsqlCommand(@"select * from vokzal.""Marshrut""", conn);

            NpgsqlDataReader reader1 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader1);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            cmd1.Dispose();
            conn.Close();
        }
    }
}
