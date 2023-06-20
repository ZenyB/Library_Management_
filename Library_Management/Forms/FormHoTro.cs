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
    public partial class FormHoTro : Form
    {
        public FormHoTro()
        {
            InitializeComponent();
        }

        private void btn_GuiHT_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng đang phát triển...", "Comming Soon");
        }

        private void btnLienHe1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ với mình qua email: 21520129@gm.uit.edu.vn", "Như Ý nè");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ với mình qua email: 21520404@gm.uit.edu.vn", "Phước nè");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ với mình qua email: 21521551@gm.uit.edu.vn", "Toàn nè");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ với mình qua email: 21522175@gm.uit.edu.vn", "Huyền nè");
        }
    }
}
