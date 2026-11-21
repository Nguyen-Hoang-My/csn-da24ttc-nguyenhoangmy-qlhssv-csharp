namespace QLHSSV
{
    internal static class Program
    {
       
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            
            while (true)
            {
                string tenDangNhap, hoTen, vaiTro;
                using (frmDangNhap dangNhap = new frmDangNhap())
                {
                    if (dangNhap.ShowDialog() != DialogResult.OK) break;
                    tenDangNhap = dangNhap.TenDangNhap;
                    hoTen = dangNhap.HoTen;
                    vaiTro = dangNhap.VaiTro;
                }

                frmMain main = new frmMain(tenDangNhap, hoTen, vaiTro);
                Application.Run(main);
                if (!main.DangXuat) break;
            }
        }
    }
}