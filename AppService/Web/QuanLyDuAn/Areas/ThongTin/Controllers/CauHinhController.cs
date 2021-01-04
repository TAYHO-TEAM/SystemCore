using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.ThongTin.Controllers
{
    public class CauHinhController : Controller
    {
        // GET: ThongTin/CauHinh
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HangMuc()
        {
            return View();
        }
        public ActionResult PhanQuyenPheDuyet()
        {
            return View();
        }
        public ActionResult QuyTrinh()
        {
            return View();
        }
        public ActionResult KeHoachDeTrinh()
        {
            return View();
        }
        public ActionResult _KeHoachShow()
        {
            return PartialView();
        }
        [HttpPost, ValidateInput(false)]
        public JsonResult postPlanRegist(string requestOBJ, string token)
        {

            return Json(new { status = "success", result = "Đã lưu thông tin yêu cầu thành công" });
        }
        public ActionResult TaiLieu()
        {
            return View();
        }

        public class PlanRegistOBJ
        {
            public int? ParentId { get; set; }
            public int? DocumentTypeId { get; set; }
            public int? WorkItemId { get; set; }
            public string Code { get; set; }
            public string Title { get; set; }
            public int? ProjectId { get; set; }
            public int? ContractorInfoId { get; set; }
            public string Description { get; set; }
            public DateTime? RequestDate { get; set; }
            public DateTime? ResponseDate { get; set; }
            public DateTime? ExpectRequestDate { get; set; }
            public DateTime? ExpectResponseDate { get; set; }
            public int? Id { get; set; }
            public bool? IsActive { get; set; }
            public bool? IsVisible { get; set; }
            public byte? Status { get; set; }
        }
    }
}