--PROC_Cap nhap thong tin ca nhan
USE _QLBH

exec USP_DangNhap @TaiKhoan = obama,@MatKhau = 1
go
CREATE PROC USP_UpdateAccounts
@userName NVARCHAR(200), @displayName NVARCHAR(100), @password NVARCHAR(200), @newPassword NVARCHAR(200)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.TaiKhoan WHERE TaiKhoan = @userName AND MatKhau = @password
	
	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassword = NULL OR @newPassword = '')
		BEGIN
			UPDATE dbo.TaiKhoan SET TenDN = @displayName WHERE TaiKhoan = @userName
		END		
		ELSE
			UPDATE dbo.TaiKhoan SET TenDN = @displayName, MatKhau = @newPassword WHERE TaiKhoan = @userName
	end
END
GO


 