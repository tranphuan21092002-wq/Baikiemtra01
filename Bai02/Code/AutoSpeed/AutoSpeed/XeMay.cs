using System;

namespace AutoSpeed
{
    public class XeMay : PhuongTien
    {
        // Field
        private int _dungTichXylanh;

        // Property DungTichXylanh
        public int DungTichXylanh
        {
            get
            {
                return _dungTichXylanh;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Dung tích xylanh phải lớn hơn 0!");
                }

                _dungTichXylanh = value;
            }
        }

        // Constructor
        public XeMay(
            string maPT,
            string tenHang,
            int namSanXuat,
            decimal giaGoc,
            int dungTichXylanh)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            DungTichXylanh = dungTichXylanh;
        }

        // Tính giá lăn bánh
        public override decimal TinhGiaLanBanh()
        {
            if (DungTichXylanh < 175)
            {
                return GiaGoc + GiaGoc * 0.02m;
            }
            else
            {
                return GiaGoc + GiaGoc * 0.05m;
            }
        }

        // Bổ sung thông tin xe máy
        public override string GetInfo()
        {
            return base.GetInfo()
                + ", Dung tích xylanh: "
                + DungTichXylanh + " cc";
        }
    }
}