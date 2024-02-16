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

namespace _3_PL
{
    public partial class FromMauSac : Form
    {
        IMauSacServices _mauSacServices;
        Guid _curentID;
        public FromMauSac()
        {
            InitializeComponent();
            _mauSacServices = new MauSacServices();
        }
        private void LoadToGrid()
        {
            dtg_mausac.ColumnCount = 4;
            dtg_mausac.Columns[0].Name = "ID";
            dtg_mausac.Columns[0].Visible = false;
            dtg_mausac.Columns[1].Name = "STT";
            dtg_mausac.Columns[2].Name = "Mã";
            dtg_mausac.Columns[3].Name = "Tên";
            int stt = 1;
            dtg_mausac.Rows.Clear();
            foreach (var item in _mauSacServices.GetAll())
            {
                dtg_mausac.Rows.Add(item.Id, stt++, item.Ma, item.Ten);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            MauSacView msv = new MauSacView()
            {
                Ma = tb_ma.Text,
                Ten = tb_ten.Text,
            };
            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn thêm không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_mauSacServices.Add(msv));
                LoadToGrid();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            MauSacView msv = new MauSacView()
            {
                Id = _curentID,
                Ma = tb_ma.Text,
                Ten = tb_ten.Text,
            };
            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn Sửa không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_mauSacServices.Update(msv));
                LoadToGrid();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn Xóa không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_mauSacServices.Delete(_curentID));
                LoadToGrid();
            }
        }

        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            LoadToGrid();
        }

        private void dtg_mausac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _curentID = (Guid)(dtg_mausac.CurrentRow.Cells[0].Value);
            tb_ma.Text = dtg_mausac.CurrentRow.Cells[2].Value.ToString();
            tb_ten.Text = dtg_mausac.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
