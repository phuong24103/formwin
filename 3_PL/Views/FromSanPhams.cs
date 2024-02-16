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
    public partial class FromSanPhams : Form
    {
        SanPhamServices _spsv;
        QlSpCtServices _qlSpCtServices;
        MauSacServices _mauSacServices;
        DongSpServices _dongspsv;
        NXSServices _NXSServices;
        Guid _curentID;
        List<ChiTietSpView> lst;
        public FromSanPhams()
        {
            _spsv = new SanPhamServices();
            _qlSpCtServices = new QlSpCtServices();
            _mauSacServices = new MauSacServices();
            _dongspsv = new DongSpServices();
            lst = new List<ChiTietSpView>();
            lst = _qlSpCtServices.GetAll();
            InitializeComponent();
        }
        private void LoadToCmb_DongSp()
        {
            foreach (var item in _dongspsv.GetAll())
            {
                cmb_dongsp.Items.Add(item.Ten);
            }
        }
        private void LoadToCmb_TenSp()
        {
            foreach (var item in _spsv.GetAll())
            {
                cmb_tensp.Items.Add(item.Ten);
            }
        }
        private void LoadToCmb_MauSac()
        {
            foreach (var item in _mauSacServices.GetAll())
            {
                cmb_mausac.Items.Add(item.Ten);
            }
        }
        private void LoadToCmb_Nsx()
        {
            foreach (var item in _NXSServices.GetAll())
            {
                cmb_tennsx.Items.Add(item.Ten);
            }
        }
        private void LoadToGridViews(List<ChiTietSpView> lst)
        {
            int stt = 1;
            dtg_sp.Rows.Clear();
            dtg_sp.ColumnCount = 11;
            dtg_sp.Columns[0].Name = "ID";
            dtg_sp.Columns[0].Visible = false;
            dtg_sp.Columns[1].Name = "STT";
            dtg_sp.Columns[2].Name = "Tên Sp";
            dtg_sp.Columns[3].Name = "Màu Sp";
            dtg_sp.Columns[4].Name = "Dòng Sp";
            dtg_sp.Columns[5].Name = "Nsx";
            dtg_sp.Columns[6].Name = "Năm BH";
            dtg_sp.Columns[7].Name = "Mô tả";
            dtg_sp.Columns[8].Name = "SL tồn";
            dtg_sp.Columns[9].Name = "Giá nhập";
            dtg_sp.Columns[10].Name = "Giá bán";
            foreach (var item in lst)
            {
                dtg_sp.Rows.Add(item.Id, stt++, item.TenSp, item.TenMauSac, item.TenDongSp, item.TenNsx, item.NamBh, item.MoTa, item.SoLuongTon, item.GiaNhap, item.GiaBan);
            }
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            var SanPham = _spsv.GetAll().FirstOrDefault(c => c.Ten == cmb_tensp.Text).Id;
            var MauSac = _mauSacServices.GetAll().FirstOrDefault(c => c.Ten == cmb_mausac.Text).Id;
            var DongSp = _dongspsv.GetAll().FirstOrDefault(c => c.Ten == cmb_dongsp.Text).Id;
            var Nsx = _NXSServices.GetAll().FirstOrDefault(c => c.Ten == cmb_tennsx.Text).Id;
            ChiTietSpView spv = new ChiTietSpView()
            {
                IdSp = SanPham,
                IdMauSac = MauSac,
                IdDongSp = DongSp,
                IdNsx = Nsx,
                NamBh = int.Parse(tbx_nambh.Text),
                MoTa = tbx_mota.Text,
                SoLuongTon = int.Parse(tbx_soluongton.Text),
                GiaBan = int.Parse(tbx_giaban.Text),
                GiaNhap = int.Parse(tbx_gianhap.Text)
            };
            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn thêm không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_qlSpCtServices.Add(spv));
            }
        }

        private void dtg_sp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _curentID = (Guid)dtg_sp.CurrentRow.Cells[0].Value;
            cmb_tensp.Text = dtg_sp.CurrentRow.Cells[2].Value.ToString();
            cmb_mausac.Text = dtg_sp.CurrentRow.Cells[3].Value.ToString();
            cmb_dongsp.Text = dtg_sp.CurrentRow.Cells[4].Value.ToString();
            cmb_tennsx.Text = dtg_sp.CurrentRow.Cells[5].Value.ToString();
            tbx_nambh.Text = dtg_sp.CurrentRow.Cells[6].Value.ToString();
            tbx_mota.Text = dtg_sp.CurrentRow.Cells[7].Value.ToString();
            tbx_soluongton.Text = dtg_sp.CurrentRow.Cells[8].Value.ToString();
            tbx_gianhap.Text = dtg_sp.CurrentRow.Cells[9].Value.ToString();
            tbx_giaban.Text = dtg_sp.CurrentRow.Cells[10].Value.ToString();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            var SanPham = _spsv.GetAll().FirstOrDefault(c => c.Ten == cmb_tensp.Text).Id;
            var MauSac = _mauSacServices.GetAll().FirstOrDefault(c => c.Ten == cmb_mausac.Text).Id;
            var DongSp = _dongspsv.GetAll().FirstOrDefault(c => c.Ten == cmb_dongsp.Text).Id;
            var Nsx = _NXSServices.GetAll().FirstOrDefault(c => c.Ten == cmb_tennsx.Text).Id;
            ChiTietSpView spv = new ChiTietSpView()
            {
                Id = _curentID,

                IdSp = SanPham,
                IdMauSac = MauSac,
                IdDongSp = DongSp,
                IdNsx = Nsx,
                NamBh = int.Parse(tbx_nambh.Text),
                MoTa = tbx_mota.Text,
                SoLuongTon = int.Parse(tbx_soluongton.Text),
                GiaBan = int.Parse(tbx_giaban.Text),
                GiaNhap = int.Parse(tbx_gianhap.Text)
            };
            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn Sửa không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_qlSpCtServices.Update(spv));
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn Xóa không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {

                MessageBox.Show(_qlSpCtServices.Delete(_curentID));
            }
        }
 

        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            lst = new List<ChiTietSpView>();
            lst = _qlSpCtServices.GetAll();
            LoadToCmb_TenSp();
            LoadToCmb_MauSac();
            LoadToCmb_DongSp();
            LoadToCmb_Nsx();
            LoadToGridViews(lst);

        }
    }
}
