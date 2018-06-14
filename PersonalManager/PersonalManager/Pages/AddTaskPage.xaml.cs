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

        }

        private async void Close_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            if (EntryTask.Text != string.Empty && EntryPeople.Text != string.Empty)
            {

                var connection = DatabaseLoader.Connection;
                var s = connection.Insert(new TaskItem()
                {
                    Message = EntryTask.Text
                });

                await Navigation.PopModalAsync();
            }

        }
    }
}