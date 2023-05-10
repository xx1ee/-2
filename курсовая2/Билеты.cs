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
    public partial class Билеты : Form
    {
        public Билеты()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Добавить_Билет().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Изменить_Билет().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Удалить_Билет().ShowDialog();
        }
    }
}
