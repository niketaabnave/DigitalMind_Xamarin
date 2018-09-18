using System;
using Xamarin.Forms;
using DigitalMindTest.Views;
using Xamarin.Forms.Xaml;
using DLToolkit.Forms.Controls;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DigitalMindTest
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

			FlowListView.Init(); 
			MainPage = new MainTabbedPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
