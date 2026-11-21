namespace QLHSSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThaotacCSDL db = new ThaotacCSDL();
            dataGridView1.DataSource = db.execute("SELECT MAKHOA, TENKHOA, LOAIDONVI FROM KHOA");
        }
    }
}
