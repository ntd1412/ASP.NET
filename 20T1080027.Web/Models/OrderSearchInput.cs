using _20T1080027.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1080027.Web.Models
{
    /// <summary>
    /// Nhận dữ liệu đầu vào cho tìm kiếm đơn hàng
    /// </summary>
    public class OrderSearchInput : PaginationSearchInput
    {
        /// <summary>
        /// Tình trạng đơn hàng
        /// </summary>
        public int Status { get; set; }
    }
}