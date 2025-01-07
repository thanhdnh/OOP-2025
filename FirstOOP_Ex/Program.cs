/*
    Trong một cửa hàng bán thực phẩm, có 3 loại thực phẩm:
    Gạo, Ngô, Thịt. Mỗi loại thực phẩm có: tên thực phẩm,
    giá bán, số lượng còn. Mỗi khách hàng mua thực phẩm sẽ
    có các thông tin: tên khách hàng, sđt.
    Hãy xây dựng chương trình cho phép mô phỏng quá trình
    mua hàng: khách chọn mặt hàng cần mua, số lượng mua, sau
    đó in ra hoá đơn. Quá trình mô phỏng cho nhiều khách
    hàng mua hàng.
    - Khai báo lớp ThucPham, KhachHang.
    - Khai báo danh sách hàng hoá.
    - Khai báo danh sách khách hàng.
    - Khai báo phương thức mua hàng
    - Khai báo phương thức in hoá đơn
*/

public class ThucPham
{
    public string tenthucpham;
    public double giaban;
    public uint slcon;
}
public class KhachHang
{
    public string tenkhachhang;
    public string sdt;
}
public class Program
{
    static List<ThucPham> dsThucPham = new List<ThucPham>();
    public static ThucPham NhapTP(string ten, double gia, uint soluong){
        ThucPham tp = new ThucPham();
        tp.tenthucpham = ten;
        tp.giaban = gia;
        tp.slcon = soluong;
        return tp;
    }
    static List<KhachHang> dsKhachHang = new List<KhachHang>();
    public static KhachHang NhapKH(string tenkhachhang, string sdt){
        KhachHang kh = new KhachHang();
        kh.tenkhachhang = tenkhachhang;
        kh.sdt = sdt;
        return kh;
    }
    public static void MuaHang(KhachHang kh, 
                    List<ThucPham> dstp, List<uint> sls){
        /*dstp.Add(dsThucPham[0]); //mua Gạo
        sls.Add(10);
        dstp.Add(dsThucPham[2]); //mua Thịt
        sls.Add(5);*/
        InHoaDon(kh, dstp, sls);
    }
    public static void InHoaDon(KhachHang kh, 
                    List<ThucPham> dstp, List<uint> sls){
        Console.WriteLine("=====Hóa đơn=====");
        Console.WriteLine($"KH: {kh.tenkhachhang} - {kh.sdt}");
        Console.WriteLine("Các mặt hàng:");
        int index = 0;
        foreach(ThucPham tp in dstp)
            Console.WriteLine("+ Tên: "+tp.tenthucpham+"\n"
                               + "Giá: "+tp.giaban+"\n"
                               + "Số lượng: "+sls[index++]+"\n");
        Console.WriteLine("---");
        double sum = TinhGia(dstp, sls);
        Console.WriteLine($"Tổng giá: {sum}\n\n");  
    }
    public static double TinhGia(List<ThucPham> dstp, List<uint> sls){
        double sum = 0;
        for(int i=0; i<dstp.Count; i++)
            sum += dstp[i].giaban * sls[i];
        return sum;
    }
    public static void Main(string[] args)
    {
        ThucPham thucpham1 = NhapTP("Gạo", 100, 100);
        dsThucPham.Add(thucpham1);
        ThucPham thucpham2 = NhapTP("Ngô", 120, 100);
        dsThucPham.Add(thucpham2);
        ThucPham thucpham3 = NhapTP("Thịt", 540, 100);
        dsThucPham.Add(thucpham3);
        KhachHang khachhang1 = NhapKH("Nguyễn Văn A", "0123456789");
        dsKhachHang.Add(khachhang1);
        KhachHang khachhang2 = NhapKH("Nguyễn Văn B", "0367213412");
        dsKhachHang.Add(khachhang2);

        List<ThucPham> muatp1 = new List<ThucPham>();
        List<uint> soluong1 = new List<uint>();
        muatp1.Add(dsThucPham[0]); soluong1.Add(5); //Mua gạo 
        muatp1.Add(dsThucPham[2]); soluong1.Add(2); //Mua thịt
        MuaHang(dsKhachHang[0], muatp1, soluong1);
        //InHoaDon(khachhang1, muatp1, soluong1);

        List<ThucPham> muatp2 = new List<ThucPham>();
        List<uint> soluong2 = new List<uint>();
        muatp2.Add(dsThucPham[1]); soluong2.Add(10); //Mua ngô
        muatp2.Add(dsThucPham[2]); soluong2.Add(3); //Mua thịt
        MuaHang(dsKhachHang[1], muatp2, soluong2);
        //InHoaDon(khachhang2, muatp2, soluong2);

        /*
        =====Hóa đơn=====
        KH: Nguyễn Văn A - 0123456789
        Các mặt hàng:
        + Tên: Gạo
        Giá: 100
        Số lượng: 5

        + Tên: Thịt
        Giá: 540
        Số lượng: 2

        ---
        Tổng giá: 1580


        =====Hóa đơn=====
        KH: Nguyễn Văn B - 0367213412
        Các mặt hàng:
        + Tên: Ngô
        Giá: 120
        Số lượng: 10

        + Tên: Thịt
        Giá: 540
        Số lượng: 3

        ---
        Tổng giá: 2820
        */
    }

}