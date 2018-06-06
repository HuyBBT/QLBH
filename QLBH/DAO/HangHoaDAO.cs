using QLBH.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAO
{
    class HangHoaDAO
    {
        private static HangHoaDAO instance;

        public static HangHoaDAO Instance
        {
            get
            {
                if (instance == null) instance = new HangHoaDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private HangHoaDAO() { }

        public List<HangHoa> GetLishHangHoabyLoaiHH(int id)
        {
                  
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from HangHoa where MaLoaiHH = " +id);

            List<HangHoa> listHH = new List<HangHoa>();

            foreach(DataRow item in data.Rows)
            {
                HangHoa HH = new HangHoa(item);

                listHH.Add(HH);
            }

            return listHH;
        }
    }
}
