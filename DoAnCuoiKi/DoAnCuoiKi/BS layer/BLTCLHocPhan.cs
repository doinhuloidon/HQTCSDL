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
    }
}
