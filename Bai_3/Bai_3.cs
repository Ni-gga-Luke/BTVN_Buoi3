using System;
using System.Collections.Generic;

namespace QuanLyBanHang
{
    struct Product
    {
        public string Code;
        public string Name;
        public double Price;
        public int Quantity;
        public string Category;

        public double Revenue
        {
            get { return Price * Quantity; }
        }
    }

    class Bai_3
    {
        static List<Product> list = new List<Product>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Them san pham");
                Console.WriteLine("2. Xem thong tin theo ma");
                Console.WriteLine("3. San pham ban chay nhat");
                Console.WriteLine("4. San pham ban chay nhat theo danh muc");
                Console.WriteLine("5. Tong doanh thu theo danh muc");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon: ");
                string chon = Console.ReadLine();

                if (chon == "1") ThemSanPham();
                else if (chon == "2") XemTheoMa();
                else if (chon == "3") BanChayNhat();
                else if (chon == "4") BanChayTheoDanhMuc();
                else if (chon == "5") TongDoanhThuTheoDanhMuc();
                else if (chon == "0") break;
                else Console.WriteLine("Lua chon sai!");
            }
        }

        static void ThemSanPham()
        {
            Product p;
            Console.Write("Nhap ma san pham: ");
            p.Code = Console.ReadLine();

            Console.Write("Ten: ");
            p.Name = Console.ReadLine();

            Console.Write("Gia: ");
            p.Price = double.Parse(Console.ReadLine());

            Console.Write("So luong: ");
            p.Quantity = int.Parse(Console.ReadLine());

            Console.Write("Danh muc: ");
            p.Category = Console.ReadLine();

            bool found = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Code == p.Code)
                {
                    var old = list[i];
                    old.Quantity += p.Quantity;
                    old.Price = p.Price;
                    old.Name = p.Name;
                    old.Category = p.Category;
                    list[i] = old;
                    found = true;
                    Console.WriteLine("Da cap nhat san pham co san!");
                    break;
                }
            }

            if (!found)
            {
                list.Add(p);
                Console.WriteLine("Da them san pham moi!");
            }
        }

        static void XemTheoMa()
        {
            Console.Write("Nhap ma san pham: ");
            string code = Console.ReadLine();

            foreach (var p in list)
            {
                if (p.Code == code)
                {
                    Console.WriteLine($"Ten: {p.Name}, Gia: {p.Price}, SL: {p.Quantity}, Muc: {p.Category}, Doanh thu: {p.Revenue}");
                    return;
                }
            }
            Console.WriteLine("Khong tim thay san pham!");
        }

        static void BanChayNhat()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Chua co du lieu!");
                return;
            }

            var best = list[0];
            foreach (var p in list)
            {
                if (p.Quantity > best.Quantity)
                    best = p;
            }

            Console.WriteLine($"Ban chay nhat: {best.Name} ({best.Quantity} sp), Doanh thu: {best.Revenue}");
        }

        static void BanChayTheoDanhMuc()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Chua co du lieu!");
                return;
            }

            Console.Write("Nhap danh muc: ");
            string muc = Console.ReadLine();

            bool found = false;
            var best = new Product();

            foreach (var p in list)
            {
                if (p.Category == muc)
                {
                    if (!found || p.Quantity > best.Quantity)
                    {
                        best = p;
                        found = true;
                    }
                }
            }

            if (found)
                Console.WriteLine($"Ban chay nhat trong danh muc {muc}: {best.Name} ({best.Quantity} sp), Doanh thu: {best.Revenue}");
            else
                Console.WriteLine("Khong tim thay danh muc nay!");
        }

        static void TongDoanhThuTheoDanhMuc()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Chua co du lieu!");
                return;
            }

            List<string> danhMuc = new List<string>();

            foreach (var p in list)
            {
                if (!danhMuc.Contains(p.Category))
                    danhMuc.Add(p.Category);
            }

            foreach (var muc in danhMuc)
            {
                double tong = 0;
                foreach (var p in list)
                {
                    if (p.Category == muc)
                        tong += p.Revenue;
                }
                Console.WriteLine($"Danh muc {muc}: Tong doanh thu = {tong}");
            }
        }
    }
}
