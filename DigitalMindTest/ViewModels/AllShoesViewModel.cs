using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DigitalMindTest.Models;
using Xamarin.Forms;

namespace DigitalMindTest.ViewModels
{
	public class AllShoesViewModel : BaseViewModel
    {
		public ObservableCollection<Shoes> TempList =new ObservableCollection<Shoes>();
		public ObservableCollection<Shoes> _allshoesList;
		public ObservableCollection<Shoes> AllShoesList
        {
			get { return _allshoesList; }
			set { SetProperty(ref _allshoesList, value); }
        }

		public Command LoadAllShoesCommand { get; set; }
		public Command<string> SearchShoesCommand { get; set; }
		public AllShoesViewModel()
        {
			LoadAllShoesCommand = new Command(async () => await LoadAllShoes());
			SearchShoesCommand = new Command<string>(async searchText => await SearchShoes(searchText));
        }

		async Task SearchShoes(string searchText)
		{
			ObservableCollection<Shoes> searchedList = new ObservableCollection<Shoes>();
			AllShoesList = TempList;
			foreach (Shoes shoes in AllShoesList)
            {
				if (shoes.Title.ToLower().Contains(searchText.ToLower()))
                {
					searchedList.Add(shoes);
                }
            }
			if (String.IsNullOrEmpty(searchText)){
				AllShoesList = TempList;
			}else{
				AllShoesList = searchedList;
			}
		}

		async Task LoadAllShoes()
		{
			AllShoesList = new ObservableCollection<Shoes>();
			AllShoesList.Add(new Shoes { Title = "Princes Shoes", Description = "Perfect", Price = "5 KM", IsFavourites = false, ShoesImageSource = "blue_casual_colors.jpg", FavImageSource = "star_selected.png" });
			AllShoesList.Add(new Shoes { Title = "Nice Sneaker", Description = "Light Used", Price = "3 KM", IsFavourites = false, ShoesImageSource = "shoes_two.png", FavImageSource = "star_not_selected.png" });
			AllShoesList.Add(new Shoes { Title = "Shoes With Lights", Description = "New", Price = "19 KM", IsFavourites = false, ShoesImageSource = "shoes_two.png", FavImageSource = "star_selected.png" });
			AllShoesList.Add(new Shoes { Title = "Classic Vans", Description = "Used", Price = "12 KM", IsFavourites = false, ShoesImageSource = "blue_casual_colors.jpg", FavImageSource = "star_not_selected.png" });
			AllShoesList.Add(new Shoes { Title = "Ballarina Shoe", Description = "Used", Price = "5 KM", IsFavourites = false, ShoesImageSource = "blue_casual_colors.jpg", FavImageSource = "star_not_selected.png" });
			AllShoesList.Add(new Shoes { Title = "Black Sneakers", Description = "Heavy Used", Price = "1 KM", IsFavourites = false, ShoesImageSource = "blue_casual_colors.jpg", FavImageSource = "star_not_selected.png" });
			TempList = AllShoesList;
		}
	}
}
