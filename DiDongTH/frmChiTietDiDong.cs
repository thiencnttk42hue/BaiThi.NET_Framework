using System;
using DiDongTH.ViewModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DiDongTH.BLL.DiDongBLL;
using DiDongTH.BLL;

namespace DiDongTH
{
    public partial class frmChiTietDiDong : Form
    {
        DiDongVM DiDongVM;
        private KETQUA diDongBLL;
        public frmChiTietDiDong( DiDongVM diDongVM = null)
        {
            InitializeComponent();
            this.DiDongVM = diDongVM;
            if(diDongVM == null)
            {
                this.Text = "Thêm mới Di Động";
            }
            else
            {
                this.Text = "Sửa thông tin Di Động";
                txtTenDD.Text = diDongVM.tendd;
                txtTSKT.Text = diDongVM.thongsokythuat;
                txtNoiSanXuat.Text = diDongVM.noisanxuat;
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            var tendd = txtTenDD.Text;
            long gia = long.Parse(txtGia.Text);
            var tskt = txtTSKT.Text;
            DateTime ngaynhap = dateNgayNhap.Value;
            var noisx = txtNoiSanXuat.Text;
            if (string.IsNullOrEmpty(tendd))
            {
                errorProvider1.SetError(txtTenDD, "Tên Di Động Không Được Để Trống!");
            }
            if (string.IsNullOrEmpty(tskt))
            {
                errorProvider1.SetError(txtTSKT, "Thông Số Kỹ Thuật Không Được Để Trống!");
            }
            if (string.IsNullOrEmpty(noisx))
            {
                errorProvider1.SetError(txtNoiSanXuat, "Nơi Sản Xuất Không Được Để Trống!");
            }
            var rs = KETQUA.ThanhCong;
            if(DiDongVM == null)
            {
                rs = DiDongBLL.add(new DiDongVM
                {
                    tendd = tendd,
                    thongsokythuat = tskt,
                    gia = gia,
                    ngaynhap = ngaynhap,
                    noisanxuat = noisx
                });
            }
            else
            {
                DiDongVM.tendd = tendd;
                DiDongVM.thongsokythuat = tskt;
                DiDongVM.gia = gia;
                DiDongVM.ngaynhap = ngaynhap;
                DiDongVM.noisanxuat = noisx;
                rs = DiDongBLL.update(DiDongVM);
            }

            if( rs == KETQUA.ThanhCong)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Các Thông Tin Trùng Trong Hệ Thống!", "Thông Báo!");
            }

        }
    }
}
