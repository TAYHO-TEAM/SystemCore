using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
//using Services.Common.Paging;

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
        public async Task<JsonResult> postPlanRegist(string requestOBJ, string token)
        {
            string result = "";
            result = await PostPlan(requestOBJ, token, result);
            if (result == "Ok")
                return Json(new { status = "success", result = "Đã lưu thông tin yêu cầu thành công" });
            else
                return Json(new { status = "error", result = result});
        }
        public async Task<string> PostPlan(string requestOBJ, string token, string result)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api-pm-cmd.tayho.com.vn/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var httpContent = new StringContent(requestOBJ, Encoding.UTF8, "application/json");
                //POST Method  
                using (HttpResponseMessage response = client.PostAsync("api/cmd/v1/PlanRegister", httpContent).Result)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        result = "Error";
                    }
                    else
                    {
                        result = "Ok";
                    }
                }

            }
            return result;
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