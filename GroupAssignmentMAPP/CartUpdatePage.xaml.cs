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
	public partial class CartUpdatePage : ContentPage
	{
		App app = (App)Application.Current;
		public CartUpdatePage()
		{
			InitializeComponent();
			ImgPizzaImg.File = app.ActivePizza.Image;
			txtPizzaName.Text = app.ActivePizza.Name;
			txtPizzaIngredients.Text = app.ActivePizza.Ingredients;
			txtPizzaPrice.Text = app.ActivePizza.Price.ToString("0.00");
			txtCurrentSize.Text = app.ActivePizza.Size.ToString();
		}

		private async void btnAbout_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AccountPage()); //Navigation
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
			if (PkrPizzaSize.SelectedIndex == 2)
			{
				txtPizzaPrice.Text = (app.ActivePizza.MaxPrice * 0.6).ToString("0.00"); //Formatting Price and adding discount since pizza size is Small
			}
		}

		private async void btnUpdate_Clicked(object sender, EventArgs e)
		{

			if (PkrPizzaSize.SelectedIndex == 0)
			{
				//Adding Pizza to cart
				app.ActivePizza.Size = "Large";
			}
			else if (PkrPizzaSize.SelectedIndex == 1)
			{
				//Adding Pizza to cart if selected size is medium
				app.ActivePizza.Size = "Medium";
				app.ActivePizza.Price = Math.Round(app.ActivePizza.Price * 0.8, 2);
			}
			else
			{
				//Adding Pizza to cart if selected size is medium
				app.ActivePizza.Size = "Small";
				app.ActivePizza.Price = Math.Round(app.ActivePizza.Price * 0.6, 2);
			}


			app.ActivePizza.Price = Convert.ToDouble(txtPizzaPrice.Text);
			Pizza result = app.cart.Find(x => x.ID == app.ActivePizza.ID);
			app.cart.Remove(result);
			app.cart.Add(app.ActivePizza);
			await Navigation.PopAsync();
			await Navigation.PopAsync();
			await Navigation.PushAsync(new CartPage());
			//app.cart.Add(app.ActivePizza);
		}

		private async void btnRemove_Clicked(object sender, EventArgs e)
		{
			app.cart.RemoveAt(app.ActivePizza.ID);
			await Application.Current.MainPage.Navigation.PopAsync();
		}

		private async void btnCancel_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}