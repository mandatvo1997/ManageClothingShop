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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
            txt_PW.MaxLength = 10;
        }

        //Btn SignUp:
        private void btn_SignIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp signup = new SignUp();
            signup.ShowDialog();
            this.Close();
        }

        //Btn Login:
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-00VPBT66;Initial Catalog=QLShop;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employees where ID='" + txt_ID.Text.Trim() + "'and Password='" + txt_PW.Text.Trim() + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count==1)
            {
                MessageBox.Show("Đăng Nhập Thành Công !!!!");
                this.Hide();
                NhanVien nv = new NhanVien();
                nv.Show();
            }
            else
            {
                MessageBox.Show("Đăng Nhập Không Thành Công !!!!");
            }
        }

        //CheckBox để ẩn hiện Password:
        private void checkBox_ShowHide_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ShowHide.Checked)
            {
                txt_PW.UseSystemPasswordChar = true;
            }
            else
            {
                txt_PW.UseSystemPasswordChar = false;
            }
        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }
    }
}
