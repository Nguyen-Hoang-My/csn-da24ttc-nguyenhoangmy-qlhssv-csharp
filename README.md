# Xây dựng ứng dụng quản lý hồ sơ sinh viên

Đồ án Thực tập Cơ sở ngành, Khoa Công nghệ Thông tin, Trường Kỹ thuật và Công nghệ, Đại học Trà Vinh.

| | |
|---|---|
| Sinh viên | Nguyễn Hoàng Mỹ |
| MSSV | 110124242 |
| Lớp | DA24TTC |
| GVHD | TS. Nguyễn Trần Diễm Hạnh |
| Email | hoangmy2006of@gmail.com |
| Điện thoại | 0392698374 |

## Giới thiệu

Ứng dụng desktop giúp bộ phận giáo vụ quản lý hồ sơ và kết quả học tập của sinh viên, từ lúc nhập học cho đến khi in bảng điểm toàn khóa. Dữ liệu được lưu trên SQL Server với đầy đủ ràng buộc khóa ngoại, nên việc sửa hay xóa một khoa, một ngành không để lại bản ghi mồ côi như khi quản lý bằng nhiều file Excel rời rạc.

## Chức năng chính

- Quản lý danh mục: khoa, bộ môn (thuộc khoa), ngành học (thuộc bộ môn), khóa học
- Quản lý sinh viên theo ngành và khóa, gồm hồ sơ nhập học và địa chỉ (tỉnh/thành phố, xã/phường, số nhà, tên đường)
- Quản lý học phần và chương trình học của từng ngành
- Đăng ký học theo học kỳ: chỉ được đăng ký học phần thuộc chương trình học, không đăng ký trùng
- Quản lý điểm: tính điểm trung bình học kỳ, điểm trung bình tích lũy (hệ 10 và hệ 4), xếp loại học lực
- In hồ sơ sinh viên và bảng điểm toàn khóa
- Đăng nhập, phân quyền: quản trị viên, cán bộ giáo vụ, sinh viên
- Thống kê sinh viên theo khoa, ngành, khóa và theo xếp loại học lực; xuất Excel

## Công nghệ

- Ngôn ngữ: C# (Windows Forms), .NET
- Cơ sở dữ liệu: Microsoft SQL Server, truy cập qua ADO.NET
- Kiến trúc: 3 lớp (GUI – BLL – DAL)
- Báo cáo: Microsoft Report Viewer (RDLC); xuất Excel: ClosedXML
- Công cụ: Visual Studio, SQL Server Management Studio, draw.io / StarUML, Git/GitHub

## Cấu trúc thư mục

```
├── setup/             Script tạo CSDL, dữ liệu mẫu, hướng dẫn cài đặt
├── src/               Mã nguồn ứng dụng
├── progress-report/   Báo cáo tiến độ hằng tuần
└── thesis/
    ├── doc/           Tài liệu dạng .docx (đề cương, quyển báo cáo)
    ├── pdf/           Tài liệu dạng .pdf
    ├── html/          Tài liệu dạng web
    ├── abs/           Slide, video demo
    └── refs/          Tài liệu tham khảo
```

## Cài đặt và chạy chương trình

*Đang cập nhật. Phần này sẽ được bổ sung khi có script CSDL và bản chạy được đầu tiên.*

## Tiến độ

| Tuần | Thời gian | Nội dung chính | Trạng thái |
|---|---|---|---|
| 1 | 12/10 – 18/10/2026 | Khảo sát, phân tích yêu cầu, thiết kế CSDL, tạo repository | Đang thực hiện |
| 2 | 02/11 – 08/11/2026 | Hoàn thiện CSDL, đăng nhập – phân quyền, các form danh mục | Chưa bắt đầu |
| 3 | 23/11 – 29/11/2026 | Sinh viên, học phần – chương trình học, đăng ký học, điểm | Chưa bắt đầu |
| 4 | 14/12 – 20/12/2026 | In ấn, thống kê, xuất Excel, kiểm thử, hoàn thiện báo cáo | Chưa bắt đầu |
| | 28/12/2026 | Nộp quyển báo cáo và link GitHub | |
