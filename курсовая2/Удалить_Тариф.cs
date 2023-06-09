﻿using Npgsql;
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
    public partial class Удалить_Тариф : Form
    {
        public string s1;
        public NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=English56; Database=Zhd_vokzal");
        public Удалить_Тариф()
        {
            InitializeComponent();
            DataTable dt = new DataTable();

            conn.Open();
          
            NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.tarif_predstav order by tar_id asc", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
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
                NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.delete_tar_by_id(" + cell_id.Value + ");", conn);

                NpgsqlDataReader reader = cmd.ExecuteReader();
                cmd.Dispose();
                conn.Close();
            } catch (Npgsql.PostgresException ex) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(@"select * from vokzal.tarif_predstav order by tar_id asc", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            cmd.Dispose();
            conn.Close();
        }

     

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            s1 = e.RowIndex.ToString();
            Console.WriteLine(s1);
        }
    }
}
