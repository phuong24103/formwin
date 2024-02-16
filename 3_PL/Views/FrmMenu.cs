using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_PL.Views
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
            anMenu();
           // openform();
        }
        private void anMenu()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }
        private void HienMenu()
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
            }
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
            }
            if (panel3.Visible == true)
            {
                panel3.Visible = false;
            }
           
        }
        private void ShowMenu(Panel menu)
        {
            if (menu.Visible == false)
            {
                HienMenu();
                menu.Visible = true;
            }
            else
            {
                menu.Visible = false;
            }
        }
        private Form activeform = null;
        private void openform (Form form)
        {
            if (activeform != null)
                activeform.Close();
            activeform = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            
            form.Show();
        }

        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            ShowMenu(panel1);
        }

        private void btn_khachang_Click(object sender, EventArgs e)
        {
            FromKhachHang fromKhachHang = new FromKhachHang();
            fromKhachHang.ShowDialog();
           // HienMenu();
            //openform( new ); gọi về form
        }

        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            HienMenu();
        }

        private void btn_hoadonct_Click(object sender, EventArgs e)
        {
            HienMenu();
        }

        private void btn_sp_Click(object sender, EventArgs e)
        {
            ShowMenu(panel2);
        }

        private void btn_ms_Click(object sender, EventArgs e)
        {
            FromMauSac fromCuaHang = new FromMauSac();
            fromCuaHang.ShowDialog();
            //HienMenu();
        }

        private void btn_nxs_Click(object sender, EventArgs e)
        {
            FromNSX fromDongSp = new FromNSX();
            fromDongSp.ShowDialog();
            //HienMenu();
        }

        private void btn_dongsp_Click(object sender, EventArgs e)
        {
            FromDongSp fromDongSp = new FromDongSp();
            fromDongSp.ShowDialog();
            //HienMenu();
        }

        private void btn_quanli_Click(object sender, EventArgs e)
        {
            ShowMenu(panel3);
        }

        private void btn_cv_Click(object sender, EventArgs e)
        {
            FromChucVu frmcv = new FromChucVu();
            frmcv.ShowDialog();
            /*HienMenu();
            openform(new FromChucVu());*/ //gọi về form
            //HienMenu();
        }

        private void btn_nhanvien_Click(object sender, EventArgs e)
        {
            FromNhanVien frmcv = new FromNhanVien();
            frmcv.ShowDialog();
            //HienMenu();
        }

        private void btn_cuahang_Click(object sender, EventArgs e)
        {
            FromCuaHang fromCuaHang = new FromCuaHang();
            fromCuaHang.ShowDialog();
            //HienMenu();
        }
    }
}
