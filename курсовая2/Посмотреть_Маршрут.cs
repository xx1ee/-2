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
    public partial class Посмотреть_Маршрут : Form
    {
        public NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=English56; Database=Zhd_vokzal");
        public string s1 = "";
        public DataGridViewCell cell_marsh_id;
        public Посмотреть_Маршрут()
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            s1 = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            cell_marsh_id = dataGridView1.Rows[Convert.ToInt32(s1) - 1].Cells[0];
            this.Close();
        }
    }
}
