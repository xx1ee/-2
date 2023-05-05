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
    public partial class Form1 : Form
    {
        public string userid;
        public string password;
        public Form1(string userid, string password)
        {
            this.userid = userid;
            this.password = password;
            InitializeComponent();
        }
        
        private void connection()
        {
            DataTable dt = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id="+userid + "; Password="+password+"; Database=Zhd_vokzal");
          
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from vokzal.case_func1();", conn);
            
            NpgsqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            cmd.Dispose();
            conn.Close();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            View view = new View();
            view.ShowDialog();
        }
    }
}
