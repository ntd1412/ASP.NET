using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20T1080027.DomainModels
{
    /// <summary>
    /// Ảnh của mặt hàng
    /// </summary>
    public class ProductPhoto
    {
        ///<summary>
        /// Mã ảnh của mặt hàng
        ///</summary>
        public long PhotoID { get; set; }
        ///<summary>
        /// Mã mặt hàng
        ///</summary>
        public int ProductID { get; set; }
        ///<summary>
        /// Đường dẫn hình ảnh
        ///</summary>
        public string Photo { get; set; }
        ///<summary>
        /// Mô tả hình ảnh
        ///</summary>
        public string Description { get; set; }
        ///<summary>
        /// Vị trí hiển thị khi đặt hàng
        ///</summary>
        public int DisplayOrder { get; set; }
        ///<summary>
        /// Cờ ẩn hiện ảnh
        ///</summary>
        public bool IsHidden { get; set; }
    }
}