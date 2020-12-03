using Acc.Cmd.Api.Controllers.v1.BaseClasses;
using Services.Common.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Acc.Cmd.Domain.Services;
using Services.Common.Media;

namespace Acc.Cmd.Api.Controllers.V1
{
    public class MediaController : APIControllerBase
    {

        private const string UploadFile = nameof(UploadFile);
        private const string SaveFile = nameof(SaveFile);
        private const string DownloadFile = nameof(DownloadFile);
        private readonly IMediaService _mediaService;

        public MediaController(IMediator mediator, IMediaService mediaService) : base(mediator)
        {
            _mediaService = mediaService;
        }

        /// <summary>
        /// Upload files.
        /// </summary>
        /// <param name="formFiles"></param>
        /// <returns></returns>
        [HttpPost(UploadFile)]
        [ProducesResponseType(typeof(MethodResult<List<MediaResponse>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UploadFileAsync(IEnumerable<IFormFile> formFiles)
        {
            var methodResult = new MethodResult<List<MediaResponse>>();
            methodResult.Result = await _mediaService.UploadFileAsync(formFiles).ConfigureAwait(false);
            return Ok(methodResult);
        }
        /// <summary>
        /// DownLoadFiles
        /// </summary>
        /// <param name="subDirectory"></param>
        /// <returns></returns>
        [HttpGet(DownloadFile)]
        [ProducesResponseType(typeof(MethodResult<List<MediaResponse>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DownloadFiles(string subDirectory)
        {
            var methodResult = new MethodResult<FileResponse>();
            methodResult.Result = await _mediaService.FetechFiles(subDirectory).ConfigureAwait(false);
            return Ok(methodResult);
           
        }
        /// <summary>
        /// SaveFile
        /// </summary>
        /// <param name="subDirectory"></param>
        /// <returns></returns>
        [HttpPost(SaveFile)]
        [ProducesResponseType(typeof(MethodResult<List<int>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SaveFileAsync([FromForm]IFormFileCollection files)
        {
            var methodResult = new MethodResult<int>();
            methodResult.Result = await _mediaService.SaveFile(files).ConfigureAwait(false);
            return Ok(methodResult);
           
        }
    }
}
