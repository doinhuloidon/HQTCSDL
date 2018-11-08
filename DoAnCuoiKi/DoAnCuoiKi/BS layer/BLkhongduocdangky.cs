using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi.BS_layer
{
    class BLkhongduocdangky
    {
        public IEnumerable<dynamic> loadda()
        {
            QLDangKyMonHocDataContext ql = new QLDangKyMonHocDataContext();
            var ab= ql.dskhongdk();
            return ab;
        }
        public int themsvkodk(string masv,string ghichu)
        {
            QLDangKyMonHocDataContext ql = new QLDangKyMonHocDataContext();
            int ab = ql.addsvkodk(masv,ghichu);
            return ab;
        }
        public int editsv(string masv, string ghichu)
        {
            QLDangKyMonHocDataContext ql = new QLDangKyMonHocDataContext();
            int ab = ql.editsvkodk(masv, ghichu);
            return ab;
        }
        public void deletesvkodk(string masv)
        {
            QLDangKyMonHocDataContext ql = new QLDangKyMonHocDataContext();
            int ab = ql.deletesvkodk(masv);
 
        }
    }
}
