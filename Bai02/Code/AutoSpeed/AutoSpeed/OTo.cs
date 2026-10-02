using System;

namespace AutoSpeed
{
    public class OTo : PhuongTien
    {
        // Fields
        private int _soChoNgoi;
        private double _dungTichDongCo;

        // Property SoChoNgoi
        public int SoChoNgoi
        {
            get
            {
                return _soChoNgoi;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Số chỗ ngồi phải lớn hơn 0!");
                }

                _soChoNgoi = value;
            }
        }

        // Property DungTichDongCo
        public double DungTichDongCo
        {
            get
            {
                return _dungTichDongCo;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Dung tích động cơ phải lớn hơn 0!");
                }

                _dungTichDongCo = value;
            }
        }

        // Constructor
        public OTo(
            string maPT,
            string tenHang,
            int namSanXuat,
            decimal giaGoc,
            int soChoNgoi,
            double dungTichDongCo)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            SoChoNgoi = soChoNgoi;
            DungTichDongCo = dungTichDongCo;
        }

        // Tính giá lăn bánh
        public override decimal TinhGiaLanBanh()
        {
            if (SoChoNgoi <= 9)
            {
                return GiaGoc
                    + GiaGoc * 0.12m
                    + GiaGoc * 0.30m;
            }
            else
            {
                return GiaGoc
                    + GiaGoc * 0.10m;
            }
        }

        // Bổ sung thông tin của ô tô
        public override string GetInfo()
        {
            return base.GetInfo()
                + ", Số chỗ ngồi: " + SoChoNgoi
                + ", Dung tích động cơ: " + DungTichDongCo + " L";
        }
    }
}