using _2_BUS.IServices;
using _2_BUS.Services;
using _2_BUS.ViewModels;
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
    public partial class FromKhachHang : Form
    {
        IKhachHangServices _khachHangServices;
        Guid _CurentID; 
        public FromKhachHang()
        {
            _khachHangServices = new KhachHangServices();
            InitializeComponent();
        }
        private void LoadDataGrid()
        {
            int stt = 1;
            dtg_khachhang.Rows.Clear();
            dtg_khachhang.ColumnCount = 12;
            dtg_khachhang.Columns[0].Name = "ID";
            dtg_khachhang.Columns[0].Visible = false;
            dtg_khachhang.Columns[1].Name = "STT";
            dtg_khachhang.Columns[2].Name = "Mã";
            dtg_khachhang.Columns[3].Name = "Tên";
            dtg_khachhang.Columns[4].Name = "Tên đệm";
            dtg_khachhang.Columns[5].Name = "Họ";
            dtg_khachhang.Columns[6].Name = "Địa chỉ";
            dtg_khachhang.Columns[7].Name = "Ngày sinh";
            dtg_khachhang.Columns[8].Name = "Sdt";
            dtg_khachhang.Columns[9].Name = "thành phố";
            dtg_khachhang.Columns[10].Name = "QUốc gia";
            dtg_khachhang.Columns[11].Name = "Mật khẩu";
            foreach (var item in _khachHangServices.GetAll())
            {
                dtg_khachhang.Rows.Add(item.Id, stt++, item.Ma, item.Ten, item.TenDem, item.Ho,item.DiaChi, item.NgaySinh, item.Sdt, item.ThanhPho, item.QuocGia, item.MatKhau);

            }

        }

        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            KhachHangView khachHangView = new KhachHangView()
            {
                Id = new Guid(),
                Ma = tb_makh.Text,
                Ten = tb_ten.Text,
                TenDem = tb_tendem.Text,
                Ho = tb_ho.Text,
                NgaySinh = dtp_ns.Value,
                Sdt = tb_sdt.Text,
                DiaChi = tb_dc.Text,
                ThanhPho = tb_tp.Text,
                QuocGia = tb_qg.Text,
                MatKhau = tb_mk.Text,


            };
            DialogResult dg = MessageBox.Show("Bạn có muốn thêm không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_khachHangServices.Add(khachHangView));
                LoadDataGrid();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            KhachHangView khachHangView = new KhachHangView()
            {
                Id = _CurentID,
                Ma = tb_makh.Text,
                Ten = tb_ten.Text,
                TenDem = tb_tendem.Text,
                Ho = tb_ho.Text,
               NgaySinh = dtp_ns.Value,
                Sdt = tb_sdt.Text,
                DiaChi = tb_dc.Text,
                ThanhPho = tb_tp.Text,
                QuocGia = tb_qg.Text,
                MatKhau = tb_mk.Text,

            };
            DialogResult dg = MessageBox.Show("Bạn có muốn sửa khoogn?", "thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_khachHangServices.Update(khachHangView));
                LoadDataGrid();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn xóa không","thông báo",MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_khachHangServices.Delete(_CurentID));
                LoadDataGrid();
            }
        }

        private void dtg_khachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _CurentID = (Guid)(dtg_khachhang.CurrentRow.Cells[0].Value);
            tb_makh.Text = dtg_khachhang.CurrentRow.Cells[2].Value.ToString();
            tb_ten.Text = dtg_khachhang.CurrentRow.Cells[3].Value.ToString();
            tb_tendem.Text = dtg_khachhang.CurrentRow.Cells[4].Value.ToString();
            tb_ho.Text = dtg_khachhang.CurrentRow.Cells[5].Value.ToString();
            dtp_ns.Text = dtg_khachhang.CurrentRow.Cells[7].Value.ToString();
  /*          DateTime dateTimeValue = (DateTime)dtg_khachhang.CurrentRow.Cells[5].Value;
            string formattedDateTime = dateTimeValue.ToString("mm/dd/yyyy HH:mm:ss");
            dtp_ns.Text = formattedDateTime;*/
            tb_sdt.Text = dtg_khachhang.CurrentRow.Cells[8].Value.ToString();
            tb_dc.Text = dtg_khachhang.CurrentRow.Cells[6].Value.ToString();
            tb_tp.Text = dtg_khachhang.CurrentRow.Cells[9].Value.ToString();
            tb_qg.Text = dtg_khachhang.CurrentRow.Cells[10].Value.ToString();
            tb_mk.Text = dtg_khachhang.CurrentRow.Cells[11].Value.ToString();
            //
        
        }
    }
}
