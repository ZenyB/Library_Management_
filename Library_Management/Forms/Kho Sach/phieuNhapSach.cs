using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class phieuNhapSach : Form
    {
       // Thread th;
        public phieuNhapSach()
        {
            InitializeComponent();
        }

        private void phieuNhapSach_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void thongTinPN_Click(object sender, EventArgs e)
        {

        }


        private void btnLuu_MouseHover(object sender, EventArgs e)
        {
           // btnLuu.BackColor = Color.FromArgb(79, 224, 181);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // hide form 1
            // this.Hide();
            // create an instace of form 2
            chiTietPNS f2 = new chiTietPNS();
            // show form 2
            f2.ShowDialog(); // it fonna halt/ freeze the excution of click event.
            // dispose form 2 instance
            f2 = null;
            //show form 1 again
            this.Show();        
        }

    

    }
}
