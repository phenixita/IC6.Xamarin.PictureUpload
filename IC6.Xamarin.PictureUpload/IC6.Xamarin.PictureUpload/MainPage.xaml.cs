using IC6.Xamarin.PictureUpload.ViewModels;
using System;
using Xamarin.Forms;

namespace IC6.Xamarin.PictureUpload
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel(DependencyService.Get<IImagePicker>(), new ApiService());
        }
         
    }
}