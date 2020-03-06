using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MEU.web.Helpers
{
    public interface IImageHelper
    {
        Task<string> UpLoadImageAsync(IFormFile imageFile);
    }
}
