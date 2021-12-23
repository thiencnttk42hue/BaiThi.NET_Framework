using DiDongTH.BLL;
using DiDongTH.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiDongTH
{
    public partial class frmDiDong : Form
    {
        public frmDiDong()
        {
            InitializeComponent();
            NapDiDong();
        }
        void NapDiDong()
        {
            var ls = DiDongBLL.GetListVM();
            diDongVMBindingSource.DataSource = ls;
            dataGridView1.DataSource = diDongVMBindingSource;
        }
        public DiDongVM SelectDiDong
        {
            get
            {
                return diDongVMBindingSource.Current as DiDongVM;
            }
        }
       
        private void btnThem_Click(object sender, EventArgs e)
        {
            var f = new frmChiTietDiDong();
            var rs = f.ShowDialog();
            if(rs == DialogResult.OK)
            {
                NapDiDong();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(SelectDiDong != null)
            {
                var f = new frmChiTietDiDong(SelectDiDong);
                var rs = f.ShowDialog();
                if( rs == DialogResult.OK)
                {
                    NapDiDong();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (SelectDiDong != null)
            {
                if (MessageBox.Show(
                    "Bạn có thực sự muốn xoá?",
                    "Chú ý",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DiDongBLL.delete(SelectDiDong.id);
                    diDongVMBindingSource.RemoveCurrent();
                    MessageBox.Show("Đã xóa thành công!");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
