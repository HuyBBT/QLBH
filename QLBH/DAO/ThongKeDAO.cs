using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAO
{
    class ThongKeDAO
    {
        private static ThongKeDAO instance;
        public static ThongKeDAO Instance
        {
            get
            {
                if (instance == null) instance = new ThongKeDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private ThongKeDAO() { }

       public DataTable ThongKe(DateTime ThongKe)
        {            
            string query = "exec USP_ThongKe @NgayXuat";
            DataTable data = DataProvider.Instance.ExcuteQuery(query,new object[] { ThongKe});
            return data;
        }
    }
}
