using System;
using System.Collections.Generic;

#nullable disable

namespace kttx21.Models
{
    public partial class SanPham
    {
        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public string MaLoai { get; set; }
        public int? SoLuong { get; set; }
        public float? DonGia { get; set; }

        public virtual LoaiSanPham MaLoaiNavigation { get; set; }
    }
}
