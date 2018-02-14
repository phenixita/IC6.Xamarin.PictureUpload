using System.IO;
using System.Threading.Tasks;

namespace IC6.Xamarin.PictureUpload
{
    public interface IApiService
    {
        Task<bool> UploadImageAsync(Stream image, string fileName);
    }
}