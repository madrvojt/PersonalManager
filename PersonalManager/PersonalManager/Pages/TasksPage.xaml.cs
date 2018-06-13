using PersonalManager.Database;
using PersonalManager.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalManager.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TasksPage : ContentPage
	{
        private ObservableCollection<string> _collections;

        public TasksPage()
		{
			InitializeComponent ();
            _collections = new ObservableCollection<string>();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddTaskPage());
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            var connection = DatabaseLoader.Connection;
            var items = connection.Table<TaskItem>().ToList().Select(s => s.Message).ToList();
            TasksListView.ItemsSource = items;
        }

    }
}