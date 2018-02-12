using System.IO;
using System.Threading.Tasks;

namespace IC6.Xamarin.PictureUpload
{
    internal interface IApiContext
    {
        Task<bool> UploadImageAsync(Stream image, string fileName);
         
    }
}