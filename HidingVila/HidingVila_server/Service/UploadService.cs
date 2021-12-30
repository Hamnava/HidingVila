using HidingVila_server.Service.IService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HidingVila_server.Service
{
    public class UploadService : IUploadFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _accessor;
        public UploadService(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor accessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _accessor = accessor;
        }
        public bool DeleteFile(string filename)
        {
            try
            {
                var path = $"{_webHostEnvironment.WebRootPath}\\RoomImages\\{filename}";
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(file.Name);
                var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
                var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\RoomImages";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "RoomImages", fileName);

                var memorystream = new MemoryStream();
                await file.OpenReadStream().CopyToAsync(memorystream);

                if (!Directory.Exists(folderDirectory))
                {
                    Directory.CreateDirectory(folderDirectory);
                }

                await using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    memorystream.WriteTo(fs);
                }
                var url = $"{_accessor.HttpContext.Request.Scheme}://{_accessor.HttpContext.Request.Host.Value}/";
                var fullpath = $"{url}RoomImages/{fileName}";
                return fullpath;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
