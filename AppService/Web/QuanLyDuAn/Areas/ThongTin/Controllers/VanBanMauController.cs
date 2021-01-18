using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.ThongTin.Controllers
{
    public class VanBanMauController : Controller
    {
        // GET: ThongTin/VanBanMau
        public ActionResult Index()
        {
            return View();
        }
        // GET: ThongTin/VanBanMau
        public ActionResult VanBanMau()
        {
            return View();
        } 
        // GET: ThongTin/VanBanMau
        public ActionResult _VanBanMauDetail(int id)
        {
            return PartialView(id);
        }
        // GET: ThongTin/VanBanMau
        public ActionResult DanhSachVanBan()
        {
            return View();
        }
        // GET: ThongTin/VanBanMau
        public ActionResult _DienVanBan(int id)
        {
            return PartialView(id);
        }
        [HttpPost, ValidateInput(false)]
        public JsonResult Create(string abc)
        {
            string xyz = abc;
            return Json(new { status = "success", result = "Đã lưu thông tin yêu cầu thành công" });
        }
        public async Task PostRegist(MultipartFormDataContent mFormData, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api-pm-cmd.tayho.com.vn/");//http://localhost:50999/,https://api-pm-cmd.tayho.com.vn/
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using (HttpResponseMessage response = client.PostAsync("api/cmd/v1/RequestRegist", mFormData).Result)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var err = response.Content.ReadAsStringAsync().Result;
                    }
                }
            }
        }
    }
}