using System;
using System.Collections.Generic;
using DigitalMindTest.ViewModels;
using Xamarin.Forms;

namespace DigitalMindTest.Views
{
    public partial class ShoesPage : ContentPage
    {
		ShoesPageViewModel viewModel;
        public ShoesPage()
        {
            InitializeComponent();
			BindingContext = viewModel = new ShoesPageViewModel();
        }
    }
}
