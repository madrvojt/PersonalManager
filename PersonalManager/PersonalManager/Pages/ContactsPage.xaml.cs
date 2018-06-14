using PersonalManager.Database;
using PersonalManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalManager.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactsPage : ContentPage
	{
		public ContactsPage ()
		{
			InitializeComponent ();
		}



        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddContact());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var connection = DatabaseLoader.Connection;
            var contacts = connection.Table<Contact>().ToList().Select(x => x.Name).ToList();
                  TasksListView.ItemsSource = contacts;
        }

    }
}