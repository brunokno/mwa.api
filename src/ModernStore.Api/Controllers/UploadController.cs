using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Fiver.Mvc.FileUpload.Models.Home;
//using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;
using ModernStore.Api.Models;
using MediatR;
using ModernStore.Domain.Core.Notifications;

namespace ModernStore.Api.Controllers
{
    [Produces("application/json")]
    //[Route("api/[controller]")]
    public class UploadController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        //private readonly IFileProvider fileProvider;

        public UploadController(
            INotificationHandler<DomainNotification> notifications,
            IHostingEnvironment hostingEnvironment
            //, IFileProvider fileProvider
            )
        {
            _hostingEnvironment = hostingEnvironment;
            //this.fileProvider = fileProvider;
        }

        //[HttpPost]
        //public async Task<IActionResult> UploadFile(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //        return Content("file not selected");

        //    var path = Path.Combine(
        //                Directory.GetCurrentDirectory(), "wwwroot",
        //                file.GetFilename());

        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }

        //    return RedirectToAction("Files");
        //}

        [Route("v1/download")]
        public async Task<IActionResult> Download() //string filename
        {
            string filename = "tl-logo-transparent.png";

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("v1/uploadfile")]
        public async Task UploadFile(Microsoft.AspNetCore.Http.IFormFile file)
        {
            //if (file == null) throw new Exception("File is null");
            //if (file.Length == 0) throw new Exception("File is empty");

            using (Stream stream = file.OpenReadStream())
            {
                using (var binaryReader = new BinaryReader(stream))
                {
                    var fileContent = binaryReader.ReadBytes((int)file.Length);
                    //await _uploadService.AddFile(fileContent, file.FileName, file.ContentType);
                }
            }
        }


        [HttpPost, DisableRequestSizeLimit]
        [Route("v1/mypage")]
        public async Task UploadFile(MyPageModel myPageModel)
        {
            var file = myPageModel.Image;

            //if (file == null) NotifyError("404", "arquivo vazio");
            //if (file.Length == 0) throw new Exception("File is empty");

            

            using (Stream stream = file.OpenReadStream())
            {
                using (var binaryReader = new BinaryReader(stream))
                {
                    var fileContent = binaryReader.ReadBytes((int)file.Length);
                    //await _uploadService.AddFile(fileContent, file.FileName, file.ContentType);
                }
            }
        }


        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}