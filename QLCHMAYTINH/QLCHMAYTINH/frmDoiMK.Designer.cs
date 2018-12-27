namespace QLCHMAYTINH
{
    partial class frmDoiMK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_xacnhanmkmoi = new DevExpress.XtraEditors.TextEdit();
            this.txt_mkmoi = new DevExpress.XtraEditors.TextEdit();
            this.txt_mkcu = new DevExpress.XtraEditors.TextEdit();
            this.TopLayout = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btn_doimk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_xacnhanmkmoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_mkmoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_mkcu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_xacnhanmkmoi);
            this.layoutControl1.Controls.Add(this.txt_mkmoi);
            this.layoutControl1.Controls.Add(this.txt_mkcu);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.TopLayout;
            this.layoutControl1.Size = new System.Drawing.Size(675, 110);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_xacnhanmkmoi
            // 
            this.txt_xacnhanmkmoi.Location = new System.Drawing.Point(150, 60);
            this.txt_xacnhanmkmoi.Name = "txt_xacnhanmkmoi";
            this.txt_xacnhanmkmoi.Properties.PasswordChar = '*';
            this.txt_xacnhanmkmoi.Size = new System.Drawing.Size(513, 20);
            this.txt_xacnhanmkmoi.StyleController = this.layoutControl1;
            this.txt_xacnhanmkmoi.TabIndex = 8;
            // 
            // txt_mkmoi
            // 
            this.txt_mkmoi.Location = new System.Drawing.Point(150, 36);
            this.txt_mkmoi.Name = "txt_mkmoi";
            this.txt_mkmoi.Properties.PasswordChar = '*';
            this.txt_mkmoi.Size = new System.Drawing.Size(513, 20);
            this.txt_mkmoi.StyleController = this.layoutControl1;
            this.txt_mkmoi.TabIndex = 6;
            // 
            // txt_mkcu
            // 
            this.txt_mkcu.Location = new System.Drawing.Point(150, 12);
            this.txt_mkcu.Name = "txt_mkcu";
            this.txt_mkcu.Properties.PasswordChar = '*';
            this.txt_mkcu.Size = new System.Drawing.Size(513, 20);
            this.txt_mkcu.StyleController = this.layoutControl1;
            this.txt_mkcu.TabIndex = 4;
            // 
            // TopLayout
            // 
            this.TopLayout.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.TopLayout.GroupBordersVisible = false;
            this.TopLayout.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem5});
            this.TopLayout.Name = "TopLayout";
            this.TopLayout.Size = new System.Drawing.Size(675, 110);
            this.TopLayout.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txt_mkcu;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(655, 24);
            this.layoutControlItem1.Text = "Mật khẩu cũ";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(135, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(655, 18);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txt_mkmoi;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(655, 24);
            this.layoutControlItem3.Text = "Mật khẩu mới";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(135, 16);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.txt_xacnhanmkmoi;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(655, 24);
            this.layoutControlItem5.Text = "Xác nhận mật khẩu mới";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(135, 16);
            // 
            // btn_doimk
            // 
            this.btn_doimk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_doimk.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_doimk.Appearance.Options.UseFont = true;
            this.btn_doimk.Location = new System.Drawing.Point(270, 116);
            this.btn_doimk.Name = "btn_doimk";
            this.btn_doimk.Size = new System.Drawing.Size(85, 32);
            this.btn_doimk.TabIndex = 1;
            this.btn_doimk.Text = "Đổi mật khẩu";
            this.btn_doimk.Click += new System.EventHandler(this.btn_doimk_Click);
            // 
            // frmDoiMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 399);
            this.Controls.Add(this.btn_doimk);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmDoiMK";
            this.Text = "Đổi mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_xacnhanmkmoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_mkmoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_mkcu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txt_xacnhanmkmoi;
        private DevExpress.XtraEditors.TextEdit txt_mkmoi;
        private DevExpress.XtraEditors.TextEdit txt_mkcu;
        private DevExpress.XtraLayout.LayoutControlGroup TopLayout;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btn_doimk;
    }
}