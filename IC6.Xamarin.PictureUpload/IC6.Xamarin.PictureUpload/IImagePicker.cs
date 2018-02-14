using System.Threading.Tasks;

namespace IC6.Xamarin.PictureUpload
{
    public interface IImagePicker
    {
        Task<FileStreamToUpload> GetImageStreamAsync();
    }
}