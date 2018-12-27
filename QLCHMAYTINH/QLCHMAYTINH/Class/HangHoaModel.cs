using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHMAYTINH.Class
{
    public class HangHoaModel: XL_Model
    {
        public HangHoaModel() : base("tblChitietHDBan") { }
        public HangHoaModel(string chuoiSQL) : base("tblChitietHDBan", chuoiSQL) { }

    }
}
