using System;
using System.Collections.Generic;
using DigitalMindTest.ViewModels;
using Xamarin.Forms;

namespace DigitalMindTest.Views
{
	public partial class FavouritesShoesPage : StackLayout
    {
		public FavouritesShoesPageViewModel viewModel;
        public FavouritesShoesPage()
        {
            InitializeComponent();
			BindingContext = viewModel = new FavouritesShoesPageViewModel();
			viewModel.LoadFavShoesCommand.Execute(null);
        }
    }
}
