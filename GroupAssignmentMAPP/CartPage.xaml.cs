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
	public partial class CartPage : ContentPage
	{

		App app = (App)Application.Current;

		public CartPage()
		{
			InitializeComponent();

			MyCartView.ItemsSource = app.cart; //Making listview in CartPage.xaml show the pizzas the user added

			double SubTotal = 0; //Initializing variables for price information
			double VAT = 0;
			double GrandTotal = 0;
			if (app.cart.Count != 0) //Checking if the user added items to cart
			{
				foreach (Pizza pizza in app.cart)
				{
					SubTotal += pizza.Price; //Getting the total price without VAT
				}
				VAT = SubTotal * 0.05;
				GrandTotal = VAT + SubTotal;

				lblSubTotal.Text = "Subtotal: £" + SubTotal.ToString("0.00"); //Formatting Subtotal string
				lblVAT.Text = "VAT: £" + VAT.ToString("0.00") + " (5% VAT)"; //Formatting VAT string
				lblGrandTotal.Text = "Grand Total: £" + GrandTotal.ToString("0.00"); //Formatting GrandTotal string
				app.GrandTotalGlobal = GrandTotal.ToString("0.00"); //Storing GrandTotal in global variable
			}
			else
			{
				btnCheckout.IsEnabled = false; //If no item is present, checkout button isn't usable
			}

			if (app.Checkedout == true)
			{
				//btnCartHistory.IsEnabled = true;
			}
			else
			{
				//btnCartHistory.IsEnabled = false;
			}

		}

		private async void MyCartView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null) //User has selected an item
			{
				Pizza cartpizza = e.SelectedItem as Pizza; //Storing the selected item in cartpizza variable

				//Viewing cart details and if user wants to remove item from cart
				//bool response = await DisplayAlert("Selected", "Name: " + cartpizza.Name.ToString() + "\nPrice: £" + cartpizza.Price.ToString() + "\nSize: " + cartpizza.Size.ToString() + "\nIngredients: " + cartpizza.Ingredients.ToString(), "Remove", "Cancel");
				app.ActivePizza = e.SelectedItem as Pizza;

				app.ActivePizza = cartpizza;

				((ListView)sender).SelectedItem = null;
				//await DisplayAlert("Test", response.ToString(), "Ok");

				//if (response)
				//{
				//	//Item is removed from cart
				//	app.cart.RemoveAt(e.SelectedItemIndex);
				//	await Application.Current.MainPage.Navigation.PopAsync();
				//}

				await Navigation.PushAsync(new CartUpdatePage());

			}
		}

		private async void btnCheckout_Clicked(object sender, EventArgs e)
		{
			//Navigating to Checkout page
			app.PurchaseHistory.AddRange(app.cart);
			await Navigation.PushAsync(new CheckoutNew());
		}

		private async void btnAbout_Clicked(object sender, EventArgs e)
		{
			//Navigating to AboutPage
			await Navigation.PushAsync(new AboutPage());
		}

		private async void btnCartHistory_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CheckoutHistory());
		}
	}
}