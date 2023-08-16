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
	public partial class CheckoutHistory : ContentPage
	{
		App app = (App)Application.Current;
		public CheckoutHistory()
		{
			InitializeComponent();
			MyCartView.ItemsSource = app.PurchaseHistory;

		}

		private async void btnBack_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		private async void btnAbout_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AboutPage());
		}

		private async void MyCartView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null) //User has selected an item
			{
				Pizza cartpizza = e.SelectedItem as Pizza; //Storing the selected item in cartpizza variable

				//Viewing cart details and if user wants to remove item from cart
				await DisplayAlert("Selected", "Name: " + cartpizza.Name.ToString() + "\nPrice: £" + cartpizza.Price.ToString() + "\nSize: " + cartpizza.Size.ToString() + "\nIngredients: " + cartpizza.Ingredients.ToString(), "Remove", "Cancel");

				((ListView)sender).SelectedItem = null;

			}
		}
	}
}