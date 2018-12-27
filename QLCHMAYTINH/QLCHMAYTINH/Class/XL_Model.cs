using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHMAYTINH.Class
{
    public class XL_Model:DataTable
    {
        //Biến cục bộ
        public static String Chuoi_lien_ket = @"Data Source=DESKTOP-KS2AHB8\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True";
        private SqlDataAdapter mBo_doc_ghi = new SqlDataAdapter();
        private SqlConnection mKet_noi;
        private String mChuoi_SQL;
        private String mTen_bang;
        //Các thuộc tính

        public String Chuoi_SQL
        {
            get { return mChuoi_SQL; }
            set { mChuoi_SQL = value; }
        }

        public String Ten_bang
        {
            get { return mTen_bang; }
            set { mTen_bang = value; }
        }

        public int So_dong
        {
            get { return this.DefaultView.Count; }
        }

        //Các phương thức khởi tạo
        public XL_Model(): base(){ }
        //Tạo mới bảng với pTen_bang
        public XL_Model(String pTen_bang)
        {
            mTen_bang = pTen_bang;
            Doc_bang();
        }
        //Tạo mớ bảng với câu truy vấn
        public XL_Model(String pTen_bang, String pChuoi_SQL)
        {
            mTen_bang = pTen_bang;
            mChuoi_SQL = pChuoi_SQL;
            Doc_bang();
        }
        //Đọc dữ liệu
        public void Doc_bang()
        {
            if (mChuoi_SQL == null)
                mChuoi_SQL = "SELECT * FROM " + mTen_bang;
            if (mKet_noi == null)
                mKet_noi = new SqlConnection(Chuoi_lien_ket);
            try
            {
                mBo_doc_ghi = new SqlDataAdapter(mChuoi_SQL, mKet_noi);
                mBo_doc_ghi.FillSchema(this, SchemaType.Mapped);
                mBo_doc_ghi.Fill(this);
                mBo_doc_ghi.RowUpdated += new SqlRowUpdatedEventHandler(mBo_doc_ghi_RowUpdated);
                SqlCommandBuilder Bo_phat_sinh = new SqlCommandBuilder(mBo_doc_ghi);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        //Ghi dữ liệu
        public Boolean Ghi()
        {
            Boolean ket_qua = true;
            try
            {
                mBo_doc_ghi.Update(this);
                this.AcceptChanges();
            }
            catch (SqlException ex)
            {
                this.RejectChanges();
                ket_qua = false;
                throw ex;
            }
            return ket_qua;
        }
        // Lọc dữ liệu
        public void Loc_du_lieu(String pDieu_kien)
        {
            try
            {
                this.DefaultView.RowFilter = pDieu_kien;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Thực hiện truy vấn cập nhật dữ liệu(Insert, Update,Delete)
        public int Thuc_hien_lenh(String Lenh)
        {
            try
            {
                SqlCommand Cau_lenh = new SqlCommand(Lenh, mKet_noi);
                mKet_noi.Open();
                int ket_qua = Cau_lenh.ExecuteNonQuery();
                mKet_noi.Close();
                return ket_qua;
            }
            catch
            {
                return -1;
            }
        }
        //Thực hiện câu truy vấn trả về một giá trị
        public Object Thuc_hien_lenh_tinh_toan(String Lenh)
        {
            try
            {
                SqlCommand Cau_lenh = new SqlCommand(Lenh, mKet_noi);
                mKet_noi.Open();
                Object ket_qua = Cau_lenh.ExecuteScalar();
                mKet_noi.Close();
                return ket_qua;
            }
            catch
            {
                return null;
            }
        }
        //Xử lý sự kiện Rowupdated đối với trường khóa chính có kiểu Automunber
        private void mBo_doc_ghi_RowUpdated(Object sender, SqlRowUpdatedEventArgs e)
        {
            if (this.PrimaryKey[0].AutoIncrement)
            {
                if ((e.Status == UpdateStatus.Continue) && (e.StatementType == StatementType.Insert))
                {
                    SqlCommand cmd = new SqlCommand("Select @@IDENTITY ", mKet_noi);
                    e.Row.ItemArray[0] = cmd.ExecuteScalar();
                    e.Row.AcceptChanges();
                }
            }
        }
    }
}
