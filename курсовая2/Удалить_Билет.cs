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
    public partial class Удалить_Билет : Form
    {
        public string s1;
        public NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id="+ Authorized_user.name + "; Password=English56; Database=Zhd_vokzal");
        public Удалить_Билет()
        {
            InitializeComponent();
            DataTable dt = new DataTable();

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.bilet_predstav order by bilet_id asc", conn);

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

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.bilet_predstav order by bilet_id asc", conn);

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();

                conn.Open();
                DataGridViewCell cell_id = dataGridView1.Rows[Convert.ToInt32(s1)].Cells[0];
                Console.WriteLine(s1);
                Console.WriteLine(cell_id.Value);
                //Thread.Sleep(100000);
                NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.delete_bilet_by_id(" + cell_id.Value + ");", conn);

                NpgsqlDataReader reader = cmd.ExecuteReader();
                cmd.Dispose();
                
            } catch (Npgsql.PostgresException ex) { }
            conn.Close();
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            s1 = e.RowIndex.ToString();
        }
    }
}
