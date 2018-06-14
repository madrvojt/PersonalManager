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
        private ObservableCollection<TaskItem> _collections;

        public TasksPage()
		{
			InitializeComponent ();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddTaskPage());
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            var connection = DatabaseLoader.Connection;
            var items = connection.Table<TaskItem>().ToList();
            var contacts = connection.Table<Contact>().ToList();
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                var contact = contacts.Where(x => x.Id == item.ContactId).FirstOrDefault();
                if (contact != null)
                {
                    item.ContactName = contact.Name;

                }
                items[i] = item;
            }

            _collections = new ObservableCollection<TaskItem>(items);
            TasksListView.ItemsSource = _collections;
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var taskItem = (TaskItem)((MenuItem)sender).CommandParameter;

            var connection = DatabaseLoader.Connection;
            var items = connection.Table<TaskItem>().ToList();
            var item = items.Where(x => x.Id == taskItem.Id).FirstOrDefault();

            connection.Delete(item);
            var itemForRemove = _collections.Where(x => x.Id == item.Id).FirstOrDefault();
            _collections.Remove(itemForRemove);
        }
    }
}