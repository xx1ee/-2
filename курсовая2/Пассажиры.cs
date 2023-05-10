using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace курсовая2
{
    public partial class Пассажиры : Form
    {
        public NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=English56; Database=Zhd_vokzal");
        public Пассажиры()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Добавить_Пассажира().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Изменить_Пассажира().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Удалить_Пассажира().ShowDialog();
        }
    }
}
