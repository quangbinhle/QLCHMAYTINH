using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;
using System.Data.SqlClient;
using QLCHMAYTINH.Class;

namespace QLCHMAYTINH
{
    public partial class frmLoai : DevExpress.XtraEditors.XtraForm
    {
        DataTable tblL;
        public frmLoai()
        {
            InitializeComponent();
        }

        private void frmLoai_Load(object sender, EventArgs e)
        {
            txtMaloai.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT Maloai, Tenloai, Ghichu FROM tblLoai";
            tblL = Class.Function.GetDataToTable(sql);
            DataGridViewLoai.DataSource = tblL;
            DataGridViewLoai.Columns[0].HeaderText = "Mã loại";
            DataGridViewLoai.Columns[1].HeaderText = "Tên loại";
            DataGridViewLoai.Columns[2].HeaderText = "Ghi chú";
            DataGridViewLoai.Columns[0].Width = 400;
            DataGridViewLoai.Columns[1].Width = 400;
            DataGridViewLoai.Columns[2].Width = 600;
            DataGridViewLoai.AllowUserToAddRows = false;
            DataGridViewLoai.EditMode = DataGridViewEditMode.EditProgrammatically;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtMaloai.Enabled = true; //cho phép nhập mới
            txtTenloai.Focus();
        }
        private void ResetValue()
        {
            txtMaloai.Text = "";
            txtTenloai.Text = "";
            txt_ghichu.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtMaloai.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaloai.Focus();
                return;
            }
            if (txtTenloai.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenloai.Focus();
                return;
            }
            sql = "Select Maloai From tblLoai where Maloai=N'" + txtMaloai.Text.Trim() + "'";
            if (Class.Function.CheckKey(sql))
            {
                MessageBox.Show("Mã loại này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaloai.Focus();
                return;
            }

            sql = "INSERT INTO tblLoai VALUES(N'" +
                txtMaloai.Text + "',N'" + txtTenloai.Text +"',N'"+ txt_ghichu.Text+"')";
            Class.Function.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaloai.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (tblL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaloai.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenloai.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE tblLoai SET Tenloai=N'" +
                txtTenloai.Text.ToString() + "',Ghichu=N'" + txt_ghichu.Text +
                "' WHERE Maloai=N'" + txtMaloai.Text + "'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaloai.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblLoai WHERE Maloai=N'" + txtMaloai.Text + "'";
                Class.Function.RunSqlDel(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridViewLoai_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaloai.Focus();
                return;
            }
            if (tblL.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaloai.Text = DataGridViewLoai.CurrentRow.Cells["Maloai"].Value.ToString();
            txtTenloai.Text = DataGridViewLoai.CurrentRow.Cells["Tenloai"].Value.ToString();
            txt_ghichu.Text = DataGridViewLoai.CurrentRow.Cells["Ghichu"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
    }
}