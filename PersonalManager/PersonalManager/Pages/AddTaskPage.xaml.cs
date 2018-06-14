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
	public partial class AddTaskPage : ContentPage
	{
		public AddTaskPage ()
		{
			InitializeComponent ();
            Close.Clicked += Close_Clicked;
            Save.Clicked += Save_Clicked;
            var connection = DatabaseLoader.Connection;
            var contacts = connection.Table<Contact>().ToList().Select(x => x.Name).ToList();
            PickerContact.ItemsSource = contacts;

        }

        private async void Close_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            if (EntryTask.Text != string.Empty)
            {
                var connection = DatabaseLoader.Connection;
                var contactForDatabase = connection.Table<Contact>().Where(x => x.Name == (string)PickerContact.SelectedItem).FirstOrDefault();

                var s = connection.Insert(new TaskItem()
                {
                    Message = EntryTask.Text,
                    ContactId = contactForDatabase.Id

                });

                await Navigation.PopModalAsync();
            }

        }
    }
}