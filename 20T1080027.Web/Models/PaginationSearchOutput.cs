using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1080027.Web.Models
{
    public abstract class PaginationSearchOutput
    {
        /// <summary>
        /// Số dòng mỗi trang
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Giá trị tìm kiếm
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Số dòng dữ liệu tìmđược
        /// </summary>
        public string SearchValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RowCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PageCount
        {
            get
            {
                if (PageSize == 0)
                    return 1;
                int p = RowCount / PageSize;
                if (RowCount % PageSize > 0)
                    p += 1;
                return p;
            }

        }
    }
}