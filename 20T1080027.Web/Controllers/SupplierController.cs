﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _20T1080027.BusinessLayers;
using _20T1080027.DomainModels;

namespace _20T1080027.Web.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        private const int PAGE_SIZE = 5;
        private const string SESSION_CONDITION = "SupplierCondition";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Quản lý nhà cung cấp";
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
            var data = CommonDataService.ListOfSuppliers(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);

            Models.SupplierSearchOutput result = new Models.SupplierSearchOutput()
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
            var data = new Supplier() { 
                SupplierID = 0
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
            var data = CommonDataService.GetSupplier(id);
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
        public ActionResult Save(Supplier data) {
            // kiểm soát dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(data.SupplierName))
                ModelState.AddModelError(nameof(data.SupplierName), "Tên không được để trống");
            if (string.IsNullOrWhiteSpace(data.ContactName))
                ModelState.AddModelError(nameof(data.ContactName), "tên giao dịch không được để trống");
            if (string.IsNullOrWhiteSpace(data.Country))
                ModelState.AddModelError(nameof(data.Country), "vui lòng chọn quốc gia");

            data.Address = data.Address ?? "";
            data.Phone = data.Phone ?? "";
            data.City = data.City ?? "";
            data.PostalCode = data.PostalCode ?? "";

            if (ModelState.IsValid == false)
            {
                ViewBag.Title = data.SupplierID == 0 ? "Bổ sung nhà cung cấp " : "Cập nhật nhà cung cấp ";
                return View("Edit", data);
            }
            if (data.SupplierID == 0)
            {
                CommonDataService.AddSupplier(data);
            } else
            {
                CommonDataService.UpdateSupplier(data);
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int id = 0)
        {
            ViewBag.Title = "Xóa nhà cung cấp:";
            if (id <= 0)
                return RedirectToAction("Index");
            if (Request.HttpMethod == "POST")
            {
                CommonDataService.DeleteSupplier(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetSupplier(id);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }
    }
}