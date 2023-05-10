using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace курсовая2
{
    public partial class Изменить_Билет : Form
    {
        public NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=English56; Database=Zhd_vokzal");
        public Посмотреть_Маршрут m = new Посмотреть_Маршрут();
        public Посмотреть_Места mesta = new Посмотреть_Места();
        public Посмотреть_Пассажира pass = new Посмотреть_Пассажира();
        public Посмотреть_Тарифы tarif = new Посмотреть_Тарифы();
        string s1;
        public Изменить_Билет()
        {
            InitializeComponent();
            DataTable dt = new DataTable();

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.bilet_predstav", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            cmd.Dispose();
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mesta.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pass.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tarif.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            m.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            s1 = textBox1.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var bil_id = dataGridView1.Rows[Convert.ToInt32(s1) - 1].Cells[0];
            if (mesta.cell_mesto_id != null)
            {
                
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.update_bilet_pl("+ mesta.cell_mesto_id.Value+ ","+bil_id.Value+")", conn);
                Console.WriteLine(@"select * from vokzal.update_bilet_pl(" + mesta.cell_mesto_id.Value + "," + bil_id.Value + ")");
                //Thread.Sleep(100000);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            if (m.cell_marsh_id != null)
            {
                
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.update_bilet_marsh(" + m.cell_marsh_id.Value + "," + bil_id.Value + ")", conn);

                NpgsqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            if (pass.cell_pass_id != null)
            {
              
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.update_bilet_pass(" + pass.cell_pass_id.Value + "," + bil_id.Value + ")", conn);

                NpgsqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            if (tarif.cell_tar_id != null)
            {

                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.update_bilet_tar(" + tarif.cell_tar_id.Value + "," + bil_id.Value + ")", conn);

                NpgsqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.bilet_predstav", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            cmd.Dispose();
            conn.Close();
        }
    }
}
