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
	public partial class Checkout : ContentPage
	{
		App app = (App)Application.Current;
		public Checkout()
		{
			InitializeComponent();
		}

		private async void btnCheckout_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CheckoutSuccess());
		}
	}
}