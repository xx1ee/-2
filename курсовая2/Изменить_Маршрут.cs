using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace курсовая2
{
    public partial class Изменить_Маршрут : Form
    {
        public List<string> data = new List<string>();
        public List<string> data_new = new List<string>();
        public NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=English56; Database=Zhd_vokzal");
        public Изменить_Маршрут()
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
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                string s = "";
                foreach (DataGridViewCell Cell in Row.Cells)
                {
                    Console.WriteLine(Cell.Value);
                    if (Cell.Value != null)
                    {
                        Match match = Regex.Match(Cell.Value.ToString(), "\\d{2}\\.\\d{2}\\.\\d{4} \\d{1,2}:\\d{2}:\\d{2}");
                        if (match.Success)
                        {
                            Console.WriteLine(Cell.Value);
                            string rep = Cell.Value.ToString().Trim().Replace(" ", "_");
                            Console.WriteLine(rep);
                            s += rep.Trim();
                            s += " ";
                        }
                        else
                        {
                            s += Cell.Value;
                            s += " ";
                        }
                    }


                }
                //Thread.Sleep(100000);
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
                    Console.WriteLine(Cell.Value);
                    if (Cell.Value != null)
                    {
                        Match match = Regex.Match(Cell.Value.ToString(), "\\d{2}\\.\\d{2}\\.\\d{4} \\d{1,2}:\\d{2}:\\d{2}");
                        if (match.Success)
                        {
                            Console.WriteLine(Cell.Value);
                            string rep = Cell.Value.ToString().Trim().Replace(" ", "_");
                            Console.WriteLine(rep);
                            //Thread.Sleep(100000);
                            s += rep.Trim();
                            s += " ";
                        }
                        else
                        {
                            s += Cell.Value;
                            s += " ";
                        }
                    }
                    Console.WriteLine(s);
                    
                }
                data_new.Add(s.Trim());
            }
            //Thread.Sleep(100000);
            for (int i = 0; i < data_new.Count; i++)
            {
                Console.WriteLine(data_new[i]);
                string[] novoe = data_new[i].Trim().Split(' ');
                string[] old = data[i].Trim().Split(' ');
                if (novoe.Length >= 2 && old.Length >= 2)
                {
                    if (!novoe[1].Equals(old[1]))
                    {
                        conn.Open();
                        string zapros1 = "select vokzal.update_marshrut_time_otprav('" + novoe[1].Replace("_", " ") + "', '" + novoe[0] + "')";
                        Console.WriteLine(zapros1);
                        NpgsqlCommand cmd = new NpgsqlCommand(zapros1, conn);
                        cmd.ExecuteReader();
                        //Thread.Sleep(1000);
                        conn.Close();
                        cmd.Dispose();
                        conn.Open();
                        NpgsqlCommand cmd1 = new NpgsqlCommand(@"select * from vokzal.""Marshrut""", conn);
                        NpgsqlDataReader reader = cmd1.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[0].Visible = false;
                        conn.Close();
                        cmd1.Dispose();
                    }
                    if (!novoe[2].Equals(old[2]))
                    {
                        conn.Open();
                        string zapros1 = "select vokzal.update_marshrut_time_pribyt('" + novoe[2].Replace("_", " ") + "', '" + novoe[0] + "')";
                        Console.WriteLine(zapros1);
                        NpgsqlCommand cmd = new NpgsqlCommand(zapros1, conn);
                        cmd.ExecuteReader();
                        //Thread.Sleep(1000);
                        conn.Close();
                        cmd.Dispose();
                        conn.Open();
                        NpgsqlCommand cmd1 = new NpgsqlCommand(@"select * from vokzal.""Marshrut""", conn);
                        NpgsqlDataReader reader = cmd1.ExecuteReader();

                        DataTable dt = new DataTable();
                        dataGridView1.Columns[0].Visible = false;
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                        cmd1.Dispose();
                    }
                    if (!novoe[3].Equals(old[3]))
                    {
                        conn.Open();
                        string zapros1 = "select vokzal.update_marshrut_station_otprav('" + novoe[3] + "', '" + novoe[0] + "')";
                        Console.WriteLine(zapros1);
                        //Thread.Sleep(100000);
                        NpgsqlCommand cmd = new NpgsqlCommand(zapros1, conn);
                        cmd.ExecuteReader();
                        //Thread.Sleep(1000);
                        conn.Close();
                        cmd.Dispose();
                        conn.Open();
                        NpgsqlCommand cmd1 = new NpgsqlCommand(@"select * from vokzal.""Marshrut""", conn);
                        NpgsqlDataReader reader = cmd1.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[0].Visible = false;
                        conn.Close();
                        cmd1.Dispose();
                    }
                    if (!novoe[4].Equals(old[4]))
                    {
                        conn.Open();
                        string zapros1 = "select vokzal.update_marshrut_station_pribyt('" + novoe[4] + "', '" + novoe[0] + "')";
                        Console.WriteLine(zapros1);
                        //Thread.Sleep(100000);
                        NpgsqlCommand cmd = new NpgsqlCommand(zapros1, conn);
                        cmd.ExecuteReader();
                        //Thread.Sleep(1000);
                        conn.Close();
                        cmd.Dispose();
                        conn.Open();
                        NpgsqlCommand cmd1 = new NpgsqlCommand(@"select * from vokzal.""Marshrut""", conn);
                        NpgsqlDataReader reader = cmd1.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[0].Visible = false;
                        conn.Close();
                        cmd1.Dispose();
                    }
                    if (!novoe[5].Equals(old[5]))
                    {
                        conn.Open();
                        string zapros1 = "select vokzal.update_marshrut_put(" + novoe[5] + ", '" + novoe[0] + "')";
                        Console.WriteLine(zapros1);
                        //Thread.Sleep(100000);
                        NpgsqlCommand cmd = new NpgsqlCommand(zapros1, conn);
                        cmd.ExecuteReader();
                        //Thread.Sleep(1000);
                        conn.Close();
                        cmd.Dispose();
                        conn.Open();
                        NpgsqlCommand cmd1 = new NpgsqlCommand(@"select * from vokzal.""Marshrut""", conn);
                        NpgsqlDataReader reader = cmd1.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[0].Visible = false;
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
                    Console.WriteLine(Cell.Value);
                    if (Cell.Value != null)
                    {
                        Match match = Regex.Match(Cell.Value.ToString(), "\\d{2}\\.\\d{2}\\.\\d{4} \\d{1,2}:\\d{2}:\\d{2}");
                        if (match.Success)
                        {
                            Console.WriteLine(Cell.Value);
                            string rep = Cell.Value.ToString().Trim().Replace(" ", "_");
                            Console.WriteLine(rep);
                            s += rep.Trim();
                            s += " ";
                        }
                        else
                        {
                            s += Cell.Value;
                            s += " ";
                        }
                    }
                }
                data.Add(s.Trim());
            }
        }
    }
    
}
