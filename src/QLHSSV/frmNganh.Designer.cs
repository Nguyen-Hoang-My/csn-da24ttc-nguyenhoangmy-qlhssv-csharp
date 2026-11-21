using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace QLHSSV
{
    partial class frmNganh
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
            grpThongTin = new GroupBox();
            lbMaNganh = new Label();
            txtMaNganh = new TextBox();
            lbTenNganh = new Label();
            txtTenNganh = new TextBox();
            lbBoMon = new Label();
            cboBoMon = new ComboBox();
            lbThoiGian = new Label();
            txtThoiGian = new TextBox();
            lbMoTa = new Label();
            txtMoTa = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lbTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTim = new Button();
            dgvNganh = new DataGridView();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNganh).BeginInit();
            SuspendLayout();
            //
            // lbMaNganh
            //
            lbMaNganh.AutoSize = true;
            lbMaNganh.Location = new Point(15, 33);
            lbMaNganh.Name = "lbMaNganh";
            lbMaNganh.TabIndex = 0;
            lbMaNganh.Text = "Mã ngành (*)";
            //
            // txtMaNganh
            //
            txtMaNganh.Location = new Point(130, 30);
            txtMaNganh.Name = "txtMaNganh";
            txtMaNganh.Size = new Size(270, 23);
            txtMaNganh.TabIndex = 1;
            //
            // lbTenNganh
            //
            lbTenNganh.AutoSize = true;
            lbTenNganh.Location = new Point(15, 68);
            lbTenNganh.Name = "lbTenNganh";
            lbTenNganh.TabIndex = 2;
            lbTenNganh.Text = "Tên ngành (*)";
            //
            // txtTenNganh
            //
            txtTenNganh.Location = new Point(130, 65);
            txtTenNganh.Name = "txtTenNganh";
            txtTenNganh.Size = new Size(270, 23);
            txtTenNganh.TabIndex = 3;
            //
            // lbBoMon
            //
            lbBoMon.AutoSize = true;
            lbBoMon.Location = new Point(15, 103);
            lbBoMon.Name = "lbBoMon";
            lbBoMon.TabIndex = 4;
            lbBoMon.Text = "Thuộc bộ môn (*)";
            //
            // cboBoMon
            //
            cboBoMon.Location = new Point(130, 100);
            cboBoMon.Name = "cboBoMon";
            cboBoMon.Size = new Size(270, 23);
            cboBoMon.TabIndex = 5;
            //
            // lbThoiGian
            //
            lbThoiGian.AutoSize = true;
            lbThoiGian.Location = new Point(430, 33);
            lbThoiGian.Name = "lbThoiGian";
            lbThoiGian.TabIndex = 6;
            lbThoiGian.Text = "Số năm ĐT (*)";
            //
            // txtThoiGian
            //
            txtThoiGian.Location = new Point(540, 30);
            txtThoiGian.Name = "txtThoiGian";
            txtThoiGian.Size = new Size(300, 23);
            txtThoiGian.TabIndex = 7;
            //
            // lbMoTa
            //
            lbMoTa.AutoSize = true;
            lbMoTa.Location = new Point(430, 68);
            lbMoTa.Name = "lbMoTa";
            lbMoTa.TabIndex = 8;
            lbMoTa.Text = "Mô tả";
            //
            // txtMoTa
            //
            txtMoTa.Multiline = true;
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Location = new Point(540, 65);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(300, 40);
            txtMoTa.TabIndex = 9;
            //
            // grpThongTin
            //
            grpThongTin.Controls.Add(lbMaNganh);
            grpThongTin.Controls.Add(txtMaNganh);
            grpThongTin.Controls.Add(lbTenNganh);
            grpThongTin.Controls.Add(txtTenNganh);
            grpThongTin.Controls.Add(lbBoMon);
            grpThongTin.Controls.Add(cboBoMon);
            grpThongTin.Controls.Add(lbThoiGian);
            grpThongTin.Controls.Add(txtThoiGian);
            grpThongTin.Controls.Add(lbMoTa);
            grpThongTin.Controls.Add(txtMoTa);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(856, 150);
            grpThongTin.TabIndex = 10;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin ngành học";
            //
            // btnThem
            //
            btnThem.Location = new Point(12, 175);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 32);
            btnThem.TabIndex = 11;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            //
            // btnSua
            //
            btnSua.Location = new Point(110, 175);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 32);
            btnSua.TabIndex = 12;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            //
            // btnXoa
            //
            btnXoa.Location = new Point(208, 175);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 32);
            btnXoa.TabIndex = 13;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            //
            // btnLamMoi
            //
            btnLamMoi.Location = new Point(306, 175);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(90, 32);
            btnLamMoi.TabIndex = 14;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            //
            // lbTimKiem
            //
            lbTimKiem.AutoSize = true;
            lbTimKiem.Location = new Point(520, 182);
            lbTimKiem.Name = "lbTimKiem";
            lbTimKiem.TabIndex = 15;
            lbTimKiem.Text = "Tìm kiếm:";
            //
            // txtTimKiem
            //
            txtTimKiem.Location = new Point(620, 179);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(160, 23);
            txtTimKiem.TabIndex = 16;
            //
            // btnTim
            //
            btnTim.Location = new Point(790, 175);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(78, 32);
            btnTim.TabIndex = 17;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            //
            // dgvNganh
            //
            dgvNganh.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNganh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNganh.Location = new Point(12, 220);
            dgvNganh.Name = "dgvNganh";
            dgvNganh.Size = new Size(856, 368);
            dgvNganh.TabIndex = 18;
            //
            // frmNganh
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 600);
            Controls.Add(grpThongTin);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(lbTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnTim);
            Controls.Add(dgvNganh);
            Name = "frmNganh";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý ngành học";
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNganh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lbMaNganh;
        private TextBox txtMaNganh;
        private Label lbTenNganh;
        private TextBox txtTenNganh;
        private Label lbBoMon;
        private ComboBox cboBoMon;
        private Label lbThoiGian;
        private TextBox txtThoiGian;
        private Label lbMoTa;
        private TextBox txtMoTa;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lbTimKiem;
        private TextBox txtTimKiem;
        private Button btnTim;
        private DataGridView dgvNganh;
    }
}