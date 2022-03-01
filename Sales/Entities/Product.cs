using System.Globalization;

namespace Sales.Entities
{
	class Product
	{
		public string Name { get; protected set; }
		public double Price { get; protected set; }
		public int Quantity { get; protected set; }

		public Product()
		{
		}

		public Product(string name, double price, int quantity)
		{
			Name = name;
			Price = price;
			Quantity = quantity;
		}

		public double TotalValue()
		{
			return Price * Quantity;
		}

		public override string ToString()
		{
			return Name
				+ ", "
				+ TotalValue().ToString("F2", CultureInfo.InvariantCulture);
		}
	}
}
