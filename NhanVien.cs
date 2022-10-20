using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_XULYANH
{
    class NhanVien
    {
        private string manv;
        private byte[] anh;

        public NhanVien(string manv, byte[] anh)
        {
            this.manv = manv;
            this.anh = anh;
        }

        public string Manv { get => manv; set => manv = value; }
        public byte[] Anh { get => anh; set => anh = value; }
    }
}
