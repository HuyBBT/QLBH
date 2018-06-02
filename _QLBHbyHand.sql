CREATE DATABASE _QLBH
GO

USE _QLBH	
go

create table DonVi
(
  MaDV int identity(1,1) primary key,
  TenDV nvarchar(200)
)
go

create table NhaCC
(
  MaNCC int identity(1,1) primary key,
  TenNCC nvarchar(200),
  DiaChi nvarchar(200),
  SDT nvarchar(20),
  Email nvarchar(200),

)
go

create table KhachHang
(
  MaKH int identity(1,1) primary key,
  TenKH nvarchar(200),
  DiaChi nvarchar(200),
  SDT nvarchar(20),
  Email nvarchar(200),
)
go

create table HangHoa
(
  MaHH nvarchar(200) primary key,
  TenHH nvarchar(200),
  MaDV int not null,
  MaNCC int not null,
  
  foreign key(MaDV) references DonVi(MaDV),
  foreign key(MaNCC) references NhaCC(MaNCC)

)
go

create table NhanVien
(
  MaNV nvarchar(200) primary key,
  TenNV nvarchar(200),
  DiaChi nvarchar(200),
  SDT nvarchar(20),
  Email nvarchar(200)
)
go

create table PhieuNhap
(
  MaPN int identity(1,1) primary key,
  NgayNhap Date
)
go
create table ChiTietPhieuNhap
(
  MaCTPN int identity(1,1) primary key,
  MaHH nvarchar(200) not null,
  MaPN int not null,
  Counts int,
  Gia float default 0,
  GhiChu nvarchar(200),
  MaNV nvarchar(200),

  foreign key(MaHH) references HangHoa(MaHH),
  foreign key(MaPN) references PhieuNhap(MaPN),
  foreign key(MaNV) references NhanVien(MaNV)
)

go
create table PhieuXuat
(
  MaPX int identity(1,1) primary key,
  NgayXuat Date
)

go
create table ChiTietPhieuXuat
(
  MaCTPX int identity(1,1) primary key,
  MaHH nvarchar(200) not null,
  MaKH int not null,
  MaPX int not null,
  Counts int,
  GhiChu nvarchar(200),

  foreign key(MaHH) references HangHoa(MaHH),
  foreign key(MaPX) references PhieuXuat(MaPX),
  foreign key(MaKH) references KhachHang(MaKH)
)
go

create table LoaiTaiKhoan
(
  Ma int identity(1,1) primary key,
  Ten nvarchar(200)
)
go

create table TaiKhoan
(
  TaiKhoan nvarchar(200) primary key,
  TenDN nvarchar(100),
  MatKhau nvarchar(200),
  MaLTK int not null,

  foreign key (MaLTK) references LoaiTaiKhoan(Ma)
)
go