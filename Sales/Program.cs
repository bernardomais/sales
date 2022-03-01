using System;
using System.IO;
using System.Globalization;
using Sales.Entities;

namespace Sales
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter full path to file sales.csv: ");
			string sourcePath = Console.ReadLine();

			try
			{
				string[] lines = File.ReadAllLines(sourcePath);

				string targetPath = Path.GetDirectoryName(sourcePath) + @"\out";
				Directory.CreateDirectory(targetPath);

				targetPath += @"\summary.csv";

				using(StreamWriter sw = File.AppendText(targetPath))
				{
					foreach (string line in lines)
					{
						string[] values = line.Split(',');
						string name = values[0];
						double price = double.Parse(values[1], CultureInfo.InvariantCulture);
						int quantity = int.Parse(values[2]);

						Product p = new Product(name, price, quantity);

						sw.WriteLine(p);
					}
				}
			}
			catch (IOException e)
			{
				Console.WriteLine("An error occurred:");
				Console.WriteLine(e.Message);
			}
		}
	}
}
