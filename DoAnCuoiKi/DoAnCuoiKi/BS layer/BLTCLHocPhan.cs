using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi.BS_layer
{
    class BLTCLHocPhan
    {
        QLDangKyMonHocDataContext ql = new QLDangKyMonHocDataContext();
        public IEnumerable<dynamic> Laylhp()
        {
            var ab = ql.timkiem();
            return ab;
        }
        public IEnumerable<dynamic> tklhpkhoa(string tenkhoa)
        {

            var ab = ql.tklhpkhoa(tenkhoa);
            return ab;
        }
        public IEnumerable<dynamic> tklhpmamon(string mamon)
        {

            var ab = ql.tklhpmamon(mamon);
            return ab;
        }
        public IEnumerable<dynamic> tklhptenmon(string tenmon)
        {
            var ab = ql.tklhptenmon(tenmon);
            return ab;
        }
        public void sualophocphan(string maLop, string phongHoc, string Thu, int TuTiet, int DenTiet, int soLuong, string tgBatDau, string tgKetThuc)
        {
<<<<<<< HEAD
            //ql.editlhp(maLop, phongHoc, Thu, TuTiet, DenTiet, soLuong, DateTime.Parse(tgBatDau), DateTime.Parse(tgKetThuc));
=======
          //  ql.editlhp(maLop, phongHoc, Thu, TuTiet, DenTiet, soLuong, DateTime.Parse(tgBatDau), DateTime.Parse(tgKetThuc));
>>>>>>> 9fd05cfa2649765ffd0b8c60a07964a6a4ca7992
        }
        public void xoalhp(string malop)
        {
            ql.deletelhp(malop);
        }

    }
}
