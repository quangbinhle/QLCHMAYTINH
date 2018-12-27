using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLCHMAYTINH.Class;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLCHMAYTINH
{
    public partial class frmDMHang : DevExpress.XtraEditors.XtraForm
    {
        DataTable tblH;
        public frmDMHang()
        {
            InitializeComponent();
        }

        private void frmDMHang_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from tblLoai";
            btnLuu.Enabled = false;
            LoadDataGridView();
            Function.FillCombo(sql, cboMaloai, "Maloai", "Tenloai");
            cboMaloai.SelectedIndex = -1;
            ResetValues();
        }
        private void ResetValues()
        {
            txtMahang.Text = "";
            txtTenhang.Text = "";
            cboMaloai.Text = "";
            txtSoluong.Text = "0";
            txtDongianhap.Text = "0";
            txtDongiaban.Text = "0";
            txtSoluong.Enabled = true;
            txtDongianhap.Enabled = false;
            txtDongiaban.Enabled = false;
            txtAnh.Text = "";
            picAnh.Image = null;
            txtGhichu.Text = "";
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblHangHoa";
            tblH = Function.GetDataToTable(sql);
            DataGridViewHang.DataSource = tblH;
            DataGridViewHang.Columns[0].HeaderText = "Mã hàng";
            DataGridViewHang.Columns[1].HeaderText = "Tên hàng";
            DataGridViewHang.Columns[2].HeaderText = "Loại";
            DataGridViewHang.Columns[3].HeaderText = "Số lượng";
            DataGridViewHang.Columns[4].HeaderText = "Đơn giá nhập";
            DataGridViewHang.Columns[5].HeaderText = "Đơn giá bán";
            DataGridViewHang.Columns[6].HeaderText = "Ảnh";
            DataGridViewHang.Columns[7].HeaderText = "Ghi chú";
            DataGridViewHang.Columns[0].Width = 100;
            DataGridViewHang.Columns[1].Width = 150;
            DataGridViewHang.Columns[2].Width = 150;
            DataGridViewHang.Columns[3].Width = 150;
            DataGridViewHang.Columns[4].Width = 150;
            DataGridViewHang.Columns[5].Width = 150;
            DataGridViewHang.Columns[6].Width = 200;
            DataGridViewHang.Columns[7].Width = 300;
            DataGridViewHang.AllowUserToAddRows = false;
            DataGridViewHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMahang.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahang.Focus();
                return;
            }
            if (txtTenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenhang.Focus();
                return;
            }
            if (cboMaloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaloai.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOpen.Focus();
                return;
            }
            sql = "SELECT Mahang FROM tblHangHoa WHERE Mahang=N'" + txtMahang.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahang.Focus();
                return;
            }
            sql = "INSERT INTO tblHangHoa(Mahang,Tenhang,Maloai,Soluong,Dongianhap,Dongiaban,Anh,Ghichu) VALUES(N'"
                + txtMahang.Text + "',N'" + txtTenhang.Text +
                "',N'" + cboMaloai.SelectedValue.ToString() +
                "'," + txtSoluong.Text + "," + txtDongianhap.Text +
                "," + txtDongiaban.Text + ",'" + txtAnh.Text + "',N'" + txtGhichu.Text + "')";

            Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMahang.Enabled = false;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMahang.Text == "") && (txtTenhang.Text == "") && (cboMaloai.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from tblHangHoa WHERE 1=1";
            if (txtMahang.Text != "")
                sql += " AND Mahang LIKE N'%" + txtMahang.Text + "%'";
            if (txtTenhang.Text != "")
                sql += " AND Tenhang LIKE N'%" + txtTenhang.Text + "%'";
            if (cboMaloai.Text != "")
                sql += " AND Maloai LIKE N'%" + cboMaloai.SelectedValue + "%'";
            tblH = Function.GetDataToTable(sql);
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridViewHang.DataSource = tblH;
            }   
            else
            {
                //MessageBox.Show("Có " + tblH.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridViewHang.DataSource = tblH;
            } 
            
            ResetValues();
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT Mahang, Tenhang,Maloai,Soluong,Dongianhap,Dongiaban,Anh,Ghichu FROM tblHangHoa";
            tblH = Function.GetDataToTable(sql);
            ResetValues();
            DataGridViewHang.DataSource = tblH;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMahang.Enabled = true;
            txtMahang.Focus();
            txtSoluong.Enabled = true;
            txtDongianhap.Enabled = true;
            txtDongiaban.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMahang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblHangHoa WHERE Mahang=N'" + txtMahang.Text + "'";
                Function.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
                txtMahang.Enabled = true;
                txtDongiaban.Enabled = true;
                txtDongianhap.Enabled = true;
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMahang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahang.Focus();
                return;
            }
            if (txtTenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenhang.Focus();
                return;
            }
            if (cboMaloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaloai.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAnh.Focus();
                return;
            }
            sql = "UPDATE tblHangHoa SET Tenhang=N'" + txtTenhang.Text.ToString() +
                "',Maloai=N'" + cboMaloai.SelectedValue.ToString() +
                "',Soluong=" + txtSoluong.Text +
                ",Dongiaban=" + txtDongiaban.Text +
                ",Dongianhap=" +txtDongianhap.Text + ",Anh='" + txtAnh.Text + "',Ghichu=N'" + txtGhichu.Text + "' WHERE Mahang=N'" + txtMahang.Text + "'";
            Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void DataGridViewHang_Click(object sender, EventArgs e)
        {
            string maloai;
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahang.Focus();
                return;
            }
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMahang.Text = DataGridViewHang.CurrentRow.Cells["Mahang"].Value.ToString();
            txtTenhang.Text = DataGridViewHang.CurrentRow.Cells["Tenhang"].Value.ToString();
            maloai = DataGridViewHang.CurrentRow.Cells["Maloai"].Value.ToString();
            sql = "SELECT Tenloai FROM tblLoai WHERE Maloai=N'" + maloai + "'";
            cboMaloai.Text = Function.GetFieldValues(sql);
            txtSoluong.Text = DataGridViewHang.CurrentRow.Cells["Soluong"].Value.ToString();
            txtDongianhap.Text = DataGridViewHang.CurrentRow.Cells["Dongianhap"].Value.ToString();
            txtDongiaban.Text = DataGridViewHang.CurrentRow.Cells["Dongiaban"].Value.ToString();
            sql = "SELECT Anh FROM tblHangHoa WHERE Mahang=N'" + txtMahang.Text + "'";
            txtAnh.Text = Function.GetFieldValues(sql);
            picAnh.Image = Image.FromFile(txtAnh.Text);
            sql = "SELECT Ghichu FROM tblHangHoa WHERE Mahang = N'" + txtMahang.Text + "'";
            txtGhichu.Text = Function.GetFieldValues(sql);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtDongiaban.Enabled = true;
            txtDongianhap.Enabled = true;
        }
    }
}