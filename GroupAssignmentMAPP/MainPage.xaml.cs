using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace GroupAssignmentMAPP
{
	public partial class MainPage : ContentPage
	{

		App app = (App)Application.Current;

		public MainPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false); //Preventing navigation page from displaying
			/*
			List<Pizza> pizzas = new List<Pizza>();

			pizzas.Add(new Pizza(1, "Hawaiian", 19.99, "Ham, pineapple, mushrooms", "hawaiian.png"));
			pizzas.Add(new Pizza(2, "The Meatfielder", 19.99, "Pepperoni, ham, chorizo, pork meatballs and smoked bacon rashers", "meatfielder.jpg"));
			pizzas.Add(new Pizza(3, "Absolute Banger", 19.99, "Pepperoni, sausage, chorizo, hotdog slices and mozzarella cheese", "absolutebanger.jpg"));
			pizzas.Add(new Pizza(4, "The Cheeseburger", 19.99, "Double ground beef with fresh tomatoes, onions, sliced gherkins and drizzled with our special burger sauce", "cheeseburger.jpg"));
			pizzas.Add(new Pizza(5, "The Festive One", 19.99, "Sage & onion turkey, sausage smoked bacon, onions and mozzerella cheese on Pizza 4 Life's tomato sauce base", "thefestiveone.jpg"));
			pizzas.Add(new Pizza(6, "Original Cheese and Tomato", 17.99, "Our original Cheese & Tomato pizza with even more cheese", "cheeseandtomato.jpg"));
			pizzas.Add(new Pizza(7, "Vegi Supreme", 19.99, "Onions, green and red peppers, sweetcorn, mushrooms, tomatoes", "vegisupreme.jpg"));
			pizzas.Add(new Pizza(8, "American Hot", 19.99, "Onions, pepperoni, jalapeno peppers", "americanhot.jpg"));
			pizzas.Add(new Pizza(9, "Chicken Feast", 19.99, "Chicken, mushrooms, sweetcorn", "chickenfeast.jpg"));
			*/

			if (app.LoggedIn == false) //Changing what buttons are displayed depending on if user is logged in
			{
				btnLogout.IsVisible = false;
				btnAccount.IsVisible = true;
			}
			else
			{
				btnLogout.IsVisible = true;
				btnAccount.IsVisible = false;
			}


			MyListView.ItemsSource = app.ActivePizzaList.PizzasList; //Setting ItemSource of MainPage ListView to pizza list

		}

		private async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null) //Checking if user selected an item
			{
				Pizza selectedpizza = e.SelectedItem as Pizza;

				app.ActivePizza = selectedpizza; //Setting global variable to pizza the user selected

				((ListView)sender).SelectedItem = null; //Deselecting what the user selected

				await Navigation.PushAsync(new PizzaDetail()); //Navigation

			}
		}

		private async void btnAccount_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AccountPage()); //Navigation
		}

		private async void btnViewCart_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CartPage()); //Navigation
		}

		private void btnSearch_Clicked(object sender, EventArgs e)
		{
			string search = txtSearch.Text;

			var queriedpizzas = from Pizza pizza in app.ActivePizzaList.PizzasList where (pizza.Name.ToLower()).Contains(search.ToLower()) select pizza;

			MyListView.ItemsSource = queriedpizzas;
		}

		private async void btnLogout_Clicked(object sender, EventArgs e)
		{
			app.LoggedIn = false;
			await DisplayAlert("Logged out", "You are now logged out!", "Ok");
			btnLogout.IsVisible = false;
			btnAccount.IsVisible = true;
		}
	}

	public class Pizza
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public double MaxPrice { get; set; }
		public double Price { get; set; }
		public string Ingredients { get; set; }
		public string Size { get; set; }
		public string Image { get; set; }


		public Pizza(int pizzaid, string name, double price, double maxprice, string ingredients, string size, string image)
		{
			ID = pizzaid;
			Name = name;
			Price = price;
			MaxPrice = maxprice;
			Ingredients = ingredients;
			Size = size;
			Image = image;
		}

	}

	public class Pizzas
	{
		public string PizzaName { get; set; }
		public ObservableCollection<Pizza> PizzasList;
		public Pizzas(string pizzaname)
		{
			PizzaName = pizzaname;
			PizzasList = new ObservableCollection<Pizza>();
		}
	}

	/*public class Account
	{
		public int ID { get; set; }
		public string First_Name { get; set; }
		public string Last_Name { get; set; }
		public string Phone_Number { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }

		public Account(int accountid, string first_name, string last_name, string phone_number, string email, string address)
		{
			ID = accountid;
			First_Name = first_name;
			Last_Name = last_name;
			Phone_Number = phone_number;
			Email = email;
			Address = address;

		}

	}*/

}
