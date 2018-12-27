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
    public partial class frmQLBanHang : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbBanHang;
        private string ten;
        public DataGridView DataGridViewQLBanHang;
        public EventHandler evtGVQLBanHang;
        public frmQLBanHang()
        {
            InitializeComponent();
        }
        public frmQLBanHang(string tennv) : this()
        {
            ten = tennv;
        }
        private void frmQLBanHang_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT a.MaHDBan,a.Makhach,b.Tenkhach,a.Manhanvien,c.Tennhanvien,a.Ngayban,a.Tongtien,a.Ghichu FROM tblHDBan AS a, tblKhachHang AS b, tblNhanvien AS c WHERE a.Manhanvien=c.Manhanvien AND a.Makhach=b.Makhach";
            loadDataGridView(sql);
        }
        private void loadDataGridView(string sql)
        {

            tbBanHang = Class.Function.GetDataToTable(sql);
            dataGridViewQLBanHang.DataSource = tbBanHang;
            dataGridViewQLBanHang.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridViewQLBanHang.Columns[1].HeaderText = "Mã khách hàng";
            dataGridViewQLBanHang.Columns[2].HeaderText = "Tên khách hàng";
            dataGridViewQLBanHang.Columns[3].HeaderText = "Mã nhân viên";
            dataGridViewQLBanHang.Columns[4].HeaderText = "Tên nhân viên";
            dataGridViewQLBanHang.Columns[5].HeaderText = "Ngày bán";
            dataGridViewQLBanHang.Columns[6].HeaderText = "Tổng tiền";
            dataGridViewQLBanHang.Columns[7].HeaderText = "Ghi chú";
            dataGridViewQLBanHang.Columns[0].Width = 150;
            dataGridViewQLBanHang.Columns[1].Width = 150;
            dataGridViewQLBanHang.Columns[2].Width = 200;
            dataGridViewQLBanHang.Columns[3].Width = 150;
            dataGridViewQLBanHang.Columns[4].Width = 200;
            dataGridViewQLBanHang.Columns[5].Width = 200;
            dataGridViewQLBanHang.Columns[6].Width = 180;
            dataGridViewQLBanHang.Columns[7].Width = 200;
            dataGridViewQLBanHang.AllowUserToAddRows = false;
            dataGridViewQLBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txt_mahd.Text == "") && (txt_thang.Text == "") && (txt_nam.Text == "") &&
               (txt_manv.Text == "") && (txt_makh.Text == "") &&
               (txt_tongtien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT a.MaHDBan,a.Makhach,b.Tenkhach,a.Manhanvien,c.Tennhanvien,a.Ngayban,a.Tongtien,a.Ghichu FROM tblHDBan AS a, tblKhachHang AS b, tblNhanvien AS c WHERE a.Manhanvien=c.Manhanvien AND a.Makhach=b.Makhach";
            if (txt_mahd.Text != "")
                sql = sql + " AND a.MaHDBan Like N'%" + txt_mahd.Text + "%'";
            if (txt_thang.Text != "")
                sql = sql + " AND MONTH(a.Ngayban) =" + txt_thang.Text;
            if (txt_nam.Text != "")
                sql = sql + " AND YEAR(a.Ngayban) =" + txt_nam.Text;
            if (txt_manv.Text != "")
                sql = sql + " AND a.Manhanvien Like N'%" + txt_manv.Text + "%'";
            if (txt_makh.Text != "")
                sql = sql + " AND a.Makhach Like N'%" + txt_makh.Text + "%'";
            if (txt_tongtien.Text != "")
                sql = sql + " AND a.Tongtien <=" + txt_tongtien.Text;
            tbBanHang = Class.Function.GetDataToTable(sql);
            if (tbBanHang.Rows.Count == 0)
            {
                dataGridViewQLBanHang.DataSource = null;

            }
            else
            {
                dataGridViewQLBanHang.DataSource = tbBanHang;
                loadDataGridView(sql);
            }

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            frmQLBanHang_Load(sender, e);
            txt_mahd.Text = "";
            txt_makh.Text = "";
            txt_manv.Text = "";
            txt_nam.Text = "";
            txt_thang.Text = "";
            txt_tongtien.Text = "";
        }

        private void dataGridViewQLBanHang_DoubleClick(object sender, EventArgs e)
        {
            //Bind thông tin hóa đơn
            int i = dataGridViewQLBanHang.CurrentRow.Index;
            string mahd = dataGridViewQLBanHang.Rows[i].Cells[0].Value.ToString();
            frmHoadonBan frmHoadonBan = new frmHoadonBan();
            frmHoadonBan.Show();
            frmHoadonBan.txt_mahd.Text = mahd;
            frmHoadonBan.cbo_makh.Text = dataGridViewQLBanHang.Rows[i].Cells[1].Value.ToString();
            frmHoadonBan.datetime_ngayban.EditValue = dataGridViewQLBanHang.Rows[i].Cells[5].Value;
            frmHoadonBan.txt_ghichu.Text = dataGridViewQLBanHang.Rows[i].Cells[7].Value.ToString();
            frmHoadonBan.txt_manv.Text = dataGridViewQLBanHang.Rows[i].Cells[3].Value.ToString();
            string sql;
            sql = "SELECT a.Tennhanvien FROM tblHDBan AS b, tblNhanvien AS a WHERE a.Manhanvien=b.Manhanvien AND MaHDBan=N'" + mahd + "'";
            frmHoadonBan.txt_tennv.Text = Class.Function.GetFieldValues(sql);

            //Bind thông tin sản phẩm
            DataTable DSSP;
            SqlConnection cnn;
            SqlDataAdapter da;

            //cnn = new SqlConnection(@"Data Source=DESKTOP-KS2AHB8\SQLEXPRESS;Initial catalog=QuanLyBanHang;Integrated Security=True");
            //da = new SqlDataAdapter("Select * from tblHDBan", cnn);
            //DSSP = new DataTable();
            //da.SelectCommand.CommandText = "Select b.Mahang,a.Tenhang,b.Soluong,b.Dongia,b.Giamgia,b.Thanhtien From tblHangHoa AS a, tblChitietHDBan AS b WHERE a.Mahang = b.Mahang AND b.MaHDBan = N'" + mahd + "'";
            //da.Fill(DSSP);
            string sqllist;
            sqllist= "Select b.Mahang,a.Tenhang,b.Soluong,b.Dongia,b.Giamgia,b.Thanhtien From tblHangHoa AS a, tblChitietHDBan AS b WHERE a.Mahang = b.Mahang AND b.MaHDBan = N'" + mahd + "'";
            DSSP = Class.Function.GetDataToTable(sqllist);
            frmHoadonBan.dataGridViewHoaDon.DataSource = DSSP;
            frmHoadonBan.dataGridViewHoaDon.AllowUserToAddRows = false;
            frmHoadonBan.dataGridViewHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
            double tongtien = 0;

            frmHoadonBan.lbl_tongcong.Text = dataGridViewQLBanHang.Rows[i].Cells[6].Value.ToString();
            frmHoadonBan.lbl_soluong.Text = frmHoadonBan.dataGridViewHoaDon.RowCount.ToString();
        }

    }
}