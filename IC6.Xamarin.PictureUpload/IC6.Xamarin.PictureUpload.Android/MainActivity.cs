using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using System;
using System.IO;
using System.Threading.Tasks;

namespace IC6.Xamarin.PictureUpload.Droid
{
    [Activity(Label = "IC6.Xamarin.PictureUpload", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        // Field, property, and method for Picture Picker
        public static readonly int PickImageId = 1000;

        public TaskCompletionSource<FileStreamToUpload> PickImageTaskCompletionSource { set; get; }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);

            if (requestCode == PickImageId)
            {
                if ((resultCode == Result.Ok) && (intent != null))
                {
                    Android.Net.Uri uri = intent.Data;

                    Stream stream = ContentResolver.OpenInputStream(uri);
                    var fileToUpload = new FileStreamToUpload()
                    {
                        FileName = Guid.NewGuid().ToString(),
                        StreamSource = stream
                    };

                    // Set the Stream as the completion of the Task
                    PickImageTaskCompletionSource.SetResult(fileToUpload);
                }
                else
                {
                    PickImageTaskCompletionSource.SetResult(null);
                }
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}