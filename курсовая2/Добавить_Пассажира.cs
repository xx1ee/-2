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
using Npgsql;

namespace курсовая2
{

    public partial class Добавить_Пассажира : Form
    {
        public NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=English56; Database=Zhd_vokzal");
        public string tb1;
        public string tb2;
        public string tb3;
        public string tb4;
        public Добавить_Пассажира()
        {
            InitializeComponent();
            DataTable dt = new DataTable();

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.""Passengers""", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            cmd.Dispose();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            conn.Open();
            
            NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.update_passangers('"+tb1+ "','"+tb2+ "','"+tb3+"','"+tb4+"');", conn);
           // Console.WriteLine(@"select * from vokzal.update_passangers('" + tb1 + "','" + tb2 + "','" + tb3 + "','" + tb4 + "');");
            //Thread.Sleep(100000);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            cmd.Dispose();

        

            conn.Close();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tb1 = textBox1.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            tb4 = textBox4.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            tb2 = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            tb3 = textBox3.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            NpgsqlCommand cmd1 = new NpgsqlCommand(@"select * from vokzal.""Passengers""", conn);

            NpgsqlDataReader reader1 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader1);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            cmd1.Dispose();
            conn.Close();
        }

        private void Добавить_Пассажира_Load(object sender, EventArgs e)
        {

        }
    }
}
