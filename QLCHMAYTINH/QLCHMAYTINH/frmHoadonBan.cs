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
using COMExcel = Microsoft.Office.Interop.Excel;

namespace QLCHMAYTINH
{
    public partial class frmHoadonBan : DevExpress.XtraEditors.XtraForm
    {
        private string tendn;
        DataTable tblCTHDB;
        double sl, SLcon, tong, tongmoi;
        public frmHoadonBan()
        {
            InitializeComponent();
        }
        public frmHoadonBan(string tennhanvien):this()
        {
            tendn = tennhanvien;
        }

        private void frmHoadonBan_Load(object sender, EventArgs e)
        {

            btnthemhd.Enabled = true;
            btnluuhd.Enabled = false;
            btnhuysp.Enabled = false;
            btn_inhd.Enabled = false;
            btn_themsp.Enabled = false;
            txt_mahd.ReadOnly = true;
            txt_tenkh.ReadOnly = true;
            txt_tennv.ReadOnly = true;
            txt_diachi.ReadOnly = true;
            txt_dtkh.ReadOnly = true;
            txt_tenhang.ReadOnly = true;
            txt_dongia.ReadOnly = true;
            txt_thanhtien.ReadOnly = true;
            txt_manv.ReadOnly = true;

            txt_giamgia.Text = "0";
            txt_thanhtien.Text = "0";
            lbl_tongcong.Text = "0";
            Function.FillCombo("SELECT Makhach, Tenkhach FROM tblKhachHang", cbo_makh, "Makhach", "Makhach");
            cbo_makh.SelectedIndex = -1;
            //Function.FillCombo("SELECT Mahang, Tenhang FROM tblHangHoa", cbo_mahang, "Mahang", "Mahang");
            //cbo_mahang.SelectedIndex = -1;
            //LoadDataGridView();
            //gán tên nhân viên thực hiện hóa đơn

        }
        private void LoadDataGridView()
        {
            //string sql;
            //sql = "SELECT a.Mahang, b.Tenhang, a.Soluong, b.Dongiaban, a.Giamgia,a.Thanhtien FROM tblChitietHDBan AS a, tblHangHoa AS b WHERE a.Mahang=b.Mahang";
            //tblCTHDB = Function.GetDataToTable(sql);
            //dataGridViewHoaDon.DataSource = tblCTHDB;
            //dataGridViewHoaDon.Columns[0].HeaderText = "Mã hàng";
            //dataGridViewHoaDon.Columns[1].HeaderText = "Tên hàng";
            //dataGridViewHoaDon.Columns[2].HeaderText = "Số lượng";
            //dataGridViewHoaDon.Columns[3].HeaderText = "Đơn giá";
            //dataGridViewHoaDon.Columns[4].HeaderText = "Giảm giá %";
            //dataGridViewHoaDon.Columns[5].HeaderText = "Thành tiền";
            //dataGridViewHoaDon.Columns[0].Width = 80;
            //dataGridViewHoaDon.Columns[1].Width = 130;
            //dataGridViewHoaDon.Columns[2].Width = 80;
            //dataGridViewHoaDon.Columns[3].Width = 90;
            //dataGridViewHoaDon.Columns[4].Width = 90;
            //dataGridViewHoaDon.Columns[5].Width = 90;
            //dataGridViewHoaDon.AllowUserToAddRows = false;
            //dataGridViewHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void btnthemhd_Click(object sender, EventArgs e)
        {
            string sql_manv = "SELECT Manhanvien FROM tblNhanvien WHERE Tendangnhap= N'" + tendn + "'";
            txt_manv.Text = Class.Function.GetFieldValues(sql_manv);
            string sql_tenv = "SELECT Tennhanvien FROM tblNhanvien WHERE Tendangnhap= N'" + tendn + "'";
            txt_tennv.Text = Class.Function.GetFieldValues(sql_tenv);
            btnluuhd.Enabled = true;
            btn_inhd.Enabled = false;
            btnthemhd.Enabled = true;
            btn_themsp.Enabled = true;
            txt_mahd.ReadOnly = true;
            txt_tenkh.ReadOnly = true;
            txt_tennv.ReadOnly = true;
            txt_diachi.ReadOnly = true;
            txt_dtkh.ReadOnly = true;
            txt_tenhang.ReadOnly = true;
            txt_dongia.ReadOnly = true;
            txt_thanhtien.ReadOnly = true;
            txt_manv.ReadOnly = true;

            txt_giamgia.Text = "0";
            txt_thanhtien.Text = "0";
            lbl_tongcong.Text = "0";
            txt_soluong.Text = "";
            txt_ghichu.Text = "";
            Function.FillCombo("SELECT Makhach, Tenkhach FROM tblKhachHang", cbo_makh, "Makhach", "Makhach");
            cbo_makh.SelectedIndex = -1;
            Function.FillCombo("SELECT Mahang, Tenhang FROM tblHangHoa", cbo_mahang, "Mahang", "Mahang");
            cbo_mahang.SelectedIndex = -1;
            dataGridViewHoaDon.Rows.Clear();
            //while (dataGridViewHoaDon.Rows.Count - 1 > 0)
            //{
            //    dataGridViewHoaDon.Rows.RemoveAt(0);
            //}
            txt_mahd.Text = Function.CreateKey("HDB");

        }

        private void cbo_makh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql_tenkh = "SELECT Tenkhach FROM tblKhachHang WHERE Makhach= N'" + cbo_makh.SelectedValue + "'";
            txt_tenkh.Text = Class.Function.GetFieldValues(sql_tenkh);
            string sql_diachikh = "SELECT Diachi FROM tblKhachHang WHERE Makhach= N'" + cbo_makh.SelectedValue + "'";
            txt_diachi.Text = Class.Function.GetFieldValues(sql_diachikh);
            string sql_dienthoai = "SELECT Dienthoai FROM tblKhachHang WHERE Makhach= N'" + cbo_makh.SelectedValue + "'";
            txt_dtkh.Text = Class.Function.GetFieldValues(sql_dienthoai);
        }



        private void cbo_mahang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql_tenhh = "SELECT Tenhang FROM tblHangHoa WHERE Mahang= N'" + cbo_mahang.SelectedValue + "'";
            txt_tenhang.Text = Class.Function.GetFieldValues(sql_tenhh);
            string sql_dongia = "SELECT Dongiaban FROM tblHangHoa WHERE Mahang= N'" + cbo_mahang.SelectedValue + "'";
            txt_dongia.Text = Class.Function.GetFieldValues(sql_dongia);
        }

        private void txt_soluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg, gg;
            if (txt_soluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txt_soluong.Text);
            if (txt_giamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txt_giamgia.Text);
            if (txt_dongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txt_dongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txt_thanhtien.Text = tt.ToString();
        }

        private void txt_giamgia_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txt_soluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txt_soluong.Text);
            if (txt_giamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txt_giamgia.Text);
            if (txt_dongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txt_dongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txt_thanhtien.Text = tt.ToString();
        }

        private void btn_themsp_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewHoaDon.RowCount; i++)
            {
                if (dataGridViewHoaDon[0, i].Value == cbo_mahang.SelectedValue)
                {
                    MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbo_mahang.Focus();
                    return;
                }
            }
            //kiểm tra số lượng
            sl = Convert.ToDouble(Function.GetFieldValues("SELECT Soluong FROM tblHangHoa WHERE Mahang = N'" + cbo_mahang.SelectedValue + "'"));
            if (txt_soluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_soluong.Text = "";
                txt_soluong.Focus();
            }
            //kiểm tra số lượng tồn kho
            else if (Convert.ToDouble(txt_soluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_soluong.Text = "";
                txt_soluong.Focus();
                return;
            }
            else
            {
                dataGridViewHoaDon.AllowUserToAddRows = false;
                dataGridViewHoaDon.Rows.Add(1);
                int indexRow = dataGridViewHoaDon.Rows.Count - 1;
                dataGridViewHoaDon[0, indexRow].Value = cbo_mahang.SelectedValue;
                dataGridViewHoaDon[1, indexRow].Value = txt_tenhang.Text;
                dataGridViewHoaDon[2, indexRow].Value = txt_soluong.Text;
                dataGridViewHoaDon[3, indexRow].Value = txt_dongia.Text;
                dataGridViewHoaDon[4, indexRow].Value = txt_giamgia.Text;
                dataGridViewHoaDon[5, indexRow].Value = txt_thanhtien.Text;

                double tongtien = 0;
                for (int i = 0; i < dataGridViewHoaDon.RowCount; i++)
                {
                    tongtien = tongtien + double.Parse(dataGridViewHoaDon.Rows[i].Cells[5].Value.ToString());
                }
                lbl_tongcong.Text = tongtien.ToString();
                lbl_soluong.Text = dataGridViewHoaDon.RowCount.ToString();
                cbo_mahang.SelectedIndex = 1;
            }
        }
        private void dataGridViewHoaDon_Click(object sender, EventArgs e)
        {
            cbo_mahang.SelectedValue = dataGridViewHoaDon.CurrentRow.Cells["Mahang"].Value.ToString();
            txt_soluong.Text = dataGridViewHoaDon.CurrentRow.Cells["Soluong"].Value.ToString();
            txt_giamgia.Text = dataGridViewHoaDon.CurrentRow.Cells["Giamgia"].Value.ToString();
            btnhuysp.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_inhd_Click(object sender, EventArgs e)
        {

        }


        private void btnhuysp_Click(object sender, EventArgs e)
        {
            int RowIndex = dataGridViewHoaDon.CurrentRow.Index;
            dataGridViewHoaDon.Rows.RemoveAt(RowIndex);
            double tongtien = 0;
            for (int i = 0; i < dataGridViewHoaDon.RowCount; i++)
            {
                tongtien = tongtien + double.Parse(dataGridViewHoaDon.Rows[i].Cells[5].Value.ToString());
            }
            lbl_tongcong.Text = tongtien.ToString();
            lbl_soluong.Text = dataGridViewHoaDon.RowCount.ToString();
        }

        private void btnluuhd_Click(object sender, EventArgs e)
        {
            string sql;
            if (dataGridViewHoaDon.RowCount<0)
            {
                MessageBox.Show("Chưa có danh sách hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (datetime_ngayban.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                datetime_ngayban.Focus();
                return;
            }
            else if (cbo_makh.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cbo_mahang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbo_mahang.Focus();
                return;
            }
            else if (txt_giamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_giamgia.Focus();
                return;
            }
            else
            {
                try
                {
                    //Lưu thông tin hóa đơn
                    sql = "INSERT INTO tblHDBan(MaHDBan, Ngayban, Manhanvien, Makhach, Tongtien,Ghichu) VALUES (N'" + txt_mahd.Text.Trim() + "','" +
                                Function.ConvertDateTime(datetime_ngayban.Text.Trim()) + "',N'" + txt_manv.Text + "',N'" +
                                cbo_makh.SelectedValue + "',N'" + lbl_tongcong.Text + "',N'" + txt_ghichu.Text + "')";
                    Function.RunSQL(sql);

                    //Lưu thông tin các mặt hàng
                    for (int i = 0; i < dataGridViewHoaDon.RowCount; i++)
                    {
                        sql = "INSERT INTO tblChitietHDBan(MaHDBan,Mahang,Soluong,Dongia, Giamgia,Thanhtien) VALUES(N'" + txt_mahd.Text.Trim() + "',N'" + dataGridViewHoaDon[0, i].Value + "'," + dataGridViewHoaDon[2, i].Value.ToString() + "," + dataGridViewHoaDon[3, i].Value.ToString() + "," + dataGridViewHoaDon[4, i].Value.ToString() + "," + dataGridViewHoaDon[5, i].Value.ToString() + ")";
                        Function.RunSQL(sql);
                    }
                    //Cập nhật lại số lượng mặt hàng vào bảng hàng hóa
                    for (int i = 0; i < dataGridViewHoaDon.RowCount; i++)
                    {
                        SLcon = sl - Convert.ToDouble(txt_soluong.Text);
                        sl = Convert.ToDouble(Function.GetFieldValues("SELECT Soluong FROM tblHangHoa WHERE Mahang = N'" + dataGridViewHoaDon[0, i].Value + "'"));
                        sql = "UPDATE tblHangHoa SET Soluong =" + SLcon + " WHERE Mahang= N'" + dataGridViewHoaDon[0, i].Value + "'";
                        Function.RunSQL(sql);
                    }
                    //Hiễn thị các nút chức năng
                    btnthemhd.Enabled = true;
                    btnluuhd.Enabled = false;
                    btn_themsp.Enabled = false;
                    btnhuysp.Enabled = false;
                    btn_inhd.Enabled = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                MessageBox.Show("Lưu hóa đơn thành công", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void ResetValuesHang()
        {
            cbo_mahang.Text = "";
            txt_soluong.Text = "";
            txt_giamgia.Text = "0";
            txt_thanhtien.Text = "0";
        }
    }
}