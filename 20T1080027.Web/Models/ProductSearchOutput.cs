using _20T1080027.DomainModels;
using _20T1080027.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1080027.Web.Models
{
    /// <summary>
    /// Lưu trữ kết quả tìm kiếm và phân trang của mặt hàng
    /// </summary>
    public class ProductSearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// Dữ liệu đầu ra
        /// </summary>
        public List<Product> Data { get; set; }
    }
}