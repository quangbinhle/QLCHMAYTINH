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
    public partial class frmDoiMK : DevExpress.XtraEditors.XtraForm
    {
        private string taikhoan;
        
        public frmDoiMK()
        {
            InitializeComponent();
        }
        public frmDoiMK(string Taikhoan):this()
        {
            taikhoan = Taikhoan;
        }

        private void btn_doimk_Click(object sender, EventArgs e)
        {
            string sql = "SELECT Matkhau FROM tblNhanvien WHERE Tendangnhap =N'" + taikhoan + "'";
            if (txt_mkcu.Text != Class.Function.GetFieldValues(sql))
            {
                MessageBox.Show("mật khẩu cũ không đúng, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_mkcu.Text = "";
                txt_mkcu.Focus();
                txt_mkmoi.Text = "";
                txt_xacnhanmkmoi.Text = "";
            }
            else if (txt_mkmoi.Text != txt_xacnhanmkmoi.Text)
            {
                MessageBox.Show("xác nhận mật khẩu, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_mkcu.Text = "";
                txt_mkcu.Focus();
                txt_mkmoi.Text = "";
                txt_xacnhanmkmoi.Text = "";
            }
            else
            {
                try
                {
                    string sql2 = "UPDATE tblNhanvien SET Matkhau=N'" + txt_mkmoi.Text + "'WHERE Tendangnhap=N'" + taikhoan + "'";
                    Class.Function.RunSQL(sql2);
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK);
                    txt_mkcu.Text = "";
                    txt_mkmoi.Text = "";
                    txt_xacnhanmkmoi.Text = "";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}