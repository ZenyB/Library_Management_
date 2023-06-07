using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class dauSach : Form
    {
        public dauSach()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dauSach_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // hide form 1
            // this.Hide();
            // create an instace of form 2
            tacGia f2 = new tacGia();
            // show form 2
            f2.ShowDialog(); // it fonna halt/ freeze the excution of click event.
            // dispose form 2 instance
            f2 = null;
            //show form 1 again
            this.Show();
        }
    }
}
