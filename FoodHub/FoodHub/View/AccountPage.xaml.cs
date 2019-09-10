using FoodHub.Helper;
using FoodHub.ViewModel;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodHub.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        MediaFile mediaFile;
        readonly FirebaseStorageHelper firebaseStorageHelper = new FirebaseStorageHelper();
        readonly AccountViewModel accountViewModel;

        public AccountPage(string username, string address, string phoneNumber)
        {
            accountViewModel = new AccountViewModel(username, address, phoneNumber);
            InitializeComponent();
            BindingContext = accountViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        // Upload user image
        private async void BtnPick_Clicked(object sender, EventArgs e)
        {
            // Check if device allows to access folders
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                _ = DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            else
            {
                await CrossMedia.Current.Initialize();
                try
                {
                    mediaFile = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                    {
                        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                    });

                    if (mediaFile == null)
                    {
                        return;
                    }

                    imageChoosed.Source = ImageSource.FromStream(() =>
                    {
                        return mediaFile.GetStream();
                    });

                    if (File.Exists(mediaFile.Path))
                    {
                        DependencyService.Get<IFileManager>().DeleteFile(mediaFile.Path);
                    }
                    mediaFile.Dispose();

                    await firebaseStorageHelper.UploadImage(mediaFile.GetStream(), Path.GetFileName(mediaFile.Path));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}