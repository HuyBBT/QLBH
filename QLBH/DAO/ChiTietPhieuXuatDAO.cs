using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAO
{
    public class ChiTietPhieuXuatDAO
    {
        private static ChiTietPhieuXuatDAO instance;
        public static ChiTietPhieuXuatDAO Instance
        {
            get
            {
                if (instance == null) instance = new ChiTietPhieuXuatDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private ChiTietPhieuXuatDAO() { }

        public bool InsertChiTietPhieuXuat(string maHH,int maKH,int MaPX,int counts,string ghiChu)
        {
            string query = "exec USP_InsertChiTietPhieuXuat @MaHH , @MaKH , @MaPX , @Counts , @GhiChu";

            int resuls = DataProvider.Instance.ExcuteNonQuery(query, new object[] { maHH,maKH,MaPX,counts,ghiChu});

            return resuls > 0;
        }
    }
}
