using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GroupAssignmentMAPP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PizzaDetail : ContentPage
	{
		App app = (App)Application.Current;
		public PizzaDetail()
		{
			InitializeComponent();
			//Displaying Pizza information from global variable 
			txtPizzaName.Text = app.ActivePizza.Name;
			txtPizzaPrice.Text = app.ActivePizza.Price.ToString();
			txtPizzaIngredients.Text = app.ActivePizza.Ingredients;
			ImgPizzaImg.File = app.ActivePizza.Image;
		}

		private async void btnCancel_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync(); //Going back if user wants to cancel
		}

		private async void btnAddToCart_Clicked(object sender, EventArgs e)
		{

			if(PkrPizzaSize.SelectedIndex == -1) //User hasn't selected a size
			{
				await DisplayAlert("Error!", "Please Select Pizza Size!", "Ok"); //DisplayAlert to prompt user to pick a size
				return; //Exiting function
			}
			//Adding to cart confirmation
			bool response = await DisplayAlert("Add To Cart?", "Are you sure you want to add " + app.ActivePizza.Name.ToString() + " to the cart?", "Yes", "No");

			if (response) //User wants to add pizza to cart
			{
				if (PkrPizzaSize.SelectedIndex == 0)
				{
					//Adding Pizza to cart
					app.cart.Add(app.ActivePizza);
				}
				else if(PkrPizzaSize.SelectedIndex == 1)
				{
					//Adding Pizza to cart if selected size is medium
					app.ActivePizza.Size = "Medium";
					app.ActivePizza.Price = Math.Round(app.ActivePizza.Price * 0.8, 2);
					app.cart.Add(app.ActivePizza);
				}
				else
				{
					//Adding Pizza to cart if selected size is medium
					app.ActivePizza.Size = "Small";
					app.ActivePizza.Price = Math.Round(app.ActivePizza.Price * 0.6, 2);
					app.cart.Add(app.ActivePizza);
				}
				

				await Navigation.PushAsync(new CartPage()); //Navigation
			}
		}

		private void PkrPizzaSize_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (PkrPizzaSize.SelectedIndex == 0)
			{
				txtPizzaPrice.Text = app.ActivePizza.MaxPrice.ToString("0.00"); //Formatting Price
			}
			if (PkrPizzaSize.SelectedIndex == 1)
			{
				txtPizzaPrice.Text = (app.ActivePizza.MaxPrice * 0.8).ToString("0.00"); //Formatting Price and adding discount since pizza size is Medium
			}
			if(PkrPizzaSize.SelectedIndex == 2)
			{
				txtPizzaPrice.Text = (app.ActivePizza.MaxPrice * 0.6).ToString("0.00"); //Formatting Price and adding discount since pizza size is Small
			}
		}

		private async void btnAbout_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AboutPage()); //Navigation
		}
	}
}