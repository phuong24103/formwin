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
    public partial class FromDongSp : Form
    {
        IDongSpServices _dongspservices;
        Guid _CurentID;
        public FromDongSp()
        {
            _dongspservices = new DongSpServices();
            InitializeComponent();
        }
        private void LoadDataGrid()
        {
            dtg_dongsp.ColumnCount = 4;
            dtg_dongsp.Columns[0].Name = "ID";
            dtg_dongsp.Columns[0].Visible = false;
            dtg_dongsp.Columns[1].Name = "STT";
            dtg_dongsp.Columns[2].Name = "Mã";
            dtg_dongsp.Columns[3].Name = "Tên";
            int stt = 1;
            dtg_dongsp.Rows.Clear();
            foreach (var item in _dongspservices.GetAll())
            {
                dtg_dongsp.Rows.Add(item.Id, stt++, item.Ma, item.Ten);
            }
        }
        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            DongSpView dongSpView = new DongSpView()
            {
                Id = new Guid(),
                
                Ten = tb_ten.Text,
                Ma = tb_ma.Text,

            };
            DialogResult dg = MessageBox.Show("bạn có muốn thêm không?","thông báo",MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_dongspservices.Add(dongSpView));
                LoadDataGrid();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            DongSpView dongSpView = new DongSpView()
            {
                Id = _CurentID,
                Ma = tb_ma.Text,
                Ten = tb_ten.Text,
            };
            DialogResult dg = MessageBox.Show("Bạn có muốn sửa không", "thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_dongspservices.Update(dongSpView));
                LoadDataGrid();
            }

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                MessageBox.Show(_dongspservices.Delete(_CurentID));
                LoadDataGrid();

            }
        }

        private void dtg_dongsp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _CurentID = (Guid)(dtg_dongsp.CurrentRow.Cells[0].Value);
            tb_ma.Text = dtg_dongsp.CurrentRow.Cells[2].Value.ToString();
            tb_ten.Text = dtg_dongsp.CurrentRow.Cells[2].Value.ToString();

        }
    }
}
