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
    public partial class muonSach : Form
    {
        public muonSach()
        {
            InitializeComponent();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnXemPhieuMuon_Click(object sender, EventArgs e)
        {
            // hide form 1
            // this.Hide();
            // create an instace of form 2
            DSPhieuMS f2 = new DSPhieuMS();
            // show form 2
            f2.ShowDialog(); // it fonna halt/ freeze the excution of click event.
            // dispose form 2 instance
            f2 = null;
            //show form 1 again
            this.Show();
        }
    }
}
