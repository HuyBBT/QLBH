using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DTO
{
    public class HangHoa
    {
        string maHH;

        string tenHH;

        int maDV;

        int maNCC;

        int maLoaiHH;

        public HangHoa(string MaHH,string TenHH,int MaDV,int MaNCC,int MaLoaiHH)
        {
            this.maHH = MaHH;
            this.tenHH = TenHH;
            this.maDV = MaDV;
            this.maNCC = MaNCC;
            this.maLoaiHH = MaLoaiHH;
        }

        public HangHoa(DataRow row)
        {
            this.maHH = row["MaHH"].ToString();
            this.tenHH = row["TenHH"].ToString();
            this.maDV = (int)row["MaDV"];
            this.maNCC = (int)row["MaNCC"];
            this.maLoaiHH = (int)row["MaLoaiHH"];
        }
        public string MaHH
        {
            get
            {
                return maHH;
            }

            set
            {
                maHH = value;
            }
        }

        public string TenHH
        {
            get
            {
                return tenHH;
            }

            set
            {
                tenHH = value;
            }
        }

        public int MaDV
        {
            get
            {
                return maDV;
            }

            set
            {
                maDV = value;
            }
        }

        public int MaNCC
        {
            get
            {
                return maNCC;
            }

            set
            {
                maNCC = value;
            }
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
    }
}
