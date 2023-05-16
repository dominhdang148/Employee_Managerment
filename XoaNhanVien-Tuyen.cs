using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static List<NhanVien> danhSachNhanVien = new List<NhanVien>();

	static void Main(string[] args)
	{
		// Thêm dữ liệu mẫu vào danh sách nhân viên
		danhSachNhanVien.Add(new NhanVien("NV001", "Nguyễn Văn A", "Nam", DateTime.Parse("1990-01-15"), "Quản lý", 15000000));
		danhSachNhanVien.Add(new NhanVien("NV002", "Trần Thị B", "Nữ", DateTime.Parse("1995-05-20"), "Lễ tân", 8000000));
		danhSachNhanVien.Add(new NhanVien("NV003", "Phạm Văn C", "Nam", DateTime.Parse("1992-11-03"), "Nhân viên phục vụ", 6000000));
		danhSachNhanVien.Add(new NhanVien("NV004", "Lê Thị D", "Nữ", DateTime.Parse("1998-07-10"), "Nhân viên phục vụ", 6000000));
		danhSachNhanVien.Add(new NhanVien("NV005", "Hoàng Văn E", "Nam", DateTime.Parse("1993-03-18"), "Quản lý", 12000000));
		danhSachNhanVien.Add(new NhanVien("NV006", "Trần Thị F", "Nữ", DateTime.Parse("1994-08-22"), "Lễ tân", 7500000));
		danhSachNhanVien.Add(new NhanVien("NV007", "Võ Văn G", "Nam", DateTime.Parse("1996-12-07"), "Nhân viên phục vụ", 5500000));
		danhSachNhanVien.Add(new NhanVien("NV008", "Nguyễn Thị H", "Nữ", DateTime.Parse("1999-05-14"), "Nhân viên phục vụ", 5500000));
		danhSachNhanVien.Add(new NhanVien("NV009", "Trần Văn I", "Nam", DateTime.Parse("1991-09-25"), "Kế toán", 9000000));
		// Gọi hàm xóa nhân viên với mã nhân viên cần xóa
		XoaNhanVien("NV002");

		// Gọi hàm xóa nhân viên theo tên
		XoaNhanVienTheoTen("Nguyễn Văn A");

		// Gọi hàm xóa nhân viên có cùng công việc
		XoaNhanVienCungCongViec("Nhân viên phục vụ");

		// In danh sách nhân viên sau khi xóa
		Console.WriteLine("Danh sách nhân viên sau khi xóa:");
		InDanhSachNhanVien();

		Console.ReadLine();
	}

	static void XoaNhanVien(string maNhanVien)
	{
		// Tìm nhân viên có mã tương ứng trong danh sách
		var nhanVien = danhSachNhanVien.FirstOrDefault(nv => nv.MaNV == maNhanVien);

		if (nhanVien != null)
		{
			// Xóa nhân viên khỏi danh sách
			danhSachNhanVien.Remove(nhanVien);
			Console.WriteLine("Đã xóa nhân viên thành công!");
		}
		else
		{
			Console.WriteLine("Không tìm thấy nhân viên có mã như vậy!");
		}
	}

	static void XoaNhanVienTheoTen(string tenNhanVien)
	{
		// Tìm nhân viên có tên tương ứng trong danh sách
		var nhanVien = danhSachNhanVien.FirstOrDefault(nv => nv.TenNV == tenNhanVien);

		if (nhanVien != null)
		{
			// Xóa nhân viên khỏi danh sách
			danhSachNhanVien.Remove(nhanVien);
			Console.WriteLine("Đã xóa nhân viên thành công!");
		}
		else
		{
			Console.WriteLine("Không tìm thấy nhân viên có tên như vậy!");
		}
	}

	static void XoaNhanVienCungCongViec(string congViec)
	{
		// Tìm những nhân viên có cùng công việc trong danh sách
		var nhanVienCungCongViec = danhSachNhanVien.Where(nv => nv.ChucVu == congViec).ToList();

		if (nhanVienCungCongViec.Any())
		{
			// Xóa từng nhân viên khỏi danh sách
			foreach (var nhanVien in nhanVienCungCongViec)
			{
				danhSachNhanVien.Remove(nhanVien);
			}

			Console.WriteLine("Đã xóa các nhân viên cùng công việc thành công!");
		}
		else
		{
			Console.WriteLine("Không tìm thấy nhân viên có công việc như vậy!");
		}
	}
	static void XoaNhanVienCungChucVu(string chucVu)
	{
		// Tìm những nhân viên có cùng chức vụ trong danh sách
		var nhanVienCungChucVu = danhSachNhanVien.Where(nv => nv.ChucVu == chucVu).ToList();

		if (nhanVienCungChucVu.Any())
		{
			// Xóa từng nhân viên khỏi danh sách
			foreach (var nhanVien in nhanVienCungChucVu)
			{
				danhSachNhanVien.Remove(nhanVien);
			}

			Console.WriteLine("Đã xóa các nhân viên cùng chức vụ thành công!");
		}
		else
		{
			Console.WriteLine("Không tìm thấy nhân viên có chức vụ như vậy!");
		}
	}
	static void InDanhSachNhanVien()
	{
		// In danh sách nhân viên
		foreach (var nhanVien in danhSachNhanVien)
		{
			Console.WriteLine($"{nhanVien.MaNV} - {nhanVien.TenNV} - {nhanVien.GioiTinh} - {nhanVien.NgaySinh.ToShortDateString()} - {nhanVien.ChucVu} - {nhanVien.Luong}");
		}
	}
}

class NhanVien
	{
		public string MaNV { get; set; }
		public string TenNV { get; set; }
		public string GioiTinh { get; set; }
		public DateTime NgaySinh { get; set; }
		public string ChucVu { get; set; }
		public decimal Luong { get; set; }

	public NhanVien(string maNV, string tenNV, string gioiTinh, DateTime ngaySinh, string chucVu, decimal luong)
	{
		MaNV = maNV;
		TenNV = tenNV;
		GioiTinh = gioiTinh;
		NgaySinh = ngaySinh;
		ChucVu = chucVu;
		Luong = luong;
	}
}