namespace QLHSSV
{
    static class QuyCheDiem
    {
        public const decimal DiemToiDaThiLan2 = 6.9m;

        public static decimal? diemHocPhan(decimal? diemQuaTrinh, decimal? diemThi, decimal? diemThiLan2, decimal tyLeQuaTrinh)
        {
            if (diemThi == null) return null;
            if (diemQuaTrinh == null && tyLeQuaTrinh > 0) return null;
            decimal diemThiTinh = diemThiLan2 ?? diemThi.Value;
            decimal diem = Math.Round((diemQuaTrinh ?? 0) * tyLeQuaTrinh + diemThiTinh * (1 - tyLeQuaTrinh),
                                      1, MidpointRounding.AwayFromZero);
            if (diemThiLan2 != null && diem > DiemToiDaThiLan2) diem = DiemToiDaThiLan2;
            return diem;
        }

        public static string diemChu(decimal? diem)
        {
            if (diem == null) return "";
            if (diem >= 9.0m) return "A";
            if (diem >= 8.0m) return "B+";
            if (diem >= 7.0m) return "B";
            if (diem >= 6.5m) return "C+";
            if (diem >= 5.5m) return "C";
            if (diem >= 5.0m) return "D+";
            if (diem >= 4.0m) return "D";
            return "F";
        }
    }
}
