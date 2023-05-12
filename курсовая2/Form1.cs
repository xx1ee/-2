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
        public string s1;
        public Form1(string userid, string password)
        {
            this.userid = userid;
            this.password = password;
            InitializeComponent();
        }
        
        private void connection()
        {
            DataTable dt = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id="+Authorized_user.name + "; Password="+ Authorized_user.password + "; Database=Zhd_vokzal");
          
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

        private void button3_Click(object sender, EventArgs e)
        {
            Пассажиры пассажиры = new Пассажиры();
            пассажиры.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Маршруты().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Места().ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Тарифы().ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Билеты().ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=" + Authorized_user.name + "; Password=" + Authorized_user.password + "; Database=Zhd_vokzal");

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from vokzal.korel_podzap2();", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            cmd.Dispose();
            conn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=" + Authorized_user.name + "; Password=" + Authorized_user.password + "; Database=Zhd_vokzal");

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from vokzal.korel_podzap();", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            cmd.Dispose();
            conn.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=" + Authorized_user.name + "; Password=" + Authorized_user.password + "; Database=Zhd_vokzal");

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from vokzal.get_total_price_for_female_passengers();", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            cmd.Dispose();
            conn.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=" + Authorized_user.name + "; Password=" + Authorized_user.password + "; Database=Zhd_vokzal");

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from vokzal.kuda_ehat_dolshe_sutok();", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            cmd.Dispose();
            conn.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=" + Authorized_user.name + "; Password=" + Authorized_user.password + "; Database=Zhd_vokzal");

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select (select count(*) from vokzal.bilet_predstav) as Количество_Билетов,(select sum(Стоимость) from vokzal.bilet_predstav) as Всего_Собрано,(select avg(Стоимость) from vokzal.bilet_predstav) as Средняя_Стоимость_Билета from vokzal.bilet_predstav group by Количество_Билетов; ", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            cmd.Dispose();
            conn.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=" + Authorized_user.name + "; Password=" + Authorized_user.password + "; Database=Zhd_vokzal");

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("call vokzal.cursor_tar()", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            cmd.Dispose();
            conn.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=" + Authorized_user.name + "; Password=" + Authorized_user.password + "; Database=Zhd_vokzal");

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from vokzal.samy_dorogoy_bilet_fio('"+s1+"')", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            cmd.Dispose();
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            s1 = textBox1.Text;
        }
    }
}
