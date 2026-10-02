using System;

namespace AutoSpeed
{
    public abstract class PhuongTien
    {
        // Fields
        private string _maPT;
        private string _tenHang;
        private int _namSanXuat;
        private decimal _giaGoc;

        // Property MaPT
        public string MaPT
        {
            get
            {
                return _maPT;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _maPT = "PT000";
                }
                else
                {
                    _maPT = value;
                }
            }
        }

        // Property TenHang
        public string TenHang
        {
            get
            {
                return _tenHang;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Tên hãng không được để trống!");
                }

                _tenHang = value;
            }
        }

        // Property NamSanXuat
        public int NamSanXuat
        {
            get
            {
                return _namSanXuat;
            }
            set
            {
                int namHienTai = DateTime.Now.Year;

                if (value < 1900 || value > namHienTai)
                {
                    throw new ArgumentException("Năm sản xuất không hợp lệ!");
                }

                _namSanXuat = value;
            }
        }

        // Property GiaGoc
        public decimal GiaGoc
        {
            get
            {
                return _giaGoc;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Giá gốc phải lớn hơn 0!");
                }

                _giaGoc = value;
            }
        }

        // Constructor
        public PhuongTien(
            string maPT,
            string tenHang,
            int namSanXuat,
            decimal giaGoc)
        {
            MaPT = maPT;
            TenHang = tenHang;
            NamSanXuat = namSanXuat;
            GiaGoc = giaGoc;
        }

        // Abstract Method
        public abstract decimal TinhGiaLanBanh();

        // Virtual Method
        public virtual string GetInfo()
        {
            return "Mã PT: " + MaPT
                + ", Tên hãng: " + TenHang
                + ", Năm sản xuất: " + NamSanXuat
                + ", Giá gốc: " + GiaGoc.ToString("N0") + " VNĐ";
        }
    }
}