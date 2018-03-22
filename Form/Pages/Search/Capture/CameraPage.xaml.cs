using System;
using System.IO;
using System.Net;
using Form.Helps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Form.Pages.Search.Capture
{
    /// <summary>
    ///     This page is use to capture image
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraPage : ContentPage
    {
        public CameraPage()
        {
            InitializeComponent();

            //
            CameraButton.Clicked += CameraButton_Clicked;
        }

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            if (Plugin.Media.CrossMedia.Current.IsCameraAvailable)
            {
                var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

                if (photo != null)
                    PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });

                /*
                var stream = photo.GetStream();

                var image1 = EmguCVImageHelper.ConvertFromImageSource(stream);
                var image2 = EmguCVImageHelper.ConvertFromImageSource(stream);

                long calTime = 0;
                var result = DrawMatches.Draw(image1, image2, out calTime);

                PhotoImage.Source = ImageSource.FromStream(() => EmguCVImageHelper.ConvertFromEmguCVImage(result));
                */
            }
            else
            {
                //
                await DisplayAlert("Cannot find camera.", "Error", "OK");
            }
        }
    }
}