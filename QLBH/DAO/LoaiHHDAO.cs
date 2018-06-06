using QLBH.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAO
{
    public class LoaiHHDAO
    {
        private static LoaiHHDAO instance;

        public static LoaiHHDAO Instance
        {
            get
            {
                if (instance == null) instance = new LoaiHHDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private LoaiHHDAO() { }

        public List<LoaiHangHoa> LoadListLoaiHH()
        {
            List<LoaiHangHoa> listLHH = new List<LoaiHangHoa>();

            string query = "Select * from LoaiHH";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                LoaiHangHoa LoaiHH = new LoaiHangHoa(item);
                listLHH.Add(LoaiHH);
            }

            return listLHH;
        }
    }
}
