using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyQuanAo
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-00VPBT66;Initial Catalog=QLShop;Integrated Security=True");

        //Btn Exit:
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn signin = new SignIn();
            signin.ShowDialog();
            this.Close();
        }

        //Btn SignUp:
        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có chắc muốn đăng ký tài khoản cho Nhân Viên này không!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                con.Open();
                string sql = "INSERT INTO Employees VALUES(@tenNV, @emailNV, @phoneNV,@userNV,@passNV)";
                SqlCommand command = new SqlCommand(sql, con);
                //command.Parameters.AddWithValue("maNV", txt_MaNV.Text);
                command.Parameters.AddWithValue("tenNV", txt_HoTen.Text);
                command.Parameters.AddWithValue("emailNV", txt_Email.Text);
                command.Parameters.AddWithValue("phoneNV", txt_Phone.Text);
                command.Parameters.AddWithValue("userNV", txt_ID.Text);
                command.Parameters.AddWithValue("passNV", txt_PW.Text);
                command.ExecuteNonQuery();
                con.Close();
                this.Hide();
                SignIn signin = new SignIn();
                signin.ShowDialog();
                this.Close();
            }
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
