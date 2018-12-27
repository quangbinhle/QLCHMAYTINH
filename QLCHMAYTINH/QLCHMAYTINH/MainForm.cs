using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace QLCHMAYTINH
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string ten;
        public MainForm()
        {
            InitializeComponent();
           
        }
        public MainForm(string tennguoidung) : this()
        {
            ten = tennguoidung;
            lbl_ten.Text = ten;
        }
        public void ViewChildForm(Form _form)
        {
            if (!IsFormAcived(_form))
            {
                _form.MdiParent = this;
                _form.Show();
            }
        }

        private bool IsFormAcived(Form form)
        {
            bool IsOpenend = false;
            if (MdiChildren.Count() > 0)
            {
                foreach (var item in MdiChildren)
                {
                    if (form.Name == item.Name)
                    {
                        xtraTabbedMdiManager1.Pages[item].MdiChild.Activate();
                        IsOpenend = true;
                    }
                }
            }
            return IsOpenend;
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDMNhanvien frmNhanvien = new frmDMNhanvien();
            frmNhanvien.Name = "frmNhanvien";
            ViewChildForm(frmNhanvien);
            //frmDMLoai.ShowDialog();
            //frmDMNhanvien nhanvien = new frmDMNhanvien();
            //nhanvien.ShowDialog();
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Hide();
            var flogin = new DangNhap();
            flogin.Closed += (s, args) => this.Close();
            flogin.Show();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDoiMK frmDoiMK = new frmDoiMK(ten);
            frmDoiMK.Name = "frmDoiMK";
            ViewChildForm(frmDoiMK);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLoai frmDMLoai = new frmLoai();
            frmDMLoai.Name = "frmLoai";
            ViewChildForm(frmDMLoai);
            //frmDMLoai.ShowDialog();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDMKhachhang frmDMKhachhang = new frmDMKhachhang();
            frmDMKhachhang.Name = "frmDMKhachhang";
            ViewChildForm(frmDMKhachhang);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDMHang frmDMHang = new frmDMHang();
            frmDMHang.Name = "frmDMHang";
            ViewChildForm(frmDMHang);
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmHoadonBan frmHoadonBan = new frmHoadonBan(ten);
            frmHoadonBan.Name = "frmHoadonBan";
            ViewChildForm(frmHoadonBan);
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLBanHang frmQLBanHang = new frmQLBanHang(ten);
            frmQLBanHang.Name = "frmQLBanHang";
            ViewChildForm(frmQLBanHang);
            //frmQLBanHang.dataGridViewQLBanHang.DoubleClick += gv_DoubleClick;

        }

        //private void gv_DoubleClick(object sender, EventArgs e)
        //{
        //    DataGridView gv = null;
        //    try
        //    {
        //        gv = (DataGridView)sender;
        //    }
        //    catch (Exception)
        //    {
        //        gv = null;
        //    }
        //    if (gv == null)
        //    {
        //        return;
        //    }
        //    if (gv.Name == "dataGridViewQLBanHang")
        //    {
        //        int i = gv.CurrentRow.Index;
        //        string mahd= gv.Rows[i].Cells[0].Value.ToString();
        //        frmHoadonBan frmHoadonBan = new frmHoadonBan();
        //        frmHoadonBan.txt_mahd.Text = mahd;
        //        frmHoadonBan.cbo_makh.Text=gv.Rows[i].Cells[1].Value.ToString();
        //        frmHoadonBan.datetime_ngayban.EditValue= gv.Rows[i].Cells[5].Value.ToString();
        //        frmHoadonBan.txt_ghichu.Text = gv.Rows[i].Cells[7].Value.ToString();
        //        frmHoadonBan.txt_manv.Text = gv.Rows[i].Cells[3].Value.ToString();
        //        string sql;
        //        sql = "SELECT a.Tennhanvien FROM tblHDBan AS b, tblNhanvien AS a WHERE a.Manhanvien=b.Manhanvien AND MaHDBan=N'" + mahd + "'";
        //        frmHoadonBan.txt_tennv.Text = Class.Function.GetFieldValues(sql);
        //        frmHoadonBan.Name = "frmHoadonBan";
        //        ViewChildForm(frmHoadonBan);
        //    }
        //}

    }
}