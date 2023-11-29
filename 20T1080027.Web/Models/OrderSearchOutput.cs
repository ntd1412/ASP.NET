using _20T1080027.DomainModels;
using _20T1080027.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1080027.Web.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderSearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// Dữ liệu đầu ra
        /// </summary>
        public List<Order> Data { get; set; }
    }
}