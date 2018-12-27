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
using QLCHMAYTINH.Class;

namespace QLCHMAYTINH
{
    public partial class frmDMNhanvien : DevExpress.XtraEditors.XtraForm
    {
        DataTable tblNV; //Lưu dữ liệu bảng nhân viên
        public frmDMNhanvien()
        {
            InitializeComponent();
        }

        private void NhanVienForm_Load(object sender, EventArgs e)
        {
            txtManhanvien.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "SELECT Manhanvien,Tennhanvien,Gioitinh,Diachi,Dienthoai,Ngaysinh,Ghichu FROM tblNhanvien";
            tblNV = Function.GetDataToTable(sql); //lấy dữ liệu
            DataGridViewNV.DataSource = tblNV;
            DataGridViewNV.Columns[0].HeaderText = "Mã nhân viên";
            DataGridViewNV.Columns[1].HeaderText = "Tên nhân viên";
            DataGridViewNV.Columns[2].HeaderText = "Giới tính";
            DataGridViewNV.Columns[3].HeaderText = "Địa chỉ";
            DataGridViewNV.Columns[4].HeaderText = "Điện thoại";
            DataGridViewNV.Columns[5].HeaderText = "Ngày sinh";
            DataGridViewNV.Columns[6].HeaderText = "Ghi chú";
            DataGridViewNV.Columns[0].Width = 150;
            DataGridViewNV.Columns[1].Width = 150;
            DataGridViewNV.Columns[2].Width = 200;
            DataGridViewNV.Columns[3].Width = 250;
            DataGridViewNV.Columns[4].Width = 200;
            DataGridViewNV.Columns[5].Width = 150;
            DataGridViewNV.Columns[6].Width = 250;
            DataGridViewNV.AllowUserToAddRows = false;
            DataGridViewNV.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtManhanvien.Enabled = true;
            txtManhanvien.Focus();
        }
        private void ResetValues()
        {
            txtManhanvien.Text = "";
            txtTennhanvien.Text = "";
            chkGioitinh.Checked = false;
            txtDiachi.Text = "";
            dateNgaysinh.Text = "";
            txtSodienthoai.Text = "";
            txt_ghichu.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtManhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManhanvien.Focus();
                return;
            }
            if (txtTennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennhanvien.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (txtSodienthoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSodienthoai.Focus();
                return;
            }
            if (dateNgaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateNgaysinh.Focus();
                return;
            }
            if (!Function.IsDate(dateNgaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // mskNgaysinh.Text = "";
                dateNgaysinh.Focus();
                return;
            }
            if (chkGioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "SELECT Manhanvien FROM tblNhanvien WHERE Manhanvien=N'" + txtManhanvien.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManhanvien.Focus();
                txtManhanvien.Text = "";
                return;
            }
            sql = "INSERT INTO tblNhanvien(Manhanvien,Tennhanvien,Gioitinh, Diachi,Dienthoai, Ngaysinh,Ghichu) VALUES (N'" + txtManhanvien.Text.Trim() + "',N'" + txtTennhanvien.Text.Trim() + "',N'" + gt + "',N'" + txtDiachi.Text.Trim() + "','" + txtSodienthoai.Text + "','" + Function.ConvertDateTime(dateNgaysinh.Text) + "',N'" + txt_ghichu.Text+ "')";
            Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtManhanvien.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtManhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennhanvien.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (txtSodienthoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSodienthoai.Focus();
                return;
            }
            if (dateNgaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateNgaysinh.Focus();
                return;
            }
            if (!Function.IsDate(dateNgaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateNgaysinh.Text = "";
                dateNgaysinh.Focus();
                return;
            }
            if (chkGioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "UPDATE tblNhanvien SET  Tennhanvien=N'" + txtTennhanvien.Text.Trim().ToString() +
                    "',Diachi=N'" + txtDiachi.Text.Trim().ToString() +
                    "',Dienthoai='" + txtSodienthoai.Text.ToString() + "',Gioitinh=N'" + gt +
                    "',Ngaysinh='" + Function.ConvertDateTime(dateNgaysinh.Text) +
                     "',Ghichu=N'" + txt_ghichu.Text.Trim().ToString() +
                    "' WHERE Manhanvien=N'" + txtManhanvien.Text + "'";
            Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtManhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblNhanvien WHERE Manhanvien=N'" + txtManhanvien.Text + "'";
                Function.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridViewNV_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManhanvien.Focus();
                return;
            }
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtManhanvien.Text = DataGridViewNV.CurrentRow.Cells["Manhanvien"].Value.ToString();
            txtTennhanvien.Text = DataGridViewNV.CurrentRow.Cells["Tennhanvien"].Value.ToString();
            if (DataGridViewNV.CurrentRow.Cells["Gioitinh"].Value.ToString() == "Nam") chkGioitinh.Checked = true;
            else chkGioitinh.Checked = false;
            txtDiachi.Text = DataGridViewNV.CurrentRow.Cells["Diachi"].Value.ToString();
            txtSodienthoai.Text = DataGridViewNV.CurrentRow.Cells["Dienthoai"].Value.ToString();
            dateNgaysinh.EditValue = DataGridViewNV.CurrentRow.Cells["Ngaysinh"].Value;
            txt_ghichu.Text = DataGridViewNV.CurrentRow.Cells["Ghichu"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
    }
}
