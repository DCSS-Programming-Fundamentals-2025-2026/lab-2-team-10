using System;

namespace MediaCatalogApp
{
	public class MediaCatalog
	{
		private const int MaxItems = 200;
		private MediaItem[] items = new MediaItem[MaxItems];
		private int count = 0;

		public void AddItem(string title, MediaType type, double rating)
		{
			if (count >= MaxItems)
			{
				Console.WriteLine("Помилка: Каталог переповнений.");
				return;
			}

			items[count] = new MediaItem
			{
				Title = title,
				Type = type,
				Rating = rating
			};
			count++;

			Console.WriteLine("Елемент додано!");
		}

		public void SearchByTitle(string query)
		{
			Console.WriteLine("\n--- Результати пошуку ---");
			bool found = false;
			string queryLower = query.ToLower();

			for (int i = 0; i < count; i++)
			{
				if (items[i].Title.ToLower().Contains(queryLower))
				{
					Console.WriteLine($"[{items[i].Type}] {items[i].Title} - Рейтинг: {items[i].Rating}");
					found = true;
				}
			}

			if (!found) Console.WriteLine("Нічого не знайдено.");
		}

		public void FilterByType(MediaType type)
		{
			Console.WriteLine($"\n--- Фільтр: {type} ---");
			for (int i = 0; i < count; i++)
			{
				if (items[i].Type == type)
				{
					Console.WriteLine($"[{items[i].Type}] {items[i].Title} - Рейтинг: {items[i].Rating}");
				}
			}
		}

		public void ShowTop5()
		{
			Console.WriteLine("\n--- ТОП-5 за рейтингом ---");
			if (count == 0) return;

			MediaItem[] tempArray = new MediaItem[count];
			Array.Copy(items, tempArray, count);
			for (int i = 0; i < count - 1; i++)
			{
				for (int j = 0; j < count - i - 1; j++)
				{
					if (tempArray[j].Rating < tempArray[j + 1].Rating)
					{
						MediaItem temp = tempArray[j];
						tempArray[j] = tempArray[j + 1];
						tempArray[j + 1] = temp;
					}
				}
			}

			int itemsToShow = Math.Min(count, 5);
			for (int i = 0; i < itemsToShow; i++)
			{
				Console.WriteLine($"#{i + 1}. {tempArray[i].Title} ({tempArray[i].Rating})");
			}
		}

		public void ShowAverageRating()
		{
			if (count == 0)
			{
				Console.WriteLine("Каталог порожній.");
				return;
			}

			double sum = 0;
			for (int i = 0; i < count; i++) sum += items[i].Rating;

			Console.WriteLine($"Середній рейтинг: {sum / count:F2}");
		}
	}
}