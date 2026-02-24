
using System.Collections;
namespace MediaCatalogApp
{
	class Program
	{

		static void Main(string[] args)
		{

			MediaCatalog catalog = new MediaCatalog();


			while (true)
			{
				Console.WriteLine("\n=== МЕНЮ ===");
				Console.WriteLine("1. Додати елемент");
				Console.WriteLine("2. Пошук");
				Console.WriteLine("3. Фільтр");
				Console.WriteLine("4. ТОП-5");
				Console.WriteLine("5. Середній рейтинг");
				Console.WriteLine("6. Видалити елемент");
				Console.WriteLine("9. Вивів через (Enumerator)");
				Console.WriteLine("10. Сортування ща рейтингом ");
				Console.WriteLine("0. Вихід");

				Console.Write("Ваш вибір: ");

				string choice = Console.ReadLine();

				try
				{
					switch (choice)
					{                                     //Добавив трай для обробки помилок
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

						case "6":
							Console.WriteLine("Індекс елемента який ви хочете видалити");
							int index = int.Parse(Console.ReadLine());
							catalog.RemoveAt(index);
							break;

						case "7":
							Console.WriteLine("Індекс елемента який ви хочете побачити");
							int index1 = int.Parse(Console.ReadLine());
							MediaItem item = catalog.GetAt(index1);
							Console.WriteLine(item);
							break;

						case "8":
							Console.WriteLine("Індекс елемента який ви хочете замінити");
							int index2 = int.Parse(Console.ReadLine());
							Console.WriteLine("Нове ім'я ");

							string Newname = Console.ReadLine();
							Console.WriteLine(" Тип: 1 - Книжка : 2 - Фільм ");

							int inte = int.Parse(Console.ReadLine());
							MediaType type = (MediaType)inte;

							Console.WriteLine("Rating");
							int rating = int.Parse(Console.ReadLine());

							MediaItem mediaItem = new MediaItem(Newname, type, rating);
							catalog.SetAt(index2, mediaItem);
							break;
						case "0":
							return;

						case "9":
							IEnumerator it = catalog.GetEnumerator();
							while (it.MoveNext())
							{
								Console.WriteLine(it.Current);
							}
							break;

						case "10":
							catalog.SortbyRating();
							break;

							case "11":
							catalog.SortByTitles();
							break;
							
						default:
							Console.WriteLine("Невірний ввід.");
							break;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}

			}
		}



		static void AddNewItem(MediaCatalog catalog)
		{
			Console.Write("Назва: ");
			string title = Console.ReadLine();

			Console.Write("Тип (1-Книга, 2-Фільм): ");
			int enamtype = int.Parse(Console.ReadLine());
			MediaType type = (MediaType)enamtype;

			Console.Write("Рейтинг (0-10): ");
			if (int.TryParse(Console.ReadLine(), out int rating))
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








