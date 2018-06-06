using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAO
{
    public class PhieuXuatDAO
    {
        private static PhieuXuatDAO instance;
        public static PhieuXuatDAO Instance
        {
            get
            {
                if (instance == null) instance = new PhieuXuatDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private PhieuXuatDAO() { }

        public bool InsertPhieuXuat(DateTime NgayXuat)
        {
            string query = "exec USP_InsertPhieuXuat @NgayXuat";

            int resuls = DataProvider.Instance.ExcuteNonQuery(query,new object[] {NgayXuat});

            return resuls > 0 ;
        }

       public DataTable LoadPhieuXuat()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from PhieuXuat where MaPX = (select MAX(MaPX) as MaVuaThem from PhieuXuat)");
            return data;
        }

        public int GetMaxIDPhieuXuat()
        {
            try
            {
                return (int)DataProvider.Instance.ExcuteScalar("select MAX(MaPX) from PhieuXuat");
            }
            catch
            {
                return 1;
            }
        }

    }
}
