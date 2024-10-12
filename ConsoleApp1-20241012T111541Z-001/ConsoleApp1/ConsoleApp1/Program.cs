using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public abstract class PhuongTien
        {
            public string TenPhuongTien { get; set; }
            public string LoaiNhienLieu { get; set; }

            public abstract void DiChuyen();
        }
        public class XeHoi : PhuongTien, IThongTinThem
        {
            public override void DiChuyen()
            {
                Console.WriteLine("Is moving");
            }

            public int TocDoToiDa()
            {
                return 200; // km/h
            }

            public double MucTieuThuNhienLieu()
            {
                return 10.5; // liters per 100 km
            }
        }

        public class XeDap : PhuongTien, IThongTinThem
        {
            public override void DiChuyen()
            {
                Console.WriteLine("Is moving");
            }

            public int TocDoToiDa()
            {
                return 30; // km/h
            }

            public double MucTieuThuNhienLieu()
            {
                return 0; // liters per 100 km (not applicable)
            }
        }
        public interface IThongTinThem
        {
            int TocDoToiDa();
            double MucTieuThuNhienLieu();
        }
        static void Main(string[] args)
        {
            List<PhuongTien> phuongTiens = new List<PhuongTien>
        {
            new XeHoi { TenPhuongTien = "Toyota", LoaiNhienLieu = "Fuel" },
            new XeDap { TenPhuongTien = "Train", LoaiNhienLieu = "Coel" }
        };

            foreach (var phuongTien in phuongTiens)
            {
                Console.WriteLine($"Ten phuong tien: {phuongTien.TenPhuongTien}");
                Console.WriteLine($"Loai nhien lieu: {phuongTien.LoaiNhienLieu}");
                phuongTien.DiChuyen();

                if (phuongTien is IThongTinThem)
                {
                    IThongTinThem them = (IThongTinThem)phuongTien;
                    Console.WriteLine($"Toc do toi da: {them.TocDoToiDa()} km/h");
                    Console.WriteLine($"Muc tieu thu nhien lieu: {them.MucTieuThuNhienLieu():F2} lit/100 km");
                }

                Console.WriteLine();
            }
        }
    }
}
