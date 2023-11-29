using _20T1080027.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20T1080027.DataLayers
{
    /// <summary>
    /// Lớp giao diện của quốc gia
    /// Định nghĩa phép xử lý dữ liệu liên quan đến quốc gia
    /// </summary>
    public interface ICountryDAL
    {
        IList<Country> List();
    }
}
