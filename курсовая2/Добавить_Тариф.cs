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
    public partial class Добавить_Тариф : Form
    {
        string tb1;
        string tb2;
        string tb3;
        public NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=English56; Database=Zhd_vokzal");
        public Добавить_Тариф()
        {
            InitializeComponent();
            DataTable dt = new DataTable();

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.tarif_predstav", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            cmd.Dispose();
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb3.Trim().Equals("Плацкарт"))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.insert_tarif(" + tb1 + "," + tb2 + ",1);", conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                cmd.Dispose();
                conn.Close();
            }
            if (tb3.Trim().Equals("Купе"))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.insert_tarif(" + tb1 + "," + tb2 + ",2);", conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                cmd.Dispose();
                conn.Close();
            }
            if (tb3.Trim().Equals("СВ"))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.insert_tarif(" + tb1 + "," + tb2 + ",3);", conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                cmd.Dispose();
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.tarif_predstav", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            cmd.Dispose();
            conn.Close();
        }
    }
}
