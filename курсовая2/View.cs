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
    public partial class View : Form

    {
        public List<string> data = new List<string>();
        public List<string> data_new = new List<string>();
        public NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=English56; Database=Zhd_vokzal");
        public View()
        {
            InitializeComponent();
            
                
            DataTable dt = new DataTable();

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from vokzal.predstav", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            cmd.Dispose();
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                string s = "";
                foreach (DataGridViewCell Cell in Row.Cells)
                {
                    s += Cell.Value;
                    s += " ";
                }
                data.Add(s.Trim());
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            data_new = new List<string>();
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                string s = "";
                foreach (DataGridViewCell Cell in Row.Cells)
                {
                    s += Cell.Value;
                    s += " ";
                }
                data_new.Add(s.Trim());
            }
            for (int i = 0; i < data_new.Count; i++)
            {
                string[] novoe = data_new[i].Trim().Split(' ');
                string[] old = data[i].Split(' ');
                if (novoe.Length >= 2 && old.Length >= 2)
                {
                    if (!novoe[2].Equals(old[2]))
                    {
                        conn.Open();
                        string zapros1 = "select vokzal.update_put_predstav('" + novoe[2] + "', '" + old[2] + "', "+novoe[1]+")";
                        Console.WriteLine(zapros1);
                        NpgsqlCommand cmd = new NpgsqlCommand(zapros1, conn);
                        cmd.ExecuteReader();
                        Thread.Sleep(1000);
                        conn.Close();
                        cmd.Dispose();
                        conn.Open();
                        NpgsqlCommand cmd1 = new NpgsqlCommand("select * from vokzal.predstav", conn);
                        NpgsqlDataReader reader = cmd1.ExecuteReader();
                        Thread.Sleep(1000);
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                        cmd1.Dispose();
                    }
                    if (!novoe[3].Equals(old[3]))
                    {
                        conn.Open();
                        string zapros1 = "select vokzal.update_train_predstav('" + novoe[3] + "', '" + old[3] + "')";
                        Console.WriteLine(zapros1);
                        NpgsqlCommand cmd = new NpgsqlCommand(zapros1, conn);
                        cmd.ExecuteReader();
                        Thread.Sleep(1000);
                        conn.Close();
                        cmd.Dispose();
                        conn.Open();
                        NpgsqlCommand cmd1 = new NpgsqlCommand("select * from vokzal.predstav", conn);
                        NpgsqlDataReader reader = cmd1.ExecuteReader();
                        Thread.Sleep(1000);
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                        cmd1.Dispose();
                    }
                    if (!novoe[4].Equals(old[4]))
                    {
                        conn.Open();
                        string zapros1 = "select vokzal.update_wagon_predstav('" + novoe[4] + "', '" + novoe[0] + "')";
                        Console.WriteLine(zapros1);
                        NpgsqlCommand cmd = new NpgsqlCommand(zapros1, conn);
                        cmd.ExecuteReader();
                        Thread.Sleep(1000);
                        conn.Close();
                        cmd.Dispose();
                        conn.Open();
                        NpgsqlCommand cmd1 = new NpgsqlCommand("select * from vokzal.predstav", conn);
                        NpgsqlDataReader reader = cmd1.ExecuteReader();
                        Thread.Sleep(1000);
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                        cmd1.Dispose();
                    }
                    if (!novoe[5].Equals(old[5]))
                    {
                        conn.Open();
                        string zapros1 = "select vokzal.update_place_predstav('" + novoe[5] + "', '" + novoe[0] + "')";
                        Console.WriteLine(zapros1);
                        NpgsqlCommand cmd = new NpgsqlCommand(zapros1, conn);
                        cmd.ExecuteReader();
                        Thread.Sleep(1000);
                        conn.Close();
                        cmd.Dispose();
                        conn.Open();
                        NpgsqlCommand cmd1 = new NpgsqlCommand("select * from vokzal.predstav", conn);
                        NpgsqlDataReader reader = cmd1.ExecuteReader();
                        Thread.Sleep(1000);
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                        cmd1.Dispose();
                    }
                    if (!novoe[6].Equals(old[6]))
                    {
                        conn.Open();
                        string zapros1 = "select vokzal.update_station_otprav_predstav('" + novoe[6] + "', '" + old[6] + "','"+novoe[1]+"')";
                        Console.WriteLine(zapros1);
                        NpgsqlCommand cmd = new NpgsqlCommand(zapros1, conn);
                        cmd.ExecuteReader();
                        Thread.Sleep(1000);
                        conn.Close();
                        cmd.Dispose();
                        conn.Open();
                        NpgsqlCommand cmd1 = new NpgsqlCommand("select * from vokzal.predstav", conn);
                        NpgsqlDataReader reader = cmd1.ExecuteReader();
                        Thread.Sleep(1000);
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                        cmd1.Dispose();
                    }
                    if (!novoe[7].Equals(old[7]))
                    {
                        conn.Open();
                        string zapros1 = "select vokzal.update_station_pribyt_predstav('" + novoe[7] + "', '" + old[7] + "','" + novoe[1] + "')";
                        Console.WriteLine(zapros1);
                        NpgsqlCommand cmd = new NpgsqlCommand(zapros1, conn);
                        cmd.ExecuteReader();
                        Thread.Sleep(1000);
                        conn.Close();
                        cmd.Dispose();
                        conn.Open();
                        NpgsqlCommand cmd1 = new NpgsqlCommand("select * from vokzal.predstav", conn);
                        NpgsqlDataReader reader = cmd1.ExecuteReader();
                        Thread.Sleep(1000);
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                        cmd1.Dispose();
                    }
                }

            }
            data = new List<string>();
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                string s = "";
                foreach (DataGridViewCell Cell in Row.Cells)
                {
                    s += Cell.Value;
                    s += " ";
                }
                data.Add(s.Trim());
            }
        }
    }
}
