using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DigitalMindTest.Models;
using DigitalMindTest.Views;
using Xamarin.Forms;

namespace DigitalMindTest.ViewModels
{
	public class ShoesPageViewModel : BaseViewModel
    {
		public ObservableCollection<View> _carouselItemSource;
        public ObservableCollection<View> CarouselItemSource
        {
            get { return _carouselItemSource; }
            set { SetProperty(ref _carouselItemSource, value); }
        }
        int _position = 0;
        public int Position
        {
			get { return _position; }
			set { SetProperty(ref _position, value); }
        }
		bool _allShowing = true;
		public bool AllShowing
        {
			get { return _allShowing; }
			set { SetProperty(ref _allShowing, value); }
        }
		bool _favShowing = false;
		public bool FavShowing
        {
			get { return _favShowing; }
			set { SetProperty(ref _favShowing, value); }
        }
		string _searchText = "";
		public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
					SearchShoes.Execute(value);
				SetProperty(ref _searchText, value, nameof(SearchText));
            }
        }
        public Command ShowAllPage { get; set; }
        public Command ShowFavPage { get; set; }
		public Command<string> SearchShoes { get; set; }
		AllShoesPage allShoesPage = new AllShoesPage();
        FavouritesShoesPage favouritesShoesPage = new FavouritesShoesPage();
            
        public ShoesPageViewModel()
        {
			CarouselItemSource = new ObservableCollection<View>()
            {
				allShoesPage,favouritesShoesPage
            };
			Title = "SHOESWAP";
            ShowAllPage = new Command(async () => await showAllShoes());
            ShowFavPage = new Command(async () => await showFavShoes());
			SearchShoes = new Command<string>(async searchQuery =>  await searchShoesByTitle(searchQuery));
        }
        
		async Task searchShoesByTitle(string searchQuery)
		{
			
			if(Position ==0){
				allShoesPage.viewModel.SearchShoesCommand.Execute(searchQuery);

			}else{
				favouritesShoesPage.viewModel.SearchShoesCommand.Execute(searchQuery);
            }

		}

		async Task showFavShoes()
        {
			 Position = 1;
			FavShowing = true;
			AllShowing = false;
        }

        async Task showAllShoes()
        {
			 Position = 0;
			FavShowing = false;
			AllShowing = true;
        }
    }
}
