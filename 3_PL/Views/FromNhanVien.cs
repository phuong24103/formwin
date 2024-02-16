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
    public partial class FromNhanVien : Form
    {
        INhanVienServices _nhanviensv;
        IChucVuServices _cvsv;
        ICuaHangServices _chsv;
        Guid _curentID;
        public FromNhanVien()
        {
            _nhanviensv = new NhanVienServices();
            _cvsv = new ChucVuServices();
            _chsv = new CuaHangServices();
            InitializeComponent();
        }
        private void LoadToCmb_ChucVu()
        {
            cmb_chucvu.Items.Clear();
            foreach (var item in _cvsv.GetAll())
            {
                cmb_chucvu.Items.Add(item.Ten);
            }
        }
        private void LoadToCmb_CuaHang()
        {
            cmb_cuahang.Items.Clear();
            foreach (var item in _chsv.GetAll())
            {
                cmb_cuahang.Items.Add(item.Ten);
            }
        }
        private void LoadToCmb_GuiBC()
        {
            cmb_nguoiguibc.Items.Clear();
            foreach (var item in _nhanviensv.GetAll())
            {
                cmb_nguoiguibc.Items.Add(item.Ma);
            }
        }
        private void LoadData_Nhanvien()
        {
            int stt = 1;
            dtg_nhanvien.Rows.Clear();
            dtg_nhanvien.ColumnCount = 15;
            dtg_nhanvien.Columns[0].Name = "ID";
            dtg_nhanvien.Columns[0].Visible = false;
            dtg_nhanvien.Columns[1].Name = "STT";
            dtg_nhanvien.Columns[2].Name = "Họ";
            dtg_nhanvien.Columns[3].Name = "Tên đệm";
            dtg_nhanvien.Columns[4].Name = "Tên";
            dtg_nhanvien.Columns[5].Name = "Mã Nv";
            dtg_nhanvien.Columns[6].Name = "Ngày sinh";
            dtg_nhanvien.Columns[7].Name = "Giới tính";
            dtg_nhanvien.Columns[8].Name = "Địa chỉ";
            dtg_nhanvien.Columns[9].Name = "Mật khẩu";
            dtg_nhanvien.Columns[10].Name = "SDT";
            dtg_nhanvien.Columns[11].Name = "Chức vụ";
            dtg_nhanvien.Columns[12].Name = "Tên cửa hàng";
            dtg_nhanvien.Columns[13].Name = "Trạng thái";
            dtg_nhanvien.Columns[14].Name = "Người gửi BC";
            foreach (var item in _nhanviensv.GetAll())
            {
                dtg_nhanvien.Rows.Add(
                    item.Id,
                    stt++,
                    item.Ho,
                    item.TenDem,
                    item.Ten,
                    item.Ma,
                    item.NgaySinh,
                    item.GioiTinh,
                    item.DiaChi,
                    item.MatKhau,
                    item.Sdt,
                    _cvsv.GetAll().FirstOrDefault(p => p.Id == item.IdCv).Ten,
                    _chsv.GetAll().FirstOrDefault(p => p.Id == item.IdCh).Ten,
                    (item.TrangThai == 0) ? "không hoạt động" : "hoạt động",
                    item.IdGuiBc != null ? _nhanviensv.GetAll().FirstOrDefault(p => p.Id == item.IdGuiBc).Ma : " ");

            }
        }

        private void dtg_nhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _curentID = (Guid)dtg_nhanvien.CurrentRow.Cells[0].Value;
            tbx_ho.Text = dtg_nhanvien.CurrentRow.Cells[2].Value.ToString();
            tbx_tendem.Text = dtg_nhanvien.CurrentRow.Cells[4].Value.ToString();
            tbx_manv.Text = dtg_nhanvien.CurrentRow.Cells[5].Value.ToString();
            dtp_ngaysinh.Text = dtg_nhanvien.CurrentRow.Cells[6].Value.ToString();
            var a = dtg_nhanvien.CurrentRow.Cells[7].Value.ToString() == "Nam" ? cbx_gt_nam.Checked == true : cbx_gt_nu.Checked == true;
            tbx_diachi.Text = dtg_nhanvien.CurrentRow.Cells[8].Value.ToString();
            tbx_matkhau.Text = dtg_nhanvien.CurrentRow.Cells[9].Value.ToString();
            tbx_sdt.Text = dtg_nhanvien.CurrentRow.Cells[10].Value.ToString();
            cmb_chucvu.Text = dtg_nhanvien.CurrentRow.Cells[11].Value.ToString();
            cmb_cuahang.Text = dtg_nhanvien.CurrentRow.Cells[12].Value.ToString();
            var b = dtg_nhanvien.CurrentRow.Cells[13].Value.ToString() == "Không hoạt động"? cbx_khonghoatdong.Checked == true: cbx_hoatdong.Checked==true;
            cmb_nguoiguibc.Text = dtg_nhanvien.CurrentRow.Cells[14].Value.ToString();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            NhanVienVIew nvv = new NhanVienVIew()
            {
                Ma = tbx_manv.Text,
                Ten = tbx_ten.Text,
                TenDem = tbx_tendem.Text,
                Ho = tbx_ho.Text,
                GioiTinh = cbx_gt_nam.Checked == true ? "Nam" : "Nữ",
                NgaySinh = DateTime.Parse(dtp_ngaysinh.Text),
                DiaChi = tbx_diachi.Text,
                Sdt = tbx_sdt.Text,
                MatKhau = tbx_matkhau.Text,
                IdCh = _chsv.GetAll().FirstOrDefault(c => c.Ten == cmb_cuahang.Text).Id,
                IdCv = _cvsv.GetAll().FirstOrDefault(c => c.Ten == cmb_chucvu.Text).Id,
                //IdGuiBc = _IQLNhanVienService.GetNhanVienByMa(cmb_nguoiguibc.Text).Id,
                IdGuiBc = cmb_nguoiguibc.Text != "" ? _nhanviensv.GetAll().FirstOrDefault(x => x.Ma == cmb_nguoiguibc.Text).Id : null,
                TrangThai = cbx_hoatdong.Checked == true ? 1 : 0,
            };
            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn thêm không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_nhanviensv.Add(nvv));
                LoadToCmb_GuiBC();
                
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            NhanVienVIew nvv = new NhanVienVIew()
            {
                Id = _curentID,
                Ma = tbx_manv.Text,
                Ten = tbx_ten.Text,
                TenDem = tbx_tendem.Text,
                Ho = tbx_ho.Text,
                GioiTinh = cbx_gt_nam.Checked == true ? "Nam" : "Nữ",
                NgaySinh = DateTime.Parse(dtp_ngaysinh.Text),
                DiaChi = tbx_diachi.Text,
                Sdt = tbx_sdt.Text,
                MatKhau = tbx_matkhau.Text,
                IdCh = _cvsv.GetAll().FirstOrDefault(c => c.Ten == cmb_cuahang.Text).Id,
                IdCv = _chsv.GetAll().FirstOrDefault(c => c.Ten == cmb_chucvu.Text).Id,
                IdGuiBc = cmb_nguoiguibc.Text != "" ? _nhanviensv.GetAll().FirstOrDefault(x => x.Ma == cmb_nguoiguibc.Text).Id : null,
                //IdGuiBc = _IQLNhanVienService.GetNhanVienByMa(cmb_nguoiguibc.Text).Id,
                TrangThai = cbx_hoatdong.Checked == true ? 1 : 0,
            };
            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn thêm không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_nhanviensv.Update(nvv));
                LoadToCmb_GuiBC();
                
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn Xóa không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_nhanviensv.Delete(_curentID));
                LoadToCmb_GuiBC();
              
            }
        }

        private void cbx_gt_nam_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_gt_nam.Checked)
            {
                cbx_gt_nu.Checked = false;
            }
        }

        private void cbx_gt_nu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_gt_nam.Checked)
            {
                cbx_gt_nu.Checked = false;
            }
        }

        private void cbx_hoatdong_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_hoatdong.Checked)
            {
                cbx_hoatdong.Checked = false;
            }
        }

        private void cbx_khonghoatdong_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_khonghoatdong.Checked)
            {
                cbx_hoatdong.Checked = false;
            }
        }

        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            LoadData_Nhanvien();
            LoadToCmb_ChucVu();
            LoadToCmb_CuaHang();
            LoadToCmb_GuiBC();
        }
    }
}
