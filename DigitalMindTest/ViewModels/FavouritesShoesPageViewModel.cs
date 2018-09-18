using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DigitalMindTest.Models;
using Xamarin.Forms;

namespace DigitalMindTest.ViewModels
{
	public class FavouritesShoesPageViewModel : BaseViewModel
    {
		public ObservableCollection<Shoes> TempList = new ObservableCollection<Shoes>();

		public ObservableCollection<Shoes> _favshoesList;
        public ObservableCollection<Shoes> FavShoesList
        {
            get { return _favshoesList; }
            set { SetProperty(ref _favshoesList, value); }
        }
		public Command LoadFavShoesCommand { get; set; }
		public Command<string> SearchShoesCommand { get; set; }

        public FavouritesShoesPageViewModel()
        {
			LoadFavShoesCommand = new Command(async () => await LoadFavShoes());
			SearchShoesCommand = new Command<string>(async searchText => await SearchShoes(searchText));

        }
		async Task LoadFavShoes()
        {
            FavShoesList = new ObservableCollection<Shoes>();
            FavShoesList.Add(new Shoes { Title = "Princes Shoes", Description = "Perfect", Price = "5 KM", IsFavourites = false, ShoesImageSource = "blue_casual_colors.jpg", FavImageSource = "star_selected.png" });
			FavShoesList.Add(new Shoes { Title = "Shoes With Lights", Description = "New", Price = "19 KM", IsFavourites = false, ShoesImageSource = "shoes_two.png", FavImageSource = "star_selected.png" });
			TempList = FavShoesList;
        }
		async Task SearchShoes(string searchText)
        {
            ObservableCollection<Shoes> searchedList = new ObservableCollection<Shoes>();
			FavShoesList = TempList;
			foreach (Shoes shoes in FavShoesList)
            {
				if (shoes.Title.ToLower().Contains(searchText.ToLower()))
                {
                    searchedList.Add(shoes);
                }
            }
            if (String.IsNullOrEmpty(searchText))
            {
				FavShoesList = TempList;
            }
            else
            {
				FavShoesList = searchedList;
            }
        }
    }
}

