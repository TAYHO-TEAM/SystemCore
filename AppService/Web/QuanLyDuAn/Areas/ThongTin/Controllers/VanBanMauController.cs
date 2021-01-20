﻿using Newtonsoft.Json;
using QuanLyDuAn.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Description;
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
        // GET: ThongTin/DanhSachVanBan
        public ActionResult DanhSachVanBan()
        {
            return View();
        }
        // GET: ThongTin/_DanhSachVanBan
        public ActionResult _DanhSachVanBan(int id)
        {
            return PartialView(id);
        }
        // GET: ThongTin/_DienVanBan
        public ActionResult _DienVanBan(int id)
        {
            return PartialView(id);
        }
        [HttpPost]
        [ResponseType(typeof(string))]
        public JsonResult Test()
        {
            List<CustomCellContentOBJ> customCellContentOBJs = new List<CustomCellContentOBJ>();
          
            try
            {
                if (!Request.Form.AllKeys.Any() && Request.Form["customformContentId"] == null && Request.Form["token"] == null)
                    throw new ArgumentNullException();
                int CustomFormContentId = 0;
                string token = "";
                try
                {
                    token = Request.Form["token"];
                    CustomFormContentId = Convert.ToInt32(Request.Form["customformContentId"].ToString());
                }
                catch
                {
                    throw new ArgumentNullException();
                }
                foreach (var item in Request.Form)
                {
                    string[] ids = new string[100];
                    CustomCellContentOBJ customCellContentOBJ = new CustomCellContentOBJ();
                    MultipartFormDataContent mFormData = new MultipartFormDataContent();
                    customCellContentOBJ.CustomFormContentId = CustomFormContentId;
                    if (item.ToString().Contains("_"))
                    {
                        ids = item.ToString().Split('_');
                        try
                        {
                            customCellContentOBJ.CustomFormBodyId = Convert.ToInt32(ids[0]);
                            customCellContentOBJ.CustomColumId = Convert.ToInt32(ids[1]);
                            customCellContentOBJ.NoRown = Convert.ToInt32(ids[2]);
                            customCellContentOBJ.Contents = Request.Form[item.ToString()].ToString() == null ? "": Request.Form[item.ToString()].ToString();
                            if (customCellContentOBJ.CustomFormContentId.HasValue) mFormData.Add(new StringContent(((int)customCellContentOBJ.CustomFormContentId).ToString()), nameof(customCellContentOBJ.CustomFormContentId));
                            if (customCellContentOBJ.CustomFormBodyId.HasValue) mFormData.Add(new StringContent(((int)customCellContentOBJ.CustomFormBodyId).ToString()), nameof(customCellContentOBJ.CustomFormBodyId));
                            if (customCellContentOBJ.CustomColumId.HasValue) mFormData.Add(new StringContent(((int)customCellContentOBJ.CustomColumId).ToString()), nameof(customCellContentOBJ.CustomColumId));
                            if (customCellContentOBJ.NoRown.HasValue) mFormData.Add(new StringContent(((int)customCellContentOBJ.NoRown).ToString()), nameof(customCellContentOBJ.NoRown));
                            if (!string.IsNullOrEmpty(customCellContentOBJ.Contents)) mFormData.Add(new StringContent(customCellContentOBJ.Contents), nameof(customCellContentOBJ.Contents));
                            using (var client = new HttpClient())
                            {
                                client.BaseAddress = new Uri("https://api-pm-cmd.tayho.com.vn/");
                                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                                using (HttpResponseMessage response = client.PostAsync("api/cmd/v1/CustomCellContent/FromForm", mFormData).Result)
                                {
                                    if (response.StatusCode != HttpStatusCode.OK)
                                    {
                                        var err = response.Content.ReadAsStringAsync().Result;
                                        return Json(new { status = "error", result = err });
                                    }
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            throw new ArgumentNullException();
                        }
                    }
                    else
                    {

                    }
                }
                return Json(new { status = "success", result = "Đã lưu thông tin yêu cầu thành công" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", result = ex.ToString() });
            }
        }
        [HttpPost, ValidateInput(false)]
        public JsonResult Create(object abc)
        {
            var xyz = abc;
            return Json(new { status = "success", result = "Đã lưu thông tin yêu cầu thành công" });
        }
      

    }

}