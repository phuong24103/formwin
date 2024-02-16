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
    public partial class FromChucVu : Form
    {
        IChucVuServices _chucVuServices;
        Guid _curentID;
        public FromChucVu()
        {
            InitializeComponent();
            _chucVuServices = new ChucVuServices();

        }
        private void LoadDataGrid()
        {
            dtg_chucvu.ColumnCount = 4;
            dtg_chucvu.Columns[0].Name = "ID";
            dtg_chucvu.Columns[0].Visible = false;
            dtg_chucvu.Columns[1].Name = "STT";
            dtg_chucvu.Columns[2].Name = "Mã";
            dtg_chucvu.Columns[3].Name = "Tên";
            int stt = 1;
            dtg_chucvu.Rows.Clear();
            foreach (var item in _chucVuServices.GetAll())
            {
                dtg_chucvu.Rows.Add(item.Id, stt++, item.Ma, item.Ten);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            ChucVuView chucVuView = new ChucVuView()
            {
                Ma = tb_ma.Text,
                Ten = tb_ten.Text,
            };
            DialogResult dg = MessageBox.Show("bạn có muốn thêm ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_chucVuServices.Add(chucVuView));
                LoadDataGrid();
            }
        }


        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void dtg_chucvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _curentID = (Guid)(dtg_chucvu.CurrentRow.Cells[0].Value);
            tb_ma.Text = dtg_chucvu.CurrentRow.Cells[2].Value.ToString();
            tb_ten.Text = dtg_chucvu.CurrentRow.Cells[3].Value.ToString();

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            ChucVuView chucVuView = new ChucVuView()
            {
                Id = _curentID,
                Ten = tb_ten.Text,
                Ma = tb_ma.Text,
            };
            DialogResult dg = MessageBox.Show("bạn có muốn sửa không", "Thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_chucVuServices.Update(chucVuView));
                LoadDataGrid();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn xóa không?","thông báo",MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_chucVuServices.Delete(_curentID));
                LoadDataGrid();
            }
        }
    }
}
