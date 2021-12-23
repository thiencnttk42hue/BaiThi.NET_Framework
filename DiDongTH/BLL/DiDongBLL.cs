using DiDongTH.DAL;
using DiDongTH.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDongTH.BLL
{
    internal class DiDongBLL
    {
        public enum KETQUA
        {
            ThanhCong, TenTrung
        }


        public static List<DiDong> GetList()
        {
            ModelDiDong modlel = new ModelDiDong();
            return modlel.DiDong.OrderByDescending(e => e.tendd).ToList();
        }
        public static List<DiDongVM> GetListVM()
        {
            ModelDiDong modlel = new ModelDiDong();
            var ls = modlel.DiDong.Select(e => new DiDongVM
            {
                id = e.id,
                tendd = e.tendd,
                thongsokythuat = e.thongsokythuat,
                gia = (long)((long?)e.gia?? 1),
                ngaynhap = (DateTime)((DateTime?)e.ngaynhap ?? new DateTime(2010, 8, 18)),
                noisanxuat = e.noisanxuat
            }).ToList();
            return ls;
        }
        public static KETQUA add(DiDongVM DiDongVM)
        {
            ModelDiDong model = new ModelDiDong();
            var dd = model.DiDong.Where(e => e.tendd == DiDongVM.tendd).FirstOrDefault();
            if(dd != null)
            {
                return KETQUA.TenTrung;
            }else
            {
                dd = new DiDong
                {
                    tendd = DiDongVM.tendd,
                    thongsokythuat = DiDongVM.thongsokythuat,
                    gia = DiDongVM.gia,
                    ngaynhap = DiDongVM.ngaynhap,
                    noisanxuat = DiDongVM.noisanxuat
                };
                model.DiDong.Add(dd);
                model.SaveChanges();
                return KETQUA.ThanhCong;
            }
        }
        public static KETQUA update(DiDongVM DiDongVM)
        {
            ModelDiDong model = new ModelDiDong();
            var dd = model.DiDong.Where(e => e.id != DiDongVM.id && e.tendd == DiDongVM.tendd).FirstOrDefault();
            if (dd != null)
            {
                return KETQUA.TenTrung;
            }
            else
            {
                dd = model.DiDong.Where(e => e.id == DiDongVM.id).FirstOrDefault();
                dd.tendd = DiDongVM.tendd;
                dd.thongsokythuat = DiDongVM.thongsokythuat;
                dd.gia = DiDongVM.gia;
                dd.ngaynhap = DiDongVM.ngaynhap;
                dd.noisanxuat = DiDongVM.noisanxuat;
                model.SaveChanges();
                return KETQUA.ThanhCong;
            }
        }
        public static void delete(long id)
        {
            ModelDiDong model = new ModelDiDong();
            var dd = model.DiDong.Where(e => e.id == id).FirstOrDefault();
            if(dd != null)
            {
                model.DiDong.Remove(dd);
            }else
            {
                throw new Exception("Di Động này không tồn tại!");
            }
            model.SaveChanges();
        }
    }
}
