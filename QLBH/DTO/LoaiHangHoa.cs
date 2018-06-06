using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DTO
{
    public class LoaiHangHoa
    {
        string tenLoaiHH;

        int maLoaiHH;

        public LoaiHangHoa(int MaLoaiHH,string TenLoaiHH)
        {
            this.maLoaiHH = MaLoaiHH;
            this.tenLoaiHH = TenLoaiHH;
        }

        public LoaiHangHoa(DataRow row)
        {
            this.maLoaiHH = (int)row["MaLoaiHH"];
            this.tenLoaiHH = row["tenLoaiHH"].ToString();
        }

        public int MaLoaiHH
        {
            get
            {
                return maLoaiHH;
            }

            set
            {
                maLoaiHH = value;
            }
        }

        public string TenLoaiHH
        {
            get
            {
                return tenLoaiHH;
            }

            set
            {
                tenLoaiHH = value;
            }
        }
    }
}
