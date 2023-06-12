using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using FontAwesome.Sharp;
using Library_Management;
using Library_Management.Forms.DocGia;
using Color = System.Drawing.Color;

namespace Library_Management
{

    public partial class Home : Form
    {

        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        //Constructor
        public Home()
        {
            InitializeComponent();
            customizeDesing();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(24, 217, 170);
        }

        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Icon Current Child Form
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(4, 4, 32);
                currentBtn.ForeColor = Color.FromArgb(240, 236, 233);
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.FromArgb(240, 236, 233);
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;

        }

        private void customizeDesing()
        {
            panelKhoSachSubMenu.Visible = false;
            panelDocGiaSubMenu.Visible = false;
            panelDichVuSubMenu.Visible = false;
            //...
        }

        private void hideSubMenu()
        {
            if (panelKhoSachSubMenu.Visible == true)
                panelKhoSachSubMenu.Visible = false;
            if (panelDocGiaSubMenu.Visible == true)
                panelDocGiaSubMenu.Visible = false;
            if (panelDichVuSubMenu.Visible == true)
                panelDichVuSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }



        private void TrangChu_Click_1(object sender, EventArgs e)
        {

            //...
            hideSubMenu();
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
            ActivateButton(sender, RGBColors.color1);
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.House;
            iconCurrentChildForm.IconColor = Color.FromArgb(24, 217, 170);
            lblTitleChildForm.Text = "Trang chủ";
        }
        private void KhoSach_Click(object sender, EventArgs e)
        {

            showSubMenu(panelKhoSachSubMenu);
            ActivateButton(sender, RGBColors.color1);
           // OpenChildForm(new FormKhoSach());
        }

        #region PanelKhoSach

        private void button12_Click(object sender, EventArgs e)
        {
            OpenChildForm(new dauSach());
            //...
            hideSubMenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Sach());
            //...
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenChildForm(new theLoai());
            //...
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tacGia());
            //...
            hideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new phieuNhapSach());
            //...
            hideSubMenu();
        }
        #endregion

        private void DocGia_Click(object sender, EventArgs e)
        {

            showSubMenu(panelDocGiaSubMenu);
            ActivateButton(sender, RGBColors.color1);
           // OpenChildForm(new FormDocGia());
        }

        #region PanelDocGia
        private void button18_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TheDocGia());
            hideSubMenu();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoaiDocGia());
            hideSubMenu();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhieuThuTien());
            hideSubMenu();
        }

        #endregion

        private void DichVu_Click(object sender, EventArgs e)
        {

            showSubMenu(panelDichVuSubMenu);
            ActivateButton(sender, RGBColors.color1);
            //OpenChildForm(new FormDichVu());
        }

        #region PanelDichVu
        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new muonSach());
            //...
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new traSach());
            //...
            hideSubMenu();
        }


        #endregion

        private void ThongKe_Click(object sender, EventArgs e)
        {

            //...
            hideSubMenu();
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FormThongKe());

        }

        private void TuyChinh_Click(object sender, EventArgs e)
        {

            //...
            hideSubMenu();
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FormTuyChinh());
        }

        private void TroGiup_Click(object sender, EventArgs e)
        {

            //...
            hideSubMenu();
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FormHoTro());
        }

        private Form activeForm = null;


        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
        //    if (WindowState == FormWindowState.Normal)
        //        WindowState = FormWindowState.Maximized;
        //    else
        //        WindowState = FormWindowState.Normal;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Remove transparent border in maximized state
        private void FormMainMenu_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                FormBorderStyle = FormBorderStyle.None;
            else
                FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDichVuSubMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDocGiaSubMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelKhoSachSubMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconCurrentChildForm_Click(object sender, EventArgs e)
        {

        }

        private void panelShadow_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void btn_TraCuu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new traCuu());
            //...
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Sach());
            //...
            hideSubMenu();
        }
    }



    //...

}

