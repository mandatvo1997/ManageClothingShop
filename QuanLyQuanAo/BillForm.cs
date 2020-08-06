using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyQuanAo
{
    public partial class BillForm : Form
    {
        class Bill
        {
            public string MaBill { get; set; }
            public string NgayLap { get; set; }
            public int MaKH { get; set; }
            public string TenKH { get; set; }
            public string DiaChiKH { get; set; }
            public int PhoneKH { get; set; }
            public int MaAo { get; set; }
            public string TenAo { get; set; }
            public string MauAo { get; set; }
            public string SizeAo { get; set; }
            public int SLAo { get; set; }
            public int GiaAo { get; set; }
            public int MaQuan { get; set; }
            public string TenQuan { get; set; }
            public string MauQuan { get; set; }
            public string SizeQuan { get; set; }
            public int SLQuan { get; set; }
            public int GiaQuan { get; set; }
            public int TongTien { get; set; }
        }
        public BillForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NRM7FS1;Initial Catalog=QLShop;Integrated Security=True");
        void loadInfo()
        {
            
        }

        //Hàm Add Bill mới:
        private void btn_AddBill_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có chắc muốn lưu Hóa Đơn này không!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
               if(txtMaAo.Text=="")
                {
                    con.Open();
                    string sql = "INSERT INTO Bill VALUES(@maBill, @ngayLap, @maKH, @tenKH,@diachi,@sodt,@maAo,@tenAo,@mauAo,@sizeAo,@slAo,@giaAo,@maQuan,@tenQuan,@mauQuan,@sizeQuan,@slQuan,@giaQuan,@tong)";
                    SqlCommand command = new SqlCommand(sql, con);
                    command.Parameters.AddWithValue("maBill", txtSoBill.Text);
                    command.Parameters.AddWithValue("ngayLap", txtNgayLap.Text);
                    command.Parameters.AddWithValue("maKH", txtMaKH.Text);
                    command.Parameters.AddWithValue("tenKH", txtTenKH.Text);
                    command.Parameters.AddWithValue("diachi", txtDiaChi.Text);
                    command.Parameters.AddWithValue("sodt", txtSDT.Text);

                    command.Parameters.AddWithValue("maAo", 1);
                    command.Parameters.AddWithValue("tenAo", txtTenAo.Text);
                    command.Parameters.AddWithValue("mauAo", txtMauAo.Text);
                    command.Parameters.AddWithValue("sizeAo", txtSizeAo.Text);
                    command.Parameters.AddWithValue("slAo", txtSLAo.Text);
                    command.Parameters.AddWithValue("giaAo", txtGiaAo.Text);

                    command.Parameters.AddWithValue("maQuan", txtMaQuan.Text);
                    command.Parameters.AddWithValue("tenQuan", txtTenQuan.Text);
                    command.Parameters.AddWithValue("mauQuan", txtMauQuan.Text);
                    command.Parameters.AddWithValue("sizeQuan", txtSizeQuan.Text);
                    command.Parameters.AddWithValue("slQuan", txtSLQuan.Text);
                    command.Parameters.AddWithValue("giaQuan", txtGiaQuan.Text);

                    command.Parameters.AddWithValue("tong", txtTongTien.Text);
                    command.ExecuteNonQuery();
                    con.Close();
                }
               else if (txtMaQuan.Text=="")
                {
                    con.Open();
                    string sql = "INSERT INTO Bill VALUES(@maBill, @ngayLap, @maKH, @tenKH,@diachi,@sodt,@maAo,@tenAo,@mauAo,@sizeAo,@slAo,@giaAo,@maQuan,@tenQuan,@mauQuan,@sizeQuan,@slQuan,@giaQuan,@tong)";
                    SqlCommand command = new SqlCommand(sql, con);
                    command.Parameters.AddWithValue("maBill", txtSoBill.Text);
                    command.Parameters.AddWithValue("ngayLap", txtNgayLap.Text);
                    command.Parameters.AddWithValue("maKH", txtMaKH.Text);
                    command.Parameters.AddWithValue("tenKH", txtTenKH.Text);
                    command.Parameters.AddWithValue("diachi", txtDiaChi.Text);
                    command.Parameters.AddWithValue("sodt", txtSDT.Text);

                    command.Parameters.AddWithValue("maAo", txtMaAo.Text);
                    command.Parameters.AddWithValue("tenAo", txtTenAo.Text);
                    command.Parameters.AddWithValue("mauAo", txtMauAo.Text);
                    command.Parameters.AddWithValue("sizeAo", txtSizeAo.Text);
                    command.Parameters.AddWithValue("slAo", txtSLAo.Text);
                    command.Parameters.AddWithValue("giaAo", txtGiaAo.Text);

                    command.Parameters.AddWithValue("maQuan", 1);
                    command.Parameters.AddWithValue("tenQuan", txtTenQuan.Text);
                    command.Parameters.AddWithValue("mauQuan", txtMauQuan.Text);
                    command.Parameters.AddWithValue("sizeQuan", txtSizeQuan.Text);
                    command.Parameters.AddWithValue("slQuan", txtSLQuan.Text);
                    command.Parameters.AddWithValue("giaQuan", txtGiaQuan.Text);

                    command.Parameters.AddWithValue("tong", txtTongTien.Text);
                    command.ExecuteNonQuery();
                    con.Close();
                }
               else
                {
                    con.Open();
                    string sql = "INSERT INTO Bill VALUES(@maBill, @ngayLap, @maKH, @tenKH,@diachi,@sodt,@maAo,@tenAo,@mauAo,@sizeAo,@slAo,@giaAo,@maQuan,@tenQuan,@mauQuan,@sizeQuan,@slQuan,@giaQuan,@tong)";
                    SqlCommand command = new SqlCommand(sql, con);
                    command.Parameters.AddWithValue("maBill", txtSoBill.Text);
                    command.Parameters.AddWithValue("ngayLap", txtNgayLap.Text);
                    command.Parameters.AddWithValue("maKH", txtMaKH.Text);
                    command.Parameters.AddWithValue("tenKH", txtTenKH.Text);
                    command.Parameters.AddWithValue("diachi", txtDiaChi.Text);
                    command.Parameters.AddWithValue("sodt", txtSDT.Text);

                    command.Parameters.AddWithValue("maAo", txtMaAo.Text);
                    command.Parameters.AddWithValue("tenAo", txtTenAo.Text);
                    command.Parameters.AddWithValue("mauAo", txtMauAo.Text);
                    command.Parameters.AddWithValue("sizeAo", txtSizeAo.Text);
                    command.Parameters.AddWithValue("slAo", txtSLAo.Text);
                    command.Parameters.AddWithValue("giaAo", txtGiaAo.Text);

                    command.Parameters.AddWithValue("maQuan", txtMaQuan.Text);
                    command.Parameters.AddWithValue("tenQuan", txtTenQuan.Text);
                    command.Parameters.AddWithValue("mauQuan", txtMauQuan.Text);
                    command.Parameters.AddWithValue("sizeQuan", txtSizeQuan.Text);
                    command.Parameters.AddWithValue("slQuan", txtSLQuan.Text);
                    command.Parameters.AddWithValue("giaQuan", txtGiaQuan.Text);

                    command.Parameters.AddWithValue("tong", txtTongTien.Text);
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            UpdateAo();
            UpdateQuan();
        }

        //Hàm cập nhật số lượng Áo còn trong Kho:
        void UpdateAo()
        {
            con.Open();
            string sql1 = "UPDATE AoMac SET SoluongAo = SoluongAo - @slAo WHERE MaAo = @maAo";
            SqlCommand command = new SqlCommand(sql1, con);
            command.Parameters.AddWithValue("maAo", txtMaAo.Text);
            command.Parameters.AddWithValue("slAo", txtSLAo.Text);
            command.ExecuteNonQuery();
            con.Close();
        }

        //Hàm cập nhật số lượng Quần còn trong Kho:
        void UpdateQuan()
        {
            con.Open();
            string sql1 = "UPDATE Quan SET SoluongQuan = SoluongQuan - @slQuan WHERE MaQuan = @maQuan";
            SqlCommand command = new SqlCommand(sql1, con);
            command.Parameters.AddWithValue("maQuan", txtMaQuan.Text);
            command.Parameters.AddWithValue("slQuan", txtSLQuan.Text);
            command.ExecuteNonQuery();
            con.Close();
        }


        public string ngaylap;
        public string makh;
        public string tenkh;
        public string diachi;
        public string sdt;
        public string maao;
        public string tenao;
        public string mauao;
        public string sizeao;
        public string slao;
        public string giaao;
        public string maquan;
        public string tenquan;
        public string mauquan;
        public string sizequan;
        public string slquan;
        public string giaquan;
        public string tong;
        
        private void BillForm_Load(object sender, EventArgs e)
        {
            txtNgayLap.Text = ngaylap;
            txtMaKH.Text = makh;
            txtTenKH.Text = tenkh;
            txtDiaChi.Text = diachi;
            txtSDT.Text = sdt;
            txtMaAo.Text = maao;
            txtTenAo.Text = tenao;
            txtMauAo.Text = mauao;
            txtSizeAo.Text = sizeao;
            txtSLAo.Text = slao;
            txtGiaAo.Text = giaao;
            txtMaQuan.Text = maquan;
            txtTenQuan.Text = tenquan;
            txtMauQuan.Text = mauquan;
            txtSizeQuan.Text = sizequan;
            txtSLQuan.Text = slquan;
            txtGiaQuan.Text = giaquan;
            txtTongTien.Text = tong;
        }

        
    }
}
