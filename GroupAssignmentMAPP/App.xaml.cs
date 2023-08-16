using System.Collections.Generic;
using Xamarin.Forms;

namespace GroupAssignmentMAPP
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new SplashPage());

		}

		public Pizza ActivePizza { get; set; } //Variable to store Pizza the user selected in MainPage
		public Pizzas ActivePizzaList = MakePizzas(); //This stores the list of available pizzas
		public List<Pizza> cart = new List<Pizza>(); //Variable to store the list of pizzas the user added to cart
		public string DeliveryType; //Global variable to store delivery type between pages
		public string GrandTotalGlobal; //Global variable to store grand total between pages
		public List<Pizza> PurchaseHistory = new List<Pizza>(); // Variable to store checkout history
		public bool Checkedout = false;
		public static Pizzas MakePizzas() //Function to make current pizza list
		{
			Pizzas pizzas = new Pizzas("Pizzas"); //Making a new Pizzas object
			pizzas.PizzasList.Add(new Pizza(1, "Rustica Italian Garden", 19.99, 19.99, "artichokes, baby romanesco cauliflower and baby spinach, with vegan MozzaRisella", "Large", "RusticaItalianGarden.jpg")); //Adding pizzas to object
			pizzas.PizzasList.Add(new Pizza(2, "Rustica Half & Half Duo Verde", 19.99, 19.99, "One half, with goat’s cheese, figs, sticky balsamic glaze and rocket. The other, Bufala mozzarella, roquito pearls, baby romanesco cauliflower and pine nuts.", "Large", "RusticaHalfHalfDuoVerde.jpg"));
			pizzas.PizzasList.Add(new Pizza(3, "Rustica Margherita", 19.99, 19.99, "made in our signature Rustica style with tomato, mozzarella and fresh basil.", "Large", "RusticaMargherita.png"));
			pizzas.PizzasList.Add(new Pizza(4, "Rustica Meat Sofia", 19.99, 19.99, "harissa chicken breast, pepperoni and torn pork & garlic meatballs", "Large", "RusticaMeatSofia.jpg"));
			pizzas.PizzasList.Add(new Pizza(5, "Rustica Primavera", 19.99, 19.99, "Goat’s cheese, artichokes, spinach, fire-roasted peppers, olives, mozzarella, sunblush tomatoes, rocket and pesto", "Large", "RusticaPrimavera.jpg"));
			//pizzas.PizzasList.Add(new Pizza(6, "Original Cheese and Tomato", 17.99, 17.99, "Our original Cheese & Tomato pizza with even more cheese", "Large", "cheeseandtomato.jpg"));
			//pizzas.PizzasList.Add(new Pizza(7, "Vegi Supreme", 19.99, 19.99, "Onions, green and red peppers, sweetcorn, mushrooms, tomatoes", "Large", "vegisupreme.jpg"));
			//pizzas.PizzasList.Add(new Pizza(8, "American Hot", 19.99, 19.99, "Onions, pepperoni, jalapeno peppers", "Large", "americanhot.jpg"));
			//pizzas.PizzasList.Add(new Pizza(9, "Chicken Feast", 19.99, 19.99, "Chicken, mushrooms, sweetcorn", "Large", "chickenfeast.jpg"));

			return pizzas;
		}

		public bool LoggedIn; //Global variable to store if the user is logged in or not

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
