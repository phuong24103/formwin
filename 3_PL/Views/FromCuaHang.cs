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
    public partial class FromCuaHang : Form
    {
        ICuaHangServices _cuahangsv;
        Guid _CurentID;
        public FromCuaHang()
        {
            InitializeComponent();
            _cuahangsv = new CuaHangServices();
        }
        private void LoadDataGrid()
        {
            dtg_cuahang.ColumnCount = 7;
            dtg_cuahang.Columns[0].Name = "ID";
            dtg_cuahang.Columns[0].Visible = false;
            dtg_cuahang.Columns[1].Name = "STT";
            dtg_cuahang.Columns[2].Name = "Mã";
            dtg_cuahang.Columns[3].Name = "Tên";
            dtg_cuahang.Columns[4].Name = "Địa chỉ";
            dtg_cuahang.Columns[5].Name = "Thành phố";
            dtg_cuahang.Columns[6].Name = "Quốc gia";
            int stt = 1;
            dtg_cuahang.Rows.Clear();
            foreach (var item in _cuahangsv.GetAll())
            {
                dtg_cuahang.Rows.Add(item.Id, stt++, item.Ma, item.Ten, item.DiaChi, item.ThanhPho, item.QuocGia);

            }

        }

        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            CuaHangView cuaHangView = new CuaHangView()
            {
                Id = new Guid(),
                Ma = tb_ma.Text,
                Ten = tb_ten.Text,
                DiaChi = tb_dc.Text,
                ThanhPho = tb_tp.Text,
                QuocGia = tb_qg.Text,
            };
            DialogResult dg = MessageBox.Show("bạn có muốn thành công không", "thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_cuahangsv.Add(cuaHangView));
                LoadDataGrid();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            CuaHangView cuaHangView = new CuaHangView()
            {
                Id = _CurentID,
                Ma = tb_ma.Text,
                Ten = tb_ten.Text,
                DiaChi = tb_dc.Text,
                ThanhPho = tb_tp.Text,
                QuocGia = tb_qg.Text,
            };
            DialogResult dg = MessageBox.Show("bạn có muốn sửa không","thông báo",MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_cuahangsv.Update(cuaHangView));
                LoadDataGrid();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn xóa không?", "thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_cuahangsv.Delete(_CurentID));
                LoadDataGrid();
            }
        }

        private void dtg_cuahang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _CurentID = (Guid)(dtg_cuahang.CurrentRow.Cells[0].Value);
            tb_ma.Text = dtg_cuahang.CurrentRow.Cells[1].Value.ToString();
            tb_ten.Text = dtg_cuahang.CurrentRow.Cells[2].Value.ToString();
            tb_dc.Text = dtg_cuahang.CurrentRow.Cells[3].Value.ToString();
            tb_tp.Text = dtg_cuahang.CurrentRow.Cells[4].Value.ToString();
            tb_qg.Text = dtg_cuahang.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
