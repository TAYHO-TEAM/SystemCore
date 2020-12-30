using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.ThongTin.Controllers
{
    public class DangKyController : Controller
    {
        // GET: ThongTin/DangKy
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PheDuyet()
        {
            return View();
        }
        public ActionResult _DetailRequestRegist(int Id)
        {
            return PartialView(Id);
        }
        public ActionResult _FormRegister()
        {
            return PartialView();
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult Create(RequestOBJ requestOBJ)
        {
            MultipartFormDataContent mFormData = new MultipartFormDataContent();
            HttpFileCollectionBase listFile = HttpContext.Request.Files;
            if (requestOBJ.DocumentTypeId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.DocumentTypeId).ToString()), ((int)requestOBJ.DocumentTypeId).ToString());
            if (requestOBJ.PlanRegisterId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.PlanRegisterId).ToString()), ((int)requestOBJ.PlanRegisterId).ToString());
            if (requestOBJ.ProjectId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.ProjectId).ToString()), ((int)requestOBJ.ProjectId).ToString());
            if (!string.IsNullOrEmpty(requestOBJ.Descriptions)) mFormData.Add(new StringContent(requestOBJ.Descriptions), requestOBJ.Descriptions );
            if (!string.IsNullOrEmpty(requestOBJ.Note)) mFormData.Add(new StringContent(requestOBJ.Note),requestOBJ.Note);
            if (requestOBJ.ParentId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.ParentId).ToString()), ((int)requestOBJ.ParentId).ToString());
            if (!string.IsNullOrEmpty(requestOBJ.Title))mFormData.Add(new StringContent(requestOBJ.Title), requestOBJ.Title);
            if (requestOBJ.WorkItemId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.WorkItemId).ToString()), nameof(requestOBJ.WorkItemId).ToString());
            if (listFile.Count > 0)
            {
                foreach (var file in listFile)
                {

                }

            }
            PostRegist(mFormData);
            return Json(new { status = "success", result = "Đã lưu thông tin yêu cầu thành công" });
        }
        public async Task PostRegist(MultipartFormDataContent mFormData)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api-pm-cmd.tayho.com.vn/");
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "multipart/form-data");
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

                //string filepath = "C:/Users/Popper/Desktop/Stackoverflow/MatchPositions.PNG";
                //string filename = "MatchPositions.PNG";

                MultipartFormDataContent content = new MultipartFormDataContent();
                ////ByteArrayContent fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(filepath));
                ////fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = filename };
                ////content.Add(fileContent);
                content.Add(new StringContent("1"), "DocumentTypeId");
                content.Add(new StringContent("1"), "PlanRegisterId");
                content.Add(new StringContent("1"), "ProjectId");
                content.Add(new StringContent("1"), "WorkItemId");
                //content.Add(new StringContent("Descriptions"), "abc");
                //content.Add(new StringContent("IsVisible"), "true");
                //content.Add(new StringContent("IsActive"), "true");


                using (HttpResponseMessage response = client.PostAsync("api/cmd/v1/RequestRegist", content).Result)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var err = response.Content.ReadAsStringAsync().Result;
                    }
                }

                //    HttpResponseMessage response =await  client.PostAsync("https://api-pm-cmd.tayho.com.vn/api/cmd/v1/RequestRegist", mFormData);
                //if (response.IsSuccessStatusCode)
                //{
                //    var retValue = await response.Content.ReadAsAsync<DocumentUploadResult>();
                //    return Ok(reyValue);
                //}
                //string returnString = await response.Content.ReadAsAsync<string>();
            }
        }
        public class RequestOBJ
        {
            public int? PlanRegisterId { get; set; }
            public string Code { get; set; }
            public string BarCode { get; set; }
            public string Title { get; set; }
            public string Descriptions { get; set; }
            public string Note { get; set; }
            public int? ParentId { get; set; }
            public int? Level { get; set; }
            public byte? NoAttachment { get; set; }
            public int? ProjectId { get; set; }
            public int? WorkItemId { get; set; }
            public int? DocumentTypeId { get; set; }
            public int? Rev { get; set; }

        }

    }
}