using System;

namespace MediaCatalogApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			MediaCatalog catalog = new MediaCatalog();

			bool running = true;
			while (running)
			{
				Console.WriteLine("\n=== МЕНЮ ===");
				Console.WriteLine("1. Додати елемент");
				Console.WriteLine("2. Пошук");
				Console.WriteLine("3. Фільтр");
				Console.WriteLine("4. ТОП-5");
				Console.WriteLine("5. Середній рейтинг");
				Console.WriteLine("0. Вихід");
				Console.Write("Ваш вибір: ");

				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						AddNewItem(catalog);
						break;
					case "2":
						Console.Write("Текст для пошуку: ");
						catalog.SearchByTitle(Console.ReadLine());
						break;
					case "3":
						FilterItems(catalog);
						break;
					case "4":
						catalog.ShowTop5();
						break;
					case "5":
						catalog.ShowAverageRating();
						break;
					case "0":
						running = false;
						break;
					default:
						Console.WriteLine("Невірний ввід.");
						break;
				}
			}
		}

		static void AddNewItem(MediaCatalog catalog)
		{
			Console.Write("Назва: ");
			string title = Console.ReadLine();

			Console.Write("Тип (1-Книга, 2-Фільм): ");
			string typeStr = Console.ReadLine();
			MediaType type = (typeStr == "1") ? MediaType.Book : MediaType.Movie;

			Console.Write("Рейтинг (0-10): ");
			if (double.TryParse(Console.ReadLine(), out double rating))
			{
				catalog.AddItem(title, type, rating);
			}
			else
			{
				Console.WriteLine("Помилка: введіть числове значення рейтингу.");
			}
		}

		static void FilterItems(MediaCatalog catalog)
		{
			Console.Write("Тип для фільтрації (1-Книга, 2-Фільм): ");
			string typeStr = Console.ReadLine();
			catalog.FilterByType(typeStr == "1" ? MediaType.Book : MediaType.Movie);
		}
	}
}