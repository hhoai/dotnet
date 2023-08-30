using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    class NhanVien : TinhLuong
    {
        public string maNV { get; set; }
        public string chucVu { get; set; }

        public override double Luong()
        {
            float pc = 0f;
            switch (chucVu)
            {
                case "Giam doc":
                    pc = 0.5f;
                    break;
                case "Pho giam doc": 
                case "Truong phong":
                    pc = 0.4f;
                    break;
                case "Pho phong":
                    pc = 0.3f;
                    break;
                default:
                    pc = 0f;
                    break;
            }
            return (hsLuong + pc) * luongCB;
        }
    }
}

/*
 public override float GetLuong()
        {
            float pc = 0f;
            if (ChucVu == "Giam doc")
            {
                pc = 0.5f;
            }
            else if (ChucVu == "Truong phong" || ChucVu == "Pho giam doc")
            {
                pc = 0.4f;
            }
            else if (ChucVu == "Pho phong")
            {
                pc = 0.3f;
            }
            return (HeSoLuong + pc) * LuongCoBan;
        }
*/