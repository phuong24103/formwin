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
    public partial class FromNSX : Form
    {
        INXSServices _nXSServices;
        Guid _curentID;
        public FromNSX()
        {
            _nXSServices = new NXSServices();
            InitializeComponent();
        }
        private void LoadToGrid()
        {
            dtg_nsx.ColumnCount = 4;
            dtg_nsx.Columns[0].Name = "ID";
            dtg_nsx.Columns[0].Visible = false;
            dtg_nsx.Columns[1].Name = "STT";
            dtg_nsx.Columns[2].Name = "Mã";
            dtg_nsx.Columns[3].Name = "Tên";
            int stt = 1;
            dtg_nsx.Rows.Clear();
            foreach (var item in _nXSServices.GetAll())
            {
                dtg_nsx.Rows.Add(item.Id, stt++, item.Ma, item.Ten);
            }
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            NXSView nsxv = new NXSView()
            {
                Ma = tb_ma.Text,
                Ten = tb_ten.Text,
            };
            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn thêm không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_nXSServices.Add(nsxv));
                LoadToGrid();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            NXSView nsxv = new NXSView()
            {
                Id = _curentID,
                Ma = tb_ma.Text,
                Ten = tb_ten.Text,
            };
            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn Sửa không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_nXSServices.Update(nsxv));
                LoadToGrid();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn Xóa không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_nXSServices.Delete(_curentID));
                LoadToGrid();
            }
        }

        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            LoadToGrid();
        }

        private void dtg_nsx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _curentID = (Guid)(dtg_nsx.CurrentRow.Cells[0].Value);
            tb_ma.Text = dtg_nsx.CurrentRow.Cells[2].Value.ToString();
            tb_ten.Text = dtg_nsx.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
