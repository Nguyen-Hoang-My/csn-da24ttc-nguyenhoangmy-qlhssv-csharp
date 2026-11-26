namespace QLHSSV
{
    partial class frmThongKe
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbLoai = new Label();
            cboLoai = new ComboBox();
            lbKhoaHoc = new Label();
            cboKhoaHoc = new ComboBox();
            lbNganh = new Label();
            cboNganh = new ComboBox();
            btnXuatExcel = new Button();
            lbKetQua = new Label();
            dgvThongKe = new DataGridView();
            lbBieuDo = new Label();
            pnlBieuDo = new Panel();
            lblChiTiet = new Label();
            dgvChiTiet = new DataGridView();
            lblTong = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvThongKe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            //
            // lbLoai
            //
            lbLoai.AutoSize = true;
            lbLoai.Location = new Point(12, 16);
            lbLoai.Name = "lbLoai";
            lbLoai.TabIndex = 0;
            lbLoai.Text = "Thống kê theo:";
            //
            // cboLoai
            //
            cboLoai.FormattingEnabled = true;
            cboLoai.Location = new Point(105, 12);
            cboLoai.Name = "cboLoai";
            cboLoai.Size = new Size(230, 23);
            cboLoai.TabIndex = 1;
            //
            // lbKhoaHoc
            //
            lbKhoaHoc.AutoSize = true;
            lbKhoaHoc.Location = new Point(350, 16);
            lbKhoaHoc.Name = "lbKhoaHoc";
            lbKhoaHoc.TabIndex = 2;
            lbKhoaHoc.Text = "Khóa học:";
            //
            // cboKhoaHoc
            //
            cboKhoaHoc.FormattingEnabled = true;
            cboKhoaHoc.Location = new Point(415, 12);
            cboKhoaHoc.Name = "cboKhoaHoc";
            cboKhoaHoc.Size = new Size(150, 23);
            cboKhoaHoc.TabIndex = 3;
            //
            // lbNganh
            //
            lbNganh.AutoSize = true;
            lbNganh.Location = new Point(580, 16);
            lbNganh.Name = "lbNganh";
            lbNganh.TabIndex = 4;
            lbNganh.Text = "Ngành:";
            //
            // cboNganh
            //
            cboNganh.FormattingEnabled = true;
            cboNganh.Location = new Point(630, 12);
            cboNganh.Name = "cboNganh";
            cboNganh.Size = new Size(220, 23);
            cboNganh.TabIndex = 5;
            //
            // btnXuatExcel
            //
            btnXuatExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatExcel.Location = new Point(868, 8);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(120, 31);
            btnXuatExcel.TabIndex = 6;
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = true;
            //
            // lbKetQua
            //
            lbKetQua.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKetQua.AutoSize = true;
            lbKetQua.Location = new Point(12, 50);
            lbKetQua.Name = "lbKetQua";
            lbKetQua.TabIndex = 7;
            lbKetQua.Text = "Kết quả thống kê:";
            //
            // dgvThongKe
            //
            dgvThongKe.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            dgvThongKe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThongKe.Location = new Point(12, 70);
            dgvThongKe.Name = "dgvThongKe";
            dgvThongKe.Size = new Size(600, 250);
            dgvThongKe.TabIndex = 8;
            //
            // lbBieuDo
            //
            lbBieuDo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbBieuDo.AutoSize = true;
            lbBieuDo.Location = new Point(625, 50);
            lbBieuDo.Name = "lbBieuDo";
            lbBieuDo.TabIndex = 9;
            lbBieuDo.Text = "Biểu đồ số sinh viên:";
            //
            // pnlBieuDo
            //
            pnlBieuDo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlBieuDo.BackColor = Color.White;
            pnlBieuDo.BorderStyle = BorderStyle.FixedSingle;
            pnlBieuDo.Location = new Point(625, 70);
            pnlBieuDo.Name = "pnlBieuDo";
            pnlBieuDo.Size = new Size(363, 250);
            pnlBieuDo.TabIndex = 10;
            //
            // lblChiTiet
            //
            lblChiTiet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblChiTiet.AutoSize = true;
            lblChiTiet.Location = new Point(12, 332);
            lblChiTiet.Name = "lblChiTiet";
            lblChiTiet.TabIndex = 11;
            lblChiTiet.Text = "Danh sách sinh viên:";
            //
            // dgvChiTiet
            //
            dgvChiTiet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Location = new Point(12, 352);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.Size = new Size(976, 260);
            dgvChiTiet.TabIndex = 12;
            //
            // lblTong
            //
            lblTong.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTong.AutoSize = true;
            lblTong.Location = new Point(12, 620);
            lblTong.Name = "lblTong";
            lblTong.TabIndex = 13;
            lblTong.Text = "";
            //
            // frmThongKe
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(lbLoai);
            Controls.Add(cboLoai);
            Controls.Add(lbKhoaHoc);
            Controls.Add(cboKhoaHoc);
            Controls.Add(lbNganh);
            Controls.Add(cboNganh);
            Controls.Add(btnXuatExcel);
            Controls.Add(lbKetQua);
            Controls.Add(dgvThongKe);
            Controls.Add(lbBieuDo);
            Controls.Add(pnlBieuDo);
            Controls.Add(lblChiTiet);
            Controls.Add(dgvChiTiet);
            Controls.Add(lblTong);
            Name = "frmThongKe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống kê sinh viên";
            ((System.ComponentModel.ISupportInitialize)dgvThongKe).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbLoai;
        private ComboBox cboLoai;
        private Label lbKhoaHoc;
        private ComboBox cboKhoaHoc;
        private Label lbNganh;
        private ComboBox cboNganh;
        private Button btnXuatExcel;
        private Label lbKetQua;
        private DataGridView dgvThongKe;
        private Label lbBieuDo;
        private Panel pnlBieuDo;
        private Label lblChiTiet;
        private DataGridView dgvChiTiet;
        private Label lblTong;
    }
}
