using IC6.Xamarin.PictureUpload.UWP;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;

[assembly: Xamarin.Forms.Dependency(typeof(ImagePicker))]

namespace IC6.Xamarin.PictureUpload.UWP
{
    public class ImagePicker : IImagePicker
    {


        public async Task<FileStreamToUpload> GetImageStreamAsync()
        {
            // Create and initialize the FileOpenPicker
            FileOpenPicker openPicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
            };

            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            // Get a file and return a Stream
            StorageFile storageFile = await openPicker.PickSingleFileAsync();

            if (storageFile == null)
            {
                return null;
            }

            IRandomAccessStreamWithContentType raStream = await storageFile.OpenReadAsync();
            return new FileStreamToUpload() { StreamSource = raStream.AsStreamForRead(), FileName = storageFile.Name };
        }
    }
}