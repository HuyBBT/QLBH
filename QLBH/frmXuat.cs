using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLBH.DTO;
using QLBH.DAO;
using System.Globalization;

namespace QLBH
{
    public partial class frmXuat : Form
    {
        public frmXuat()
        {
            InitializeComponent();
            
        }
    
        private void frmXuat_Load(object sender, EventArgs e)
        {
            loadBill();
            LoadLoaiHH();
            LoadPhieuXuat();
        }
        void LoadPhieuXuat()
        {
            dtgPhieuXuat.DataSource = PhieuXuatDAO.Instance.LoadPhieuXuat();
        }
        int tongtien = 0;
        void loadBill()
        {
            List<Bill> list = BillDAO.Instance.HienThiPhieuXuat(PhieuXuatDAO.Instance.GetMaxIDPhieuXuat());
            foreach(Bill item in list)
            {
               
                ListViewItem lsv = new ListViewItem(item.TenKH.ToString());
                lsv.SubItems.Add(item.TenHH.ToString());
                lsv.SubItems.Add(item.NgayXuat.ToString());
                lsv.SubItems.Add(item.SoLuong.ToString());
                lsv.SubItems.Add(item.DonGia.ToString());
                lsv.SubItems.Add(item.ThanhTien.ToString());
                tongtien += item.ThanhTien;
                lvxuat.Items.Add(lsv);
            }
            //CultureInfo culture = new CultureInfo("vi-VN");

            txtTongTien.Text = tongtien.ToString();
        }

        void LoadLoaiHH()
        {
            List<LoaiHangHoa> listCategory = LoaiHHDAO.Instance.LoadListLoaiHH();
            cbLoaiHangHoa.DataSource = listCategory;
            cbLoaiHangHoa.DisplayMember = "TenLoaiHH";
        }
   
        void LoadListHHbyLoaiHH(int id)
        {
            List<HangHoa> listFood = HangHoaDAO.Instance.GetLishHangHoabyLoaiHH(id);
            cbHangHoa.DataSource = listFood;
            cbHangHoa.DisplayMember = "TenHH";
        }

        private void cbLoaiHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            LoaiHangHoa selected = cb.SelectedItem as LoaiHangHoa;
            id = selected.MaLoaiHH;

            LoadListHHbyLoaiHH(id);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            int MaKH = int.Parse(txtMaKhachHang.Text);
            string MaHH = (cbHangHoa.SelectedItem as HangHoa).MaHH;
            int counts = (int)nmSoLuong.Value;
            string ghiChu = txtGhiChu.Text;
            if(ChiTietPhieuXuatDAO.Instance.InsertChiTietPhieuXuat(MaHH,MaKH,PhieuXuatDAO.Instance.GetMaxIDPhieuXuat(),counts,ghiChu))
            {
                MessageBox.Show("Them Thanh Cong");
                loadBill();
            }
            else
            {
                MessageBox.Show("Them Thanh cong");
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMaKhachHang_TextChanged(object sender, EventArgs e)
        {

        }

        void ThemTongTien(int tongtien,int mpx)
        {
            PhieuXuatDAO.Instance.ThemTongTien(tongtien, mpx);
        }


        private void btnThemPhieuXuat_Click(object sender, EventArgs e)
        {
            int mpx = PhieuXuatDAO.Instance.GetMaxIDPhieuXuat();
            int tontien = int.Parse(txtTongTien.Text);
            ThemTongTien(tongtien,mpx);
            lvxuat.Items.Clear();
            DateTime ngayxuat = dtngayxuat.Value;
            if(PhieuXuatDAO.Instance.InsertPhieuXuat(ngayxuat))
            {
                MessageBox.Show("Thanh Toan Cong");
                LoadPhieuXuat();
                txtTongTien.Text = "";
            }
            else
            {
                MessageBox.Show("Thanh Toan that bai");
            }


        }
    }
}
