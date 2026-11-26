using System.Data;
using System.Diagnostics;
using ClosedXML.Excel;

namespace QLHSSV
{
    // Xuất dữ liệu trên DataGridView ra file Excel bằng thư viện ClosedXML.
    // Chỉ lấy các cột đang hiện, dùng tiêu đề cột trên lưới làm tiêu đề trong Excel.
    static class XuatExcel
    {
        public static void xuat(string tenFileGoiY, params (string tenSheet, string tieuDe, DataGridView luoi)[] cacBang)
        {
            using SaveFileDialog hop = new SaveFileDialog();
            hop.Filter = "Excel (*.xlsx)|*.xlsx";
            hop.FileName = tenFileGoiY + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";
            if (hop.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    foreach (var bang in cacBang)
                        ghiSheet(wb.Worksheets.Add(bang.tenSheet), bang.tieuDe, bang.luoi);
                    wb.SaveAs(hop.FileName);
                }
                if (MessageBox.Show("Đã xuất file:\n" + hop.FileName + "\n\nMở file luôn không?", "Xuất Excel",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    Process.Start(new ProcessStartInfo(hop.FileName) { UseShellExecute = true });
            }
            catch (IOException)
            {
                MessageBox.Show("Không ghi được file. Nếu file đang mở trong Excel thì đóng lại rồi xuất lại.", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất Excel bị lỗi: " + ex.Message, "Lỗi");
            }
        }

        static void ghiSheet(IXLWorksheet ws, string tieuDe, DataGridView luoi)
        {
            List<DataGridViewColumn> cot = luoi.Columns.Cast<DataGridViewColumn>()
                                               .Where(c => c.Visible).OrderBy(c => c.DisplayIndex).ToList();
            int soCot = Math.Max(cot.Count, 1);

            ws.Cell(1, 1).Value = tieuDe;
            ws.Range(1, 1, 1, soCot).Merge().Style.Font.SetBold().Font.SetFontSize(14)
              .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Cell(2, 1).Value = "Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") +
                                  "   -   Người xuất: " + PhienDangNhap.HoTen;
            ws.Range(2, 1, 2, soCot).Merge().Style.Font.SetItalic();

            const int dongDau = 4;
            for (int j = 0; j < cot.Count; j++)
                ws.Cell(dongDau, j + 1).Value = cot[j].HeaderText;

            int dong = dongDau + 1;
            foreach (DataGridViewRow r in luoi.Rows)
            {
                if (r.IsNewRow) continue;
                for (int j = 0; j < cot.Count; j++)
                {
                    object? v = r.Cells[cot[j].Index].Value;
                    IXLCell o = ws.Cell(dong, j + 1);
                    switch (v)
                    {
                        case null:
                        case DBNull:
                            break;
                        case DateTime d:
                            o.Value = d;
                            o.Style.DateFormat.Format = "dd/MM/yyyy";
                            break;
                        case int or long or short or byte or decimal or double or float:
                            o.Value = Convert.ToDouble(v);
                            break;
                        default:
                            o.Value = v.ToString();
                            break;
                    }
                }
                dong++;
            }

            if (cot.Count > 0)
            {
                IXLRange bang = ws.Range(dongDau, 1, Math.Max(dong - 1, dongDau), cot.Count);
                bang.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
                          .Border.SetInsideBorder(XLBorderStyleValues.Thin);
                ws.Range(dongDau, 1, dongDau, cot.Count).Style.Font.SetBold()
                  .Fill.SetBackgroundColor(XLColor.LightGray)
                  .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Columns(1, cot.Count).AdjustToContents(dongDau, dong);
            }
        }
    }
}
