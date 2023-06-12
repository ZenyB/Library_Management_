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
    public partial class traSach : Form
    {
        public traSach()
        {
            InitializeComponent();
        }

        private void btnXemPhieuTra_Click(object sender, EventArgs e)
        {
            // hide form 1
            // this.Hide();
            // create an instace of form 2
            DSPhieuTS f2 = new DSPhieuTS();
            // show form 2
            f2.ShowDialog(); // it fonna halt/ freeze the excution of click event.
            // dispose form 2 instance
            f2 = null;
            //show form 1 again
            this.Show();
        }
    }
}
