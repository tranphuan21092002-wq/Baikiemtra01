using System;
using System.Collections.Generic;

namespace AutoSpeed
{
    internal class Program
    {
        // Tao danh sach phuong tien dung chung cho TC04 va TC05
        static List<PhuongTien> danhSach = new List<PhuongTien>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("======================================");
                Console.WriteLine("        HE THONG AUTOSPEED");
                Console.WriteLine("======================================");
                Console.WriteLine("1. TC01 - Kiem tra NamSanXuat");
                Console.WriteLine("2. TC02 - Tinh gia lan banh OTo");
                Console.WriteLine("3. TC03 - Tinh gia lan banh XeMay");
                Console.WriteLine("4. TC04 - Kiem tra da hinh");
                Console.WriteLine("5. TC05 - Tim phuong tien gia cao nhat");
                Console.WriteLine("0. Thoat");
                Console.WriteLine("======================================");

                Console.Write("Nhap lua chon: ");
                string luaChon = Console.ReadLine();

                Console.WriteLine();

                switch (luaChon)
                {
                    case "1":
                        TestCase01();
                        break;

                    case "2":
                        TestCase02();
                        break;

                    case "3":
                        TestCase03();
                        break;

                    case "4":
                        TestCase04();
                        break;

                    case "5":
                        TestCase05();
                        break;

                    case "0":
                        Console.WriteLine("Da thoat chuong trinh.");
                        return;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Nhan Enter de tiep tuc...");
                Console.ReadLine();
            }
        }

        // =====================================================
        // TC01: Kiem tra nam san xuat khong hop le
        // =====================================================
        static void TestCase01()
        {
            Console.WriteLine("========== TC01 ==========");
            Console.WriteLine("Kiem tra NamSanXuat");

            try
            {
                Console.Write("Nhap ma PT: ");
                string maPT = Console.ReadLine();

                Console.Write("Nhap ten hang: ");
                string tenHang = Console.ReadLine();

                Console.Write("Nhap nam san xuat: ");
                int namSanXuat = int.Parse(Console.ReadLine());

                Console.Write("Nhap gia goc: ");
                decimal giaGoc = decimal.Parse(Console.ReadLine());

                Console.Write("Nhap so cho ngoi: ");
                int soChoNgoi = int.Parse(Console.ReadLine());

                Console.Write("Nhap dung tich dong co (L): ");
                double dungTich = double.Parse(Console.ReadLine());

                // Thu tao doi tuong OTo
                OTo oto = new OTo(
                    maPT,
                    tenHang,
                    namSanXuat,
                    giaGoc,
                    soChoNgoi,
                    dungTich
                );

                Console.WriteLine("Tao OTo thanh cong!");
                Console.WriteLine(oto.GetInfo());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }
        }

        // =====================================================
        // TC02: Tinh gia lan banh OTo
        // =====================================================
        static void TestCase02()
        {
            Console.WriteLine("========== TC02 ==========");
            Console.WriteLine("Tinh gia lan banh OTo");

            try
            {
                Console.Write("Nhap ma PT: ");
                string maPT = Console.ReadLine();

                Console.Write("Nhap ten hang: ");
                string tenHang = Console.ReadLine();

                Console.Write("Nhap nam san xuat: ");
                int namSanXuat = int.Parse(Console.ReadLine());

                Console.Write("Nhap gia goc: ");
                decimal giaGoc = decimal.Parse(Console.ReadLine());

                Console.Write("Nhap so cho ngoi: ");
                int soChoNgoi = int.Parse(Console.ReadLine());

                Console.Write("Nhap dung tich dong co (L): ");
                double dungTich = double.Parse(Console.ReadLine());

                OTo oto = new OTo(
                    maPT,
                    tenHang,
                    namSanXuat,
                    giaGoc,
                    soChoNgoi,
                    dungTich
                );

                decimal giaLanBanh = oto.TinhGiaLanBanh();

                Console.WriteLine();
                Console.WriteLine("Thong tin OTo:");
                Console.WriteLine(oto.GetInfo());

                Console.WriteLine(
                    "Gia lan banh: "
                    + giaLanBanh.ToString("N0")
                    + " VNĐ"
                );
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }
        }

        // =====================================================
        // TC03: Tinh gia lan banh XeMay
        // =====================================================
        static void TestCase03()
        {
            Console.WriteLine("========== TC03 ==========");
            Console.WriteLine("Tinh gia lan banh XeMay");

            try
            {
                Console.Write("Nhap ma PT: ");
                string maPT = Console.ReadLine();

                Console.Write("Nhap ten hang: ");
                string tenHang = Console.ReadLine();

                Console.Write("Nhap nam san xuat: ");
                int namSanXuat = int.Parse(Console.ReadLine());

                Console.Write("Nhap gia goc: ");
                decimal giaGoc = decimal.Parse(Console.ReadLine());

                Console.Write("Nhap dung tich xylanh (cc): ");
                int dungTichXylanh = int.Parse(Console.ReadLine());

                XeMay xeMay = new XeMay(
                    maPT,
                    tenHang,
                    namSanXuat,
                    giaGoc,
                    dungTichXylanh
                );

                decimal giaLanBanh = xeMay.TinhGiaLanBanh();

                Console.WriteLine();
                Console.WriteLine("Thong tin XeMay:");
                Console.WriteLine(xeMay.GetInfo());

                Console.WriteLine(
                    "Gia lan banh: "
                    + giaLanBanh.ToString("N0")
                    + " VNĐ"
                );
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }
        }

        // =====================================================
        // TC04: Kiem tra da hinh
        // =====================================================
        static void TestCase04()
        {
            Console.WriteLine("========== TC04 ==========");
            Console.WriteLine("Kiem tra Polymorphism");
            Console.WriteLine();

            // Xoa danh sach cu de test lai TC04
            danhSach.Clear();

            try
            {
                // -------------------------
                // Nhap OTo
                // -------------------------
                Console.WriteLine("--- Nhap thong tin OTo ---");

                Console.Write("Nhap ma PT: ");
                string maOto = Console.ReadLine();

                Console.Write("Nhap ten hang: ");
                string tenOto = Console.ReadLine();

                Console.Write("Nhap nam san xuat: ");
                int namOto = int.Parse(Console.ReadLine());

                Console.Write("Nhap gia goc: ");
                decimal giaOto = decimal.Parse(Console.ReadLine());

                Console.Write("Nhap so cho ngoi: ");
                int soChoOto = int.Parse(Console.ReadLine());

                Console.Write("Nhap dung tich dong co (L): ");
                double dungTichOto = double.Parse(Console.ReadLine());

                OTo oto = new OTo(
                    maOto,
                    tenOto,
                    namOto,
                    giaOto,
                    soChoOto,
                    dungTichOto
                );

                // -------------------------
                // Nhap XeMay
                // -------------------------
                Console.WriteLine();
                Console.WriteLine("--- Nhap thong tin XeMay ---");

                Console.Write("Nhap ma PT: ");
                string maXeMay = Console.ReadLine();

                Console.Write("Nhap ten hang: ");
                string tenXeMay = Console.ReadLine();

                Console.Write("Nhap nam san xuat: ");
                int namXeMay = int.Parse(Console.ReadLine());

                Console.Write("Nhap gia goc: ");
                decimal giaXeMay = decimal.Parse(Console.ReadLine());

                Console.Write("Nhap dung tich xylanh (cc): ");
                int dungTichXeMay = int.Parse(Console.ReadLine());

                XeMay xeMay = new XeMay(
                    maXeMay,
                    tenXeMay,
                    namXeMay,
                    giaXeMay,
                    dungTichXeMay
                );

                // Them ca OTo va XeMay vao List<PhuongTien>
                danhSach.Add(oto);
                danhSach.Add(xeMay);

                Console.WriteLine();
                Console.WriteLine("--- Danh sach PhuongTien ---");

                // Bien pt co kieu PhuongTien
                // nhung C# tu dong goi dung ham cua OTo/XeMay
                foreach (PhuongTien pt in danhSach)
                {
                    Console.WriteLine(pt.GetInfo());

                    Console.WriteLine(
                        "Gia lan banh: "
                        + pt.TinhGiaLanBanh().ToString("N0")
                        + " VNĐ"
                    );

                    Console.WriteLine("--------------------------------");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }
        }

        // =====================================================
        // TC05: Tim phuong tien co gia lan banh cao nhat
        // =====================================================
        static void TestCase05()
        {
            Console.WriteLine("========== TC05 ==========");
            Console.WriteLine("Tim phuong tien co gia lan banh cao nhat");

            if (danhSach.Count == 0)
            {
                Console.WriteLine(
                    "Chua co danh sach phuong tien!"
                );

                Console.WriteLine(
                    "Hay chay TC04 truoc de them OTo va XeMay."
                );

                return;
            }

            QuanLyPhuongTien ql = new QuanLyPhuongTien();

            // Dua cac phuong tien trong danh sach vao QuanLyPhuongTien
            foreach (PhuongTien pt in danhSach)
            {
                ql.AddPhuongTien(pt);
            }

            // Tim phuong tien co gia lan banh lon nhat
            PhuongTien max = ql.FindMaxGiaLanBanh();

            Console.WriteLine();
            Console.WriteLine("Phuong tien co gia lan banh cao nhat:");

            Console.WriteLine(max.GetInfo());

            Console.WriteLine(
                "Gia lan banh: "
                + max.TinhGiaLanBanh().ToString("N0")
                + " VNĐ"
            );
        }
    }
}