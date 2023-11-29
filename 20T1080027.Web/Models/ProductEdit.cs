using _20T1080027.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1080027.Web.Models
{
    /// <summary>
    /// Hiển thị các mô hình khi sửa mặt hàng
    /// </summary>
    public class ProductEdit
    {
        /// <summary>
        /// Lấy ra thông tin một mặt hàng
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// Lấy ra danh sách thuộc tính của mặt hàng
        /// </summary>
        public List<ProductAttribute> ProductAttributes { get; set; }
        /// <summary>
        /// Lấy ra danh sách ảnh của mặt hàng
        /// </summary>
        public List<ProductPhoto> ProductPhotos { get; set; }
    }
}