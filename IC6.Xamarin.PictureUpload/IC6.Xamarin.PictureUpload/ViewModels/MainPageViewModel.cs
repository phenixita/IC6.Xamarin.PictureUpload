using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace IC6.Xamarin.PictureUpload.ViewModels
{
    internal class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly IImagePicker _imagePickerSvc;

        private Command _uploadImage;

        private bool _uploadStatus;

        public MainPageViewModel(IImagePicker imagePicker, IApiService httpService)
        {
            _imagePickerSvc = imagePicker ?? throw new ArgumentNullException(nameof(imagePicker));
            _apiSvc = httpService ?? throw new ArgumentNullException(nameof(httpService));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IApiService _apiSvc { get; }
        public Command UploadImage
        {
            get
            {
                if (_uploadImage == null)
                {
                    _uploadImage = new Command(
                        async () =>
                        {
                            try
                            {
                                var theFileToUpload = await _imagePickerSvc.GetImageStreamAsync();

                                UploadStatus =  await _apiSvc.UploadImageAsync(theFileToUpload.StreamSource, theFileToUpload.FileName);
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine(ex.Message);
                            }
                        },
                        () =>
                        {
                            return true;
                        });
                }

                return _uploadImage;
            }
        }

        public bool UploadStatus
        {
            get
            {
                return _uploadStatus;
            }
            set
            {
                _uploadStatus = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(UploadStatus)));
            }
        }
    }
}