using PersonalManager.Entities;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace PersonalManager
{
	public partial class App : Application
	{


        public App ()
		{
            #if DEBUG
            LiveReload.Init();
            #endif

            InitializeComponent();


			MainPage = new MainPage();

         

        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
