using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoSpeed
{
    public class QuanLyPhuongTien
    {
        // Danh sách phương tiện
        private List<PhuongTien> danhSachPhuongTien;

        // Constructor
        public QuanLyPhuongTien()
        {
            danhSachPhuongTien = new List<PhuongTien>();
        }

        // Thêm phương tiện
        public void AddPhuongTien(PhuongTien pt)
        {
            if (pt == null)
            {
                throw new ArgumentNullException("pt");
            }

            danhSachPhuongTien.Add(pt);
        }

        // Hiển thị tất cả phương tiện
        public void DisplayAll()
        {
            if (danhSachPhuongTien.Count == 0)
            {
                Console.WriteLine("Danh sách phương tiện đang trống!");
                return;
            }

            foreach (PhuongTien pt in danhSachPhuongTien)
            {
                Console.WriteLine(pt.GetInfo());

                Console.WriteLine(
                    "Giá lăn bánh: "
                    + pt.TinhGiaLanBanh().ToString("N0")
                    + " VNĐ");

                Console.WriteLine("-----------------------------------");
            }
        }

        // Tìm phương tiện có giá lăn bánh cao nhất
        public PhuongTien FindMaxGiaLanBanh()
        {
            if (danhSachPhuongTien.Count == 0)
            {
                return null;
            }

            return danhSachPhuongTien
                .OrderByDescending(pt => pt.TinhGiaLanBanh())
                .First();
        }

        // Tìm phương tiện theo tên hãng
        public List<PhuongTien> SearchByName(string keyword)
        {
            return danhSachPhuongTien
                .Where(pt => pt.TenHang.ToLower().Contains(keyword.ToLower()))
                .ToList();
        }
    }
}