using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;

namespace HidingVila_server.Service.IService
{
    public interface IUploadFile
    {
        public Task<string> UploadFile(IBrowserFile file);
        public bool DeleteFile(string filename);
    }
}
