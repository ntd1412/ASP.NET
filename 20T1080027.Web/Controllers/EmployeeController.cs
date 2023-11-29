using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using _20T1080027.BusinessLayers;
using _20T1080027.DataLayers.SQLServer;
using _20T1080027.DomainModels;

namespace _20T1080027.Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private const int PAGE_SIZE = 5;
        private const string SESSION_CONDITION = "EmployeeCondition";
        private const string STORAGE_UPLOAD_FILE_EMPLOYEE = "Public/images/Employee";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Quản lý nhân viên";

            Models.PaginationSearchInput condition = Session[SESSION_CONDITION] as Models.PaginationSearchInput;
            if (condition == null)
            {
                condition = new Models.PaginationSearchInput()
                {
                    Page = 1,
                    PageSize = PAGE_SIZE,
                    SearchValue = ""
                };
            }
            return View(condition); // truyền dữ liệu bằng model

        }
        public ActionResult Search(Models.PaginationSearchInput condition) // int Page , int PageSize , string SearchValue
        {
            int rowCount = 0;
            var data = CommonDataService.ListOfEmployees(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);

            Models.EmployeeSearchOutput result = new Models.EmployeeSearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };

            Session[SESSION_CONDITION] = condition;
            return View(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.Title = "Bổ sung nhà cung cấp:";
            var data = new Employee() { 
                EmployeeID = 0
            };
            return View("Edit", data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {

            ViewBag.Title = "Cập nhật nhà cung cấp:";
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetEmployee(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            return View(data);
        }
        /// <summary>
        /// Lưu dữ liệu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Employee data, string Birthday, HttpPostedFileBase image) { 
            DateTime? datetimeConvert = Converter.DMYStringToDateTime(Birthday);
            // kiểm tra tính hợp lệ của dữ liệu
            if (string.IsNullOrWhiteSpace(data.FirstName))
            {
                ModelState.AddModelError(nameof(data.FirstName), "Họ và tên đệm không được để trống");
            }
            if (string.IsNullOrWhiteSpace(data.LastName))
            {
                ModelState.AddModelError(nameof(data.LastName), "Tên không được để trống");
            }

            if (string.IsNullOrWhiteSpace(Birthday))
                ModelState.AddModelError(nameof(data.BirthDate), "Ngày tháng năm sinh không được để trống");
            else
            {
                if (datetimeConvert.Value < SqlDateTime.MinValue.Value || datetimeConvert.Value > SqlDateTime.MaxValue.Value)
                {
                    ModelState.AddModelError(nameof(data.BirthDate), "Ngày tháng năm sinh không hợp lệ");
                }
                else
                    data.BirthDate = datetimeConvert.Value;
            }


            if (image != null)
            {
                string path = Server.MapPath($"~/{STORAGE_UPLOAD_FILE_EMPLOYEE}");
                string fileName = $"{DateTime.Now.Ticks}-{image.FileName}";
                string filePath =Path.Combine(path, fileName);
                image.SaveAs(filePath);
                data.Photo = $"/{STORAGE_UPLOAD_FILE_EMPLOYEE}/{fileName}";
            }
            // kiểm tra xem thử email có bị trùng hay không?
            var employees = CommonDataService.ListOfEmployees(data.Email);
            if (employees.Count > 0 && data.EmployeeID == 0)
                ModelState.AddModelError(nameof(data.Email), "Vui lòng sử dụng email khác");
            else
            {
                data.Email = data.Email;
            }
            //data.Photo = data.Photo ?? "";
            data.Notes = data.Notes ?? "";
            // data.Email = data.Email ?? "";
            if (!ModelState.IsValid)
            {
                ViewBag.Title = data.EmployeeID == 0 ? "Bổ sung" : "Cập nhật";
                return View("Edit", data);
            }

            if (data.EmployeeID == 0)
            {
                CommonDataService.AddEmployee(data);
            } else
            {
                CommonDataService.UpdateEmployee(data);
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int id = 0)
        {
            ViewBag.Title = "Xóa nhân viên:";
            if (id <= 0)
                return RedirectToAction("Index");
            if (Request.HttpMethod == "POST")
            {
                CommonDataService.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetEmployee(id);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }
    }
}