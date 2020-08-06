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
    public partial class NhanVien : Form
    {
        //Khai báo kiểu dữ liệu:
        class Quan
        {
            public int MaQuan { get; set; }
            public string TenQuan { get; set; }
            public string MauQuan { get; set; }
            public string SizeQuan { get; set; }
            public int SoluongQuan { get; set; }
            public int GiaQuan { get; set; }
        }
        class Ao
        {
            public int MaAo { get; set; }
            public string TenAo { get; set; }
            public string MauAo { get; set; }
            public string SizeAo { get; set; }
            public int SoluongAo { get; set; }
            public int GiaAo { get; set; }
        }
        class NhanVienShop
        {
            public int MaNV { get; set; }
            public string TenNV { get; set; }
            public string EmailNV { get; set; }
            public int PhoneNV { get; set; }
            public string ID { get; set; }
            public string Password { get; set; }
        }
        class KhachHangShop
        {
            public int MaKH { get; set; }
            public string TenKH { get; set; }
            public string DiaChiKH { get; set; }
            public int PhoneKH { get; set; }
        }
        

        //Nội dung Coding:
        public NhanVien()
        {
            InitializeComponent();
            loadQuan();
            loadAo();
            loadNV();
            loadKH();
            
            //Tab Bán Hàng:
            loadGridAo();
            loadGridQuan();
            loadGridKH();
            loadGridLS();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NRM7FS1;Initial Catalog=QLShop;Integrated Security=True");

        void loadQuan()
        {
            con.Open();
            string sql = "Select * from Quan";
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            QuanDataGridView.DataSource = dt;
        }
        void loadAo()
        {
            con.Open();
            string sql = "Select * from AoMac";
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            AoDataGridView.DataSource = dt;
        }
        void loadNV()
        {
            con.Open();
            string sql = "Select * from Employees";
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            load_DataNV.DataSource = dt;
        }
        void loadKH()
        {
            con.Open();
            string sql = "Select * from Customers";
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            load_DataKH.DataSource = dt;
        }

        //Load bảng Grid bên Tab Bán Hàng:
        void loadGridAo()
        {
            con.Open();
            string sql = "Select * from AoMac";
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }
        void loadGridQuan()
        {
            con.Open();
            string sql = "Select * from Quan";
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView2.DataSource = dt;
        }
        void loadGridKH()
        {
            con.Open();
            string sql = "Select * from Customers";
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView3.DataSource = dt;
        }
        void loadGridLS()
        {
            con.Open();
            string sql = "Select * from Bill";
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView4.DataSource = dt;
        }


        //Tab Sản Phẩm:
        //Grid Áo:
        private void AoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = AoDataGridView.CurrentCell.RowIndex;
            txt_IDAo.Text = AoDataGridView.Rows[t].Cells[0].Value.ToString();
            txt_TenAo.Text = AoDataGridView.Rows[t].Cells[1].Value.ToString();
            txt_MauAo.Text = AoDataGridView.Rows[t].Cells[2].Value.ToString();
            comboBox_SizeAo.Text = AoDataGridView.Rows[t].Cells[3].Value.ToString();
            txt_SLAo.Text = AoDataGridView.Rows[t].Cells[4].Value.ToString();
            txt_GiaAo.Text = AoDataGridView.Rows[t].Cells[5].Value.ToString();
        }

        //Grid Quần:
        private void QuanDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = QuanDataGridView.CurrentCell.RowIndex;
            txt_IDQuan.Text = QuanDataGridView.Rows[t].Cells[0].Value.ToString();
            txt_TenQuan.Text = QuanDataGridView.Rows[t].Cells[1].Value.ToString();
            txt_MauQuan.Text = QuanDataGridView.Rows[t].Cells[2].Value.ToString();
            comboBox_SizeQuan.Text = QuanDataGridView.Rows[t].Cells[3].Value.ToString();
            txt_SLQuan.Text = QuanDataGridView.Rows[t].Cells[4].Value.ToString();
            txt_GiaQuan.Text = QuanDataGridView.Rows[t].Cells[5].Value.ToString();
        }

        //Hàm chức năng bên Áo:
        //Btn Add:
        private void btn_AddAo_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "INSERT INTO AoMac VALUES(@tenAo, @mauAo, @sizeAo, @soluongAo, @giaAo)";
            SqlCommand command = new SqlCommand(sql, con);
            command.Parameters.AddWithValue("tenAo", txt_TenAo.Text);
            command.Parameters.AddWithValue("mauAo", txt_MauAo.Text);
            command.Parameters.AddWithValue("sizeAo", comboBox_SizeAo.Text);
            command.Parameters.AddWithValue("soluongAo", txt_SLAo.Text);
            command.Parameters.AddWithValue("giaAo", txt_GiaAo.Text);
            command.ExecuteNonQuery();
            con.Close();
            loadAo();
        }

        //Btn Delete:
        private void btn_DeleteAo_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có chắc muốn xóa không!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                con.Open();
                string sql = "DELETE FROM AoMac WHERE MaAo=@maAo ";
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("maAo", txt_IDAo.Text);
                command.Parameters.AddWithValue("tenAo", txt_TenAo.Text);
                command.Parameters.AddWithValue("mauAo", txt_MauAo.Text);
                command.Parameters.AddWithValue("sizeAo", comboBox_SizeAo.Text);
                command.Parameters.AddWithValue("soluongAo", txt_SLAo.Text);
                command.Parameters.AddWithValue("giaAo", txt_GiaAo.Text);
                command.ExecuteNonQuery();
                con.Close();
                loadAo();
            }
        }

        //Btn Update:
        private void btn_UpdateAo_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có chắc muốn sửa không!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                con.Open();
                string sql = "UPDATE AoMac SET TenAo=@tenAo,MauAo=@mauAo,SizeAo=@sizeAo,SoluongAo=@soluongAo,GiaAo=@giaAo WHERE MaAo=@maAo ";
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("maAo", txt_IDAo.Text);
                command.Parameters.AddWithValue("tenAo", txt_TenAo.Text);
                command.Parameters.AddWithValue("mauAo", txt_MauAo.Text);
                command.Parameters.AddWithValue("sizeAo", comboBox_SizeAo.Text);
                command.Parameters.AddWithValue("soluongAo", txt_SLAo.Text);
                command.Parameters.AddWithValue("giaAo", txt_GiaAo.Text);
                command.ExecuteNonQuery();
                con.Close();
                loadAo();
            }
        }

        //Btn Refresh:
        private void btn_RefreshAo_Click(object sender, EventArgs e)
        {
            txt_IDAo.Text = "";
            txt_TenAo.Text = "";
            txt_MauAo.Text = "";
            comboBox_SizeAo.Text = "";
            txt_SLAo.Text = "";
            txt_GiaAo.Text = "";
            loadAo();
        }

        //Hàm để Enable 3 chức năng:
        private void txt_TenAo_TextChanged(object sender, EventArgs e)
        {
            btn_AddAo.Enabled = true;
            btn_DeleteAo.Enabled = true;
            btn_UpdateAo.Enabled = true;
        }

        //Hàm chức năng bên Quần:
        //Btn Add:
        private void btn_AddQuan_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "INSERT INTO Quan VALUES(@tenQuan, @mauQuan, @sizeQuan, @soluongQuan, @giaQuan)";
            SqlCommand command = new SqlCommand(sql, con);
            command.Parameters.AddWithValue("tenQuan", txt_TenQuan.Text);
            command.Parameters.AddWithValue("mauQuan", txt_MauQuan.Text);
            command.Parameters.AddWithValue("sizeQuan", comboBox_SizeQuan.Text);
            command.Parameters.AddWithValue("soluongQuan", txt_SLQuan.Text);
            command.Parameters.AddWithValue("giaQuan", txt_GiaQuan.Text);
            command.ExecuteNonQuery();
            con.Close();
            loadQuan();
        }

        //Btn Delete:
        private void btn_DeleteQuan_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có chắc muốn xóa không!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                con.Open();
                string sql = "DELETE FROM Quan WHERE MaQuan=@maQuan ";
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("maQuan", txt_IDQuan.Text);
                command.Parameters.AddWithValue("tenQuan", txt_TenQuan.Text);
                command.Parameters.AddWithValue("mauQuan", txt_MauQuan.Text);
                command.Parameters.AddWithValue("sizeQuan", comboBox_SizeQuan.Text);
                command.Parameters.AddWithValue("soluongQuan", txt_SLQuan.Text);
                command.Parameters.AddWithValue("giaQuan", txt_GiaQuan.Text);
                command.ExecuteNonQuery();
                con.Close();
                loadQuan();
            }
        }

        //Btn Update:
        private void btn_UpdateQuan_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có chắc muốn sửa không!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                con.Open();
                string sql = "UPDATE Quan SET TenQuan=@tenQuan,MauQuan=@mauQuan,SizeQuan=@sizeQuan,SoluongQuan=@soluongQuan,GiaQuan=@giaQuan WHERE MaQuan=@maQuan ";
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("maQuan", txt_IDQuan.Text);
                command.Parameters.AddWithValue("tenQuan", txt_TenQuan.Text);
                command.Parameters.AddWithValue("mauQuan", txt_MauQuan.Text);
                command.Parameters.AddWithValue("sizeQuan", comboBox_SizeQuan.Text);
                command.Parameters.AddWithValue("soluongQuan", txt_SLQuan.Text);
                command.Parameters.AddWithValue("giaQuan", txt_GiaQuan.Text);
                command.ExecuteNonQuery();
                con.Close();
                loadQuan();
            }
        }

        //Btn Refresh:
        private void btn_RefreshQuan_Click(object sender, EventArgs e)
        {
            txt_IDQuan.Text = "";
            txt_TenQuan.Text = "";
            txt_MauQuan.Text = "";
            comboBox_SizeQuan.Text = "";
            txt_SLQuan.Text = "";
            txt_GiaQuan.Text = "";
            loadQuan();
        }

        //Hàm để Enable 3 chức năng:
        private void txt_TenQuan_TextChanged(object sender, EventArgs e)
        {
            btn_AddQuan.Enabled = true;
            btn_DeleteQuan.Enabled = true;
            btn_UpdateQuan.Enabled = true;
        }

        //Btn Exit bên tab Sản Phẩm:
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn muốn Đăng Xuất chứ !!!", "Đăng Xuất", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                this.Hide();
                SignIn signin = new SignIn();
                signin.ShowDialog();
                this.Close();
            }
        }


        //Tab QL Nhân Viên:
        private void load_DataNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = load_DataNV.CurrentCell.RowIndex;
            txt_MaNV.Text = load_DataNV.Rows[t].Cells[0].Value.ToString();
            txt_HoTenNV.Text = load_DataNV.Rows[t].Cells[1].Value.ToString();
            txt_EmailNV.Text = load_DataNV.Rows[t].Cells[2].Value.ToString();
            txt_PhoneNV.Text = load_DataNV.Rows[t].Cells[3].Value.ToString();
            txt_UserNV.Text = load_DataNV.Rows[t].Cells[4].Value.ToString();
            txt_PassNV.Text = load_DataNV.Rows[t].Cells[5].Value.ToString();
        }

        //Btn Add:
        private void btn_Add_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có chắc muốn thêm Nhân Viên này không!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                con.Open();
                string sql = "INSERT INTO Employees VALUES(@tenNV, @emailNV, @phoneNV,@userNV,@passNV)";
                SqlCommand command = new SqlCommand(sql, con);
                //command.Parameters.AddWithValue("maNV", txt_MaNV.Text);
                command.Parameters.AddWithValue("tenNV", txt_HoTenNV.Text);
                command.Parameters.AddWithValue("emailNV", txt_EmailNV.Text);
                command.Parameters.AddWithValue("phoneNV", txt_PhoneNV.Text);
                command.Parameters.AddWithValue("userNV", txt_UserNV.Text);
                command.Parameters.AddWithValue("passNV", txt_PassNV.Text);
                command.ExecuteNonQuery();
                con.Close();
                loadNV();
            }
        }

        //Btn Delete:
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có chắc muốn xóa không!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                con.Open();
                string sql = "DELETE FROM Employees WHERE MaNV=@maNV ";
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("maNV", txt_MaNV.Text);
                command.Parameters.AddWithValue("tenNV", txt_HoTenNV.Text);
                command.Parameters.AddWithValue("emailNV", txt_EmailNV.Text);
                command.Parameters.AddWithValue("phoneNV", txt_PhoneNV.Text);
                command.Parameters.AddWithValue("userNV", txt_UserNV.Text);
                command.Parameters.AddWithValue("passNV", txt_PassNV.Text);
                command.ExecuteNonQuery();
                con.Close();
                loadNV();
            }
        }

        //Btn Update:
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có chắc muốn sửa không!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                con.Open();
                string sql = "UPDATE Employees SET TenNV=@tenNV,EmailNV=@emailNV,PhoneNV=@phoneNV,ID=@userNV,Password=@passNV WHERE MaNV=@maNV ";
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("maNV", txt_MaNV.Text);
                command.Parameters.AddWithValue("tenNV", txt_HoTenNV.Text);
                command.Parameters.AddWithValue("emailNV", txt_EmailNV.Text);
                command.Parameters.AddWithValue("phoneNV", txt_PhoneNV.Text);
                command.Parameters.AddWithValue("userNV", txt_UserNV.Text);
                command.Parameters.AddWithValue("passNV", txt_PassNV.Text);
                command.ExecuteNonQuery();
                con.Close();
                loadNV();
            }
        }

        //Btn Refresh:
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            loadNV();
            txt_MaNV.Text = "";
            txt_HoTenNV.Text = "";
            txt_EmailNV.Text = "";
            txt_PhoneNV.Text = "";
            txt_UserNV.Text = "";
            txt_PassNV.Text = "";
        }

        //Hàm để Enable 3 button chức năng:
        private void txt_HoTenNV_TextChanged(object sender, EventArgs e)
        {
            btn_Add.Enabled = true;
            btn_Edit.Enabled = true;
            btn_Delete.Enabled = true;
        }

        //Btn Exit bên tab Nhân Viên:
        private void btn_ExitNV_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn signin = new SignIn();
            signin.ShowDialog();
            this.Close();
        }

        //Btn search theo tên NV:
        private void btn_Search_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "SELECT * from Employees WHERE TenNV='" + txt_SearchNV.Text.Trim() + "'";
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            load_DataNV.DataSource = dt;
        }


        //Tab QL Khách Hàng:
        private void load_DataKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = load_DataKH.CurrentCell.RowIndex;
            txt_MaKH.Text = load_DataKH.Rows[t].Cells[0].Value.ToString();
            txt_NameKH.Text = load_DataKH.Rows[t].Cells[1].Value.ToString();
            txt_DiaChiKH.Text = load_DataKH.Rows[t].Cells[2].Value.ToString();
            txt_PhoneKH.Text = load_DataKH.Rows[t].Cells[3].Value.ToString();
        }

        //Btn Add:
        private void btn_Add1_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có chắc muốn thêm Khách Hàng này không!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                con.Open();
                string sql = "INSERT INTO Customers VALUES(@tenKH, @diachiKH, @phoneKH)";
                SqlCommand command = new SqlCommand(sql, con);
                //command.Parameters.AddWithValue("maKH", txt_MaKH.Text);
                command.Parameters.AddWithValue("tenKH", txt_NameKH.Text);
                command.Parameters.AddWithValue("diachiKH", txt_DiaChiKH.Text);
                command.Parameters.AddWithValue("phoneKH", txt_PhoneKH.Text);
                command.ExecuteNonQuery();
                con.Close();
                loadKH();
            }
        }

        //Btn Delete:
        private void btn_Delete1_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có chắc muốn xóa KH này không!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                con.Open();
                string sql = "DELETE FROM Customers WHERE MaKH=@maKH ";
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("maKH", txt_MaKH.Text);
                command.Parameters.AddWithValue("tenKH", txt_NameKH.Text);
                command.Parameters.AddWithValue("diachiKH", txt_DiaChiKH.Text);
                command.Parameters.AddWithValue("phoneKH", txt_PhoneKH.Text);
                command.ExecuteNonQuery();
                con.Close();
                loadKH();
            }
        }

        //Btn Update:
        private void btn_Update1_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có chắc muốn sửa KH này không!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                con.Open();
                string sql = "UPDATE Customers SET TenKH=@tenKH,DiaChiKH=@diachiKH,PhoneKH=@phoneKH WHERE MaKH=@maKH ";
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("maKH", txt_MaKH.Text);
                command.Parameters.AddWithValue("tenKH", txt_NameKH.Text);
                command.Parameters.AddWithValue("diachiKH", txt_DiaChiKH.Text);
                command.Parameters.AddWithValue("phoneKH", txt_PhoneKH.Text);
                command.ExecuteNonQuery();
                con.Close();
                loadKH();
            }
        }

        //Btn Refresh:
        private void btn_Refresh1_Click(object sender, EventArgs e)
        {
            loadKH();
            txt_MaKH.Text = "";
            txt_NameKH.Text = "";
            txt_DiaChiKH.Text = "";
            txt_PhoneKH.Text = "";
        }

        //Hàm để Enable 3 chức năng:
        private void txt_NameKH_TextChanged(object sender, EventArgs e)
        {
            btn_Add1.Enabled = true;
            btn_Update1.Enabled = true;
            btn_Delete1.Enabled = true;
        }

        //Btn Exit bên tab Khách Hàng:
        private void btn_ExitKH_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn signin = new SignIn();
            signin.ShowDialog();
            this.Close();
        }

        //Btn search theo tên KH:
        private void btn_Search2_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "SELECT * from Customers WHERE TenKH='" + txt_SearchKH.Text.Trim() + "'";
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            load_DataKH.DataSource = dt;
        }


        //Tab Bán Hàng:
        //Bảng Áo:
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dataGridView1.CurrentCell.RowIndex;
            txt_MaAo.Text = dataGridView1.Rows[t].Cells[0].Value.ToString();
            txt_TenAo1.Text = dataGridView1.Rows[t].Cells[1].Value.ToString();
            txt_MauAo1.Text = dataGridView1.Rows[t].Cells[2].Value.ToString();
            txt_SizeAo1.Text = dataGridView1.Rows[t].Cells[3].Value.ToString();
            txt_GiaAo1.Text = dataGridView1.Rows[t].Cells[5].Value.ToString();
        }

        //Bảng Quần:
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dataGridView2.CurrentCell.RowIndex;
            txt_MaQuan.Text = dataGridView2.Rows[t].Cells[0].Value.ToString();
            txt_TenQuan1.Text = dataGridView2.Rows[t].Cells[1].Value.ToString();
            txt_MauQuan1.Text = dataGridView2.Rows[t].Cells[2].Value.ToString();
            txt_SizeQuan1.Text = dataGridView2.Rows[t].Cells[3].Value.ToString();
            txt_GiaQuan1.Text = dataGridView2.Rows[t].Cells[5].Value.ToString();
        }

        //Bảng infor Khách Hàng:
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dataGridView3.CurrentCell.RowIndex;
            txt_MaKH1.Text = dataGridView3.Rows[t].Cells[0].Value.ToString();
            txt_TenKH1.Text = dataGridView3.Rows[t].Cells[1].Value.ToString();
            txt_DiaChiKH1.Text = dataGridView3.Rows[t].Cells[2].Value.ToString();
            txt_PhoneKH1.Text = dataGridView3.Rows[t].Cells[3].Value.ToString();
        }

        //Btn Refresh cho bảng SP:
        private void btn_Reset1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Text = "";

            txt_MaAo.Text = "";
            txt_TenAo1.Text = "";
            txt_MauAo1.Text = "";
            txt_SizeAo1.Text = "";
            txt_GiaAo1.Text = "";
            numAo.Text = "0";

            txt_MaQuan.Text = "";
            txt_TenQuan1.Text = "";
            txt_MauQuan1.Text = "";
            txt_SizeQuan1.Text = "";
            txt_GiaQuan1.Text = "";
            numQuan.Text = "0";

            txt_Sum.Text = "";

            loadGridAo();
            loadGridQuan();
        }

        //Btn Refresh cho bảng KH:
        private void btn_Reset2_Click(object sender, EventArgs e)
        {
            txt_MaKH1.Text = "";
            txt_TenKH1.Text = "";
            txt_DiaChiKH1.Text = "";
            txt_PhoneKH1.Text = "";

            loadGridKH();
        }

        //Hàm tính tiền Sản Phẩm đã chọn:
        void TongTien()
        {
            int tong = 0;
            int slAo = 0;
            int slQuan = 0;
            int giaAo = 0;
            int giaQuan = 0;

            if (txt_MaAo.Text == "")
            {
                slQuan = Convert.ToInt32(numQuan.Value);
                giaQuan = Convert.ToInt32(txt_GiaQuan1.Text);
                tong = (slQuan * giaQuan);
                txt_Sum.Text = tong.ToString();
            }
            else if (txt_MauQuan1.Text=="")
            {
                slAo = Convert.ToInt32(numAo.Value);
                giaAo = Convert.ToInt32(txt_GiaAo1.Text);
                tong = (slAo * giaAo);
                txt_Sum.Text = tong.ToString();
            }
            else
            {
                slAo = Convert.ToInt32(numAo.Value);
                slQuan = Convert.ToInt32(numQuan.Value);
                giaAo = Convert.ToInt32(txt_GiaAo1.Text);
                giaQuan = Convert.ToInt32(txt_GiaQuan1.Text);
                tong = (slQuan * giaQuan) + (slAo * giaAo);
                txt_Sum.Text = tong.ToString();
            }
        }

        private void txt_Sum_TextChanged(object sender, EventArgs e)
        {
            btn_Purchase.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TongTien();
        }

        //Hàm Mua Hàng (btn Mua):
        private void btn_Purchase_Click(object sender, EventArgs e)
        {
            BillForm bf = new BillForm();
            bf.ngaylap = dateTimePicker1.Text;
            bf.makh = txt_MaKH1.Text;
            bf.tenkh = txt_TenKH1.Text;
            bf.diachi = txt_DiaChiKH1.Text;
            bf.sdt = txt_PhoneKH1.Text;
            bf.maao = txt_MaAo.Text;
            bf.tenao = txt_TenAo1.Text;
            bf.mauao = txt_MauAo1.Text;
            bf.sizeao = txt_SizeAo1.Text;
            int soAo = Convert.ToInt32(numAo.Value); //la 
            bf.slao = soAo.ToString();
            bf.giaao = txt_GiaAo1.Text;
            bf.maquan = txt_MaQuan.Text;
            bf.tenquan = txt_TenQuan1.Text;
            bf.mauquan = txt_MauQuan1.Text;
            bf.sizequan = txt_SizeQuan1.Text;
            int soQuan = Convert.ToInt32(numQuan.Value);
            bf.slquan = soQuan.ToString();
            bf.giaquan = txt_GiaQuan1.Text;
            bf.tong = txt_Sum.Text;
            bf.ShowDialog();
        }


        //Tab History:
        //Btn Refresh data trong Grid Bill:
        private void btn_RefreshBill_Click(object sender, EventArgs e)
        {
            txt_MaBill.Text = "";
            loadGridLS();
        }

        //Btn Đăng xuất bên tab History:
        private void btn_ExitBill_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn muốn Đăng Xuất chứ !!!", "Đăng Xuất", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                this.Hide();
                SignIn signin = new SignIn();
                signin.ShowDialog();
                this.Close();
            }
        }

        //Btn Delete Bill:
        private void btn_DeleteBill_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có chắc muốn xóa Bill này không!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                con.Open();
                string sql = "DELETE FROM Bill WHERE MaBill=@maBill ";
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("maBill", txt_MaBill.Text);
                command.ExecuteNonQuery();
                con.Close();
                loadGridLS();
            }
        }

        //Bảng infor Bill:
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dataGridView4.CurrentCell.RowIndex;
            txt_MaBill.Text = dataGridView4.Rows[t].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportForm rf = new ReportForm();
            rf.Show();
        }
    }
}
