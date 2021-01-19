using Newtonsoft.Json;
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
                if (!Request.Form.AllKeys.Any() && Request.QueryString["customformContentId"] == null && Request.QueryString["token"] == null)
                    throw new ArgumentNullException();
                int CustomFormContentId = 0;
                string token = "";
                try
                {
                    token = Request.QueryString["token"].ToString();
                    CustomFormContentId = Convert.ToInt32(Request.QueryString["customformContentId"].ToString());
                }
                catch
                {
                    throw new ArgumentNullException();
                }
                foreach (var item in Request.Form)
                {
                    string[] ids = new string[100];
                    CustomCellContentOBJ customCellContentOBJ = new CustomCellContentOBJ();
                    customCellContentOBJ.CustomFormContentId = CustomFormContentId;
                    if (item.ToString().Contains("_"))
                    {
                        ids = item.ToString().Split('_');
                        try
                        {
                            customCellContentOBJ.CustomFormBodyId = Convert.ToInt32(ids[0]);
                            customCellContentOBJ.CustomColumId = Convert.ToInt32(ids[1]);
                            customCellContentOBJ.NoRown = Convert.ToInt32(ids[2]);
                            customCellContentOBJ.Contents = Request.QueryString[item.ToString()].ToString() == null ? "": Request.QueryString[item.ToString()].ToString();
                        }
                        catch
                        {
                            throw new ArgumentNullException();
                        }
                    }
                    else
                    {

                    }
                    customCellContentOBJs.Add(customCellContentOBJ);
                }
                MultipartFormDataContent mFormData = new MultipartFormDataContent();
                //HttpFileCollectionBase listFile = HttpContext.Request.Files;
                if (customCellContentOBJs.Count>0) mFormData.Add(new StringContent(JsonConvert.SerializeObject(customCellContentOBJs)), nameof(customCellContentOBJs));
                //if (listFile.Count > 0)
                //{
                //    int i = 1;
                //    foreach (string file in listFile)
                //    {
                //        HttpPostedFileBase fileBase = Request.Files[file];
                //        byte[] fileData = null;
                //        using (var binaryReader = new BinaryReader(fileBase.InputStream))
                //        {
                //            fileData = binaryReader.ReadBytes(fileBase.ContentLength);
                //        }
                //        ByteArrayContent b = new ByteArrayContent(fileData);
                //        b.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                //        //byte[] binData = b.ReadBytes(fileBase.ContentLength);
                //        mFormData.Add(b, nameof(file) + i++.ToString(), fileBase.FileName);
                //    }
                //}
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api-pm-cmd.tayho.com.vn/");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    using (HttpResponseMessage response = client.PostAsync("api/cmd/v1/DocumentReleased", mFormData).Result)
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            var err = response.Content.ReadAsStringAsync().Result;
                            return Json(new { status = "error", result = err });
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", result = "Đã lưu thông tin yêu cầu không thành công" });
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