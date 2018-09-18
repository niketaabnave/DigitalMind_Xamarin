using System;
using System.Collections.Generic;
using DigitalMindTest.ViewModels;
using Xamarin.Forms;

namespace DigitalMindTest.Views
{
	public partial class AllShoesPage : StackLayout
    {
		public AllShoesViewModel viewModel;
        public AllShoesPage()
        {
            InitializeComponent();
			BindingContext = viewModel = new AllShoesViewModel();
			viewModel.LoadAllShoesCommand.Execute(null);
        }

	}
}
