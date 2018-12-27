using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using QLCHMAYTINH.Class;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLCHMAYTINH
{

    public partial class frmDMKhachhang : DevExpress.XtraEditors.XtraForm
    {
        DataTable tblKH;
        public frmDMKhachhang()
        {
            InitializeComponent();
        }

        private void frmDMKhachhang_Load(object sender, EventArgs e)
        {
            txtMakhach.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblKhachHang";
            tblKH = Function.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            DataGridViewKH.DataSource = tblKH; //Hiển thị vào dataGridView
            DataGridViewKH.Columns[0].HeaderText = "Mã khách hàng";
            DataGridViewKH.Columns[1].HeaderText = "Tên khách hàng";
            DataGridViewKH.Columns[2].HeaderText = "Địa chỉ";
            DataGridViewKH.Columns[3].HeaderText = "Điện thoại";
            DataGridViewKH.Columns[4].HeaderText = "Email";
            DataGridViewKH.Columns[5].HeaderText = "Ghi chú";
            DataGridViewKH.Columns[0].Width = 200;
            DataGridViewKH.Columns[1].Width = 250;
            DataGridViewKH.Columns[2].Width = 250;
            DataGridViewKH.Columns[3].Width = 250;
            DataGridViewKH.Columns[4].Width = 250;
            DataGridViewKH.Columns[5].Width = 250;
            DataGridViewKH.AllowUserToAddRows = false;
            DataGridViewKH.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMakhach.Text = "";
            txtTenkhach.Text = "";
            txtDiachi.Text = "";
            txtDienthoai.Text = "";
            txt_email.Text = "";
            txt_ghichu.Text = "";
        }

        private void DataGridViewKH_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMakhach.Focus();
                return;
            }
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMakhach.Text = DataGridViewKH.CurrentRow.Cells["Makhach"].Value.ToString();
            txtTenkhach.Text = DataGridViewKH.CurrentRow.Cells["Tenkhach"].Value.ToString();
            txtDiachi.Text = DataGridViewKH.CurrentRow.Cells["Diachi"].Value.ToString();
            txtDienthoai.Text = DataGridViewKH.CurrentRow.Cells["Dienthoai"].Value.ToString();
            txt_email.Text = DataGridViewKH.CurrentRow.Cells["Email"].Value.ToString();
            txt_ghichu.Text = DataGridViewKH.CurrentRow.Cells["Ghichu"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMakhach.Enabled = true;
            txtMakhach.Focus();
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            string sql;
            if (txtMakhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMakhach.Focus();
                return;
            }
            if (txtTenkhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenkhach.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return;
            }
            if (txtDienthoai.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienthoai.Focus();
                return;
            }
            //Kiểm tra đã tồn tại mã khách chưa
            sql = "SELECT Makhach FROM tblKhachHang WHERE Makhach=N'" + txtMakhach.Text + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã khách này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMakhach.Focus();
                return;
            }
            //Chèn thêm
            sql = "INSERT INTO tblKhachHang VALUES (N'" + txtMakhach.Text +
                "',N'" + txtTenkhach.Text + "',N'" + txtDiachi.Text + "','" + txtDienthoai.Text + "','" + txt_email.Text + "',N'" + txt_ghichu.Text + "')";
            Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();

            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMakhach.Enabled = false;
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMakhach.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblKhachHang WHERE Makhach=N'" + txtMakhach.Text + "'";
                Function.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMakhach.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenkhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenkhach.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return;
            }
            if (txtDienthoai.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienthoai.Focus();
                return;
            }
            sql = "UPDATE tblKhachHang SET Tenkhach=N'" + txtTenkhach.Text + "',Diachi=N'" +
                txtDiachi.Text + "',Dienthoai='" + txtDienthoai.Text + "',Email=N'" +
                txt_email.Text + "',Ghichu=N'" +txt_ghichu.Text+ "' WHERE Makhach=N'" + txtMakhach.Text + "'";
            Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}