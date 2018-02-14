using Android.Content;
using IC6.Xamarin.PictureUpload.Droid;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ImagePickerDroid))]

namespace IC6.Xamarin.PictureUpload.Droid
{
    public class ImagePickerDroid : IImagePicker
    {
        

        public Task<FileStreamToUpload> GetImageStreamAsync()
        {
            // Define the Intent for getting images
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            // Get the MainActivity instance
            MainActivity activity = Forms.Context as MainActivity;

            // Start the picture-picker activity (resumes in MainActivity.cs)
            activity.StartActivityForResult(
                Intent.CreateChooser(intent, "Select Picture"),
                MainActivity.PickImageId);

            // Save the TaskCompletionSource object as a MainActivity property
            activity.PickImageTaskCompletionSource = new TaskCompletionSource<FileStreamToUpload>();

            // Return Task object
            return activity.PickImageTaskCompletionSource.Task;
        }
    }
}