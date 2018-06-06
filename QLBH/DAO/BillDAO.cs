using QLBH.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get
            {
                if (instance == null) instance = new BillDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private BillDAO() { }

        public List<Bill> HienThiPhieuXuat(int id)
        {
            List<Bill> listPhieuXuat = new List<Bill>();

            string query = "select kh.TenKH,hh.TenHH,px.NgayXuat,cpx.Counts as SoLuong,pn.Giaxuat as DonGia, cpx.Counts*pn.Giaxuat as ThanhTien from ChiTietPhieuXuat cpx,PhieuXuat px, HangHoa hh,KhachHang kh, ChiTietPhieuNhap pn where cpx.MaHH = pn.MaHH and cpx.MaHH = hh.MaHH and cpx.MaKH = kh.MaKH and px.MaPX = cpx.MaPX and px.MaPX ="+id ;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Bill Phieu = new Bill(item);
                listPhieuXuat.Add(Phieu);
            }

            return listPhieuXuat;

        }

        void isertPhieuXuat(DateTime ngayxuat)
        {
            string query = "exec USP_InsertPhieuXuat @NgayXuat";
            int resulst = DataProvider.Instance.ExcuteNonQuery(query, new object[] { ngayxuat });
        }
    }
}
