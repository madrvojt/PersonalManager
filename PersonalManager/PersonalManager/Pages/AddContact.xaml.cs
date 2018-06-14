using PersonalManager.Database;
using PersonalManager.Entities;
using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalManager.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddContact : ContentPage
	{
		public AddContact ()
		{
			InitializeComponent ();

            Close.Clicked += Close_Clicked;
            Save.Clicked += Save_Clicked;
        }

        private async void Close_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            if (EntryContact.Text != string.Empty)
            {
                var connection = DatabaseLoader.Connection;
                var s = connection.Insert(new Contact()
                {
                    Name = EntryContact.Text,

                });

                await Navigation.PopModalAsync();
            }

        }

        private async void ButtonPhoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                return;
            }



            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
            }

            if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "test",
                    Name = "test.jpg"
                });

                var stream = file.GetStream();
                var bytes = new byte[stream.Length];
                await stream.ReadAsync(bytes, 0, (int)stream.Length);
                string base64 = System.Convert.ToBase64String(bytes);
                Debug.WriteLine(base64);
            }
            else
            {
                await DisplayAlert("Permissions Denied", "Unable to take photos.", "OK");
                //On iOS you may want to send your user to the settings screen.
                //CrossPermissions.Current.OpenAppSettings();
            }


          

        }
    }
}