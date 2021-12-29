using HidingVila_server.Service.IService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HidingVila_server.Service
{
    public class UploadService : IUploadFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UploadService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public bool DeleteFile(string filename)
        {
            throw new System.NotImplementedException();
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

                var fullpath = $"RoomImages/{fileName}";
                return fullpath;
            }
            catch (System.Exception ex)
            {

                throw (ex);
            }
        }
    }
}
