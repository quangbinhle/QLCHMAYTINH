using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace QLCHMAYTINH
{
    public partial class DangNhap : DevExpress.XtraEditors.XtraForm
    {
        private string TaiKhoan;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            if (txt_taikhoan.Text == "" || txt_matkhau.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_taikhoan.Focus();
                txt_matkhau.Clear();
            }
            else
            {
                try
                {
                    string sql = "SELECT * FROM tblNhanvien WHERE Tendangnhap =N'" + txt_taikhoan.Text +"' AND Matkhau =N'" + txt_matkhau.Text+"'";
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"Data Source=DESKTOP-KS2AHB8\SQLEXPRESS;Initial catalog=QuanLyBanHang;Integrated Security=True";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        TaiKhoan = txt_taikhoan.Text;
                        this.Hide();
                        var formmain = new MainForm(TaiKhoan);
                        formmain.Closed += (s, args) => this.Close();
                        formmain.Show();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_taikhoan.Focus();
                        txt_matkhau.Clear();
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}