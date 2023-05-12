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
    public partial class Изменить_Пассажира : Form
    {
        public List<string> data = new List<string>();
        public List<string> data_new = new List<string>();
        public NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id="+ Authorized_user.name + "; Password=English56; Database=Zhd_vokzal");
        public Изменить_Пассажира()
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
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                string s = "";
                foreach (DataGridViewCell Cell in Row.Cells)
                {
                    Console.WriteLine(Cell.Value);
                    if (Cell.Value != null)
                    {
                        if (Cell.Value.ToString().Contains("0:00:00"))
                        {
                            Console.WriteLine(Cell.Value);
                            string rep = Cell.Value.ToString().Substring(0, Cell.Value.ToString().Length - 8);
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
            try
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
                            if (Cell.Value.ToString().Contains("0:00:00"))
                            {
                                Console.WriteLine(Cell.Value);
                                string rep = Cell.Value.ToString().Substring(0, Cell.Value.ToString().Length - 8);
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
                    data_new.Add(s.Trim());
                }
                for (int i = 0; i < data_new.Count; i++)
                {
                    string[] novoe = data_new[i].Trim().Split(' ');
                    string[] old = data[i].Trim().Split(' ');
                    if (novoe.Length >= 2 && old.Length >= 2)
                    {
                        if (!novoe[1].Equals(old[1]))
                        {
                            conn.Open();
                            string zapros1 = "select vokzal.update_passengers_fio('" + novoe[1] + "', '" + novoe[0] + "')";
                            Console.WriteLine(zapros1);
                            NpgsqlCommand cmd = new NpgsqlCommand(zapros1, conn);
                            cmd.ExecuteReader();
                            //Thread.Sleep(1000);
                            conn.Close();
                            cmd.Dispose();
                            conn.Open();
                            NpgsqlCommand cmd1 = new NpgsqlCommand(@"select * from vokzal.""Passengers""", conn);
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
                            string rozhdeniye = novoe[2];
                            Console.WriteLine(rozhdeniye);
                            string zapros1 = "select vokzal.update_passengers_birth('" + rozhdeniye + "', '" + novoe[0] + "')";
                            Console.WriteLine(zapros1);
                            //Thread.Sleep(100000);
                            NpgsqlCommand cmd = new NpgsqlCommand(zapros1, conn);
                            cmd.ExecuteReader();
                            //Thread.Sleep(1000);
                            conn.Close();
                            cmd.Dispose();
                            conn.Open();
                            NpgsqlCommand cmd1 = new NpgsqlCommand(@"select * from vokzal.""Passengers""", conn);
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
                            string zapros1 = "select vokzal.update_passengers_passport('" + novoe[3] + "', '" + novoe[0] + "')";
                            Console.WriteLine(zapros1);
                            //Thread.Sleep(100000);
                            NpgsqlCommand cmd = new NpgsqlCommand(zapros1, conn);
                            cmd.ExecuteReader();
                            //Thread.Sleep(1000);
                            conn.Close();
                            cmd.Dispose();
                            conn.Open();
                            NpgsqlCommand cmd1 = new NpgsqlCommand(@"select * from vokzal.""Passengers""", conn);
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
                            string zapros1 = "select vokzal.update_passengers_pol('" + novoe[4] + "', '" + novoe[0] + "')";
                            Console.WriteLine(zapros1);
                            //Thread.Sleep(100000);
                            NpgsqlCommand cmd = new NpgsqlCommand(zapros1, conn);
                            cmd.ExecuteReader();
                            //Thread.Sleep(1000);
                            conn.Close();
                            cmd.Dispose();
                            conn.Open();
                            NpgsqlCommand cmd1 = new NpgsqlCommand(@"select * from vokzal.""Passengers""", conn);
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
                            if (Cell.Value.ToString().Contains("0:00:00"))
                            {
                                Console.WriteLine(Cell.Value);
                                string rep = Cell.Value.ToString().Substring(0, Cell.Value.ToString().Length - 8);
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
            } catch(Npgsql.PostgresException ex) { conn.Close(); }
            
        }
    }
}
