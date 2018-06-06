using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DTO
{
    public class Bill
    {
       
        int thanhTien;

        int donGia;

        int soLuong;
         
        string tenHH;

        string tenKH;

        DateTime ngayXuat;

        public Bill(string TenHH,string TenKH,int SoLuong,int DonGia,int ThanhTien,DateTime NgayXuat)
        {
            this.thanhTien = ThanhTien;
            this.donGia = DonGia;
            this.soLuong = SoLuong;
            this.tenHH = TenHH;
            this.TenKH = TenKH;
            this.ngayXuat = NgayXuat;
        }

        public Bill(DataRow row)
        {
            var oj = row["ThanhTien"];
            this.thanhTien = (int)row["ThanhTien"];
            this.donGia = (int)row["DonGia"];
            this.soLuong = (int)row["SoLuong"];
            this.tenHH = row["TenHH"].ToString();
            this.TenKH = row["TenKH"].ToString();
            this.ngayXuat = (DateTime)row["NgayXuat"];
        }
        
        public int DonGia
        {
            get
            {
                return donGia;
            }

            set
            {
                donGia = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
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

        public int ThanhTien
        {
            get
            {
                return thanhTien;
            }

            set
            {
                thanhTien = value;
            }
        }

  
        public DateTime NgayXuat
        {
            get
            {
                return ngayXuat;
            }

            set
            {
                ngayXuat = value;
            }
        }

        public string TenKH
        {
            get
            {
                return tenKH;
            }

            set
            {
                tenKH = value;
            }
        }
    }
}
