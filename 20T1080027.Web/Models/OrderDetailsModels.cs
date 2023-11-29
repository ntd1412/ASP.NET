using _20T1080027.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1080027.Web.Models
{
    /// <summary>
    /// Hiển thị các cấu trúc xử lý chi tiết đơn hàng
    /// </summary>
    public class OrderDetailsModels
    {
        /// <summary>
        /// Lấy ra thông tin của đơn đặt hàng
        /// </summary>
        public Order Order { get; set; }
        /// <summary>
        /// Lấy ra thông tin chi tiết của đơn đặt hàng
        /// </summary>
        public List<DomainModels.OrderDetail> OrderDetails { get; set; }
    }
}