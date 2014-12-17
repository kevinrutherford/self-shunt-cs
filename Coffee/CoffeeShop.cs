using System.Collections.Generic;
using System;

namespace Coffee
{
	internal class CoffeeFlavour
	{
		private readonly string name;

		internal CoffeeFlavour (string newFlavour)
		{
			this.name = newFlavour;
		}

		public override string ToString ()
		{
			return name;
		}
	}

	internal class Menu
	{
		private Dictionary<string, CoffeeFlavour> flavours = new Dictionary<string, CoffeeFlavour> ();

		internal CoffeeFlavour Lookup (string flavorName)
		{
			if (!flavours.ContainsKey (flavorName))
				flavours.Add (flavorName, new CoffeeFlavour (flavorName));
			return flavours [flavorName];
		}

		internal int TotalCoffeeFlavoursMade ()
		{
			return flavours.Count;
		}
	}

	internal class Order
	{
		private readonly int tableNumber;
		private readonly CoffeeFlavour flavour;

		internal Order (int tableNumber, CoffeeFlavour flavour)
		{
			this.tableNumber = tableNumber;
			this.flavour = flavour;
		}

		internal void Serve ()
		{
			Console.WriteLine ("Serving " + flavour + " to table " + tableNumber);
		}
	}

	internal class CoffeeShop
	{
		private readonly List<Order> orders = new List<Order> ();
		private readonly Menu menu = new Menu ();

		internal void TakeOrder (string flavourName, int table)
		{
			CoffeeFlavour flavour = menu.Lookup (flavourName);
			Order order = new Order (table, flavour);
			orders.Add (order);
		}

		internal void Service ()
		{
			foreach (Order order in orders)
				order.Serve ();		
		}

		public static void Main (string[] args)
		{
			CoffeeShop shop = new CoffeeShop ();

			shop.TakeOrder ("Cappuccino", 2);
			shop.TakeOrder ("Frappe", 1);
			shop.TakeOrder ("Espresso", 1);
			shop.TakeOrder ("Frappe", 897);
			shop.TakeOrder ("Cappuccino", 97);
			shop.TakeOrder ("Frappe", 3);
			shop.TakeOrder ("Espresso", 3);
			shop.TakeOrder ("Cappuccino", 3);
			shop.TakeOrder ("Espresso", 96);
			shop.TakeOrder ("Frappe", 552);
			shop.TakeOrder ("Cappuccino", 121);
			shop.TakeOrder ("Espresso", 121);

			shop.Service ();
			Console.WriteLine ("\ntotal CoffeeFlavour objects made: "
				+ shop.menu.TotalCoffeeFlavoursMade ());
		}
	}
}