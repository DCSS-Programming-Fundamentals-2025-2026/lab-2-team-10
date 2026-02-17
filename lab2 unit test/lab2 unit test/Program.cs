using System;
using Xunit;
using MediaCatalogApp;

namespace MediaCatalogApp.Tests
{
	public class MediaCatalogTests
	{
		[Fact]
		public void RemoveItem_ValidIndex_RemovesItemAndShiftsArray()
		{
			var catalog = new MediaCatalog();
			catalog.AddItem("Матриця", MediaType.Movie, 8.7);
			catalog.AddItem("CLR via C#", MediaType.Book, 9.5);
			catalog.AddItem("Володар перснів", MediaType.Movie, 9.0);

			catalog.RemoveItem(1);

			var items = catalog.GetAllItems();
			Assert.Equal(2, items.Length);
			Assert.Equal("Володар перснів", items[1].Title);
		}

		[Fact]
		public void GetAverageRating_WithValidItems_CalculatesCorrectly()
		{
			var catalog = new MediaCatalog();
			catalog.AddItem("Фільм 1", MediaType.Movie, 8.0);
			catalog.AddItem("Книга 1", MediaType.Book, 10.0);

			double average = catalog.GetAverageRating();

			Assert.Equal(9.0, average);
		}

		[Fact]
		public void AddItem_NegativeRating_ThrowsExceptionAndStateRemainsConsistent()
		{
			var catalog = new MediaCatalog();
			catalog.AddItem("Нормальний фільм", MediaType.Movie, 7.5);


			var exception = Assert.Throws<ArgumentException>(() =>
				catalog.AddItem("Поганий ввід", MediaType.Movie, -5.0)
			);

			var items = catalog.GetAllItems();
			Assert.Single(items);
			Assert.Equal("Нормальний фільм", items[0].Title);
		}

		[Fact]
		public void Integration_CreateAddRemove_GeneratesCorrectFinalReport()
		{
			var catalog = new MediaCatalog();

			catalog.AddItem("The Walking Dead", MediaType.Movie, 8.1);
			catalog.AddItem("Prison Break", MediaType.Movie, 8.3);
			catalog.AddItem("Dexter", MediaType.Movie, 8.6);

			catalog.RemoveItem(0);
			var topItems = catalog.GetTop5();
			double average = catalog.GetAverageRating();

			Assert.Equal(2, topItems.Length);
			Assert.Equal("Dexter", topItems[0].Title);
			Assert.Equal(8.45, average, precision: 2);

			[Fact]
			public void Integration_AddUntilFullAndFilter_WorksTogetherCorrectly()
			{
				var catalog = new MediaCatalog();
				for (int i = 0; i < 10; i++)
				{
					catalog.AddItem($"Книга {i}", MediaType.Book, 7.0);
				}
				catalog.AddItem("Dota: Dragon's Blood", MediaType.Movie, 7.8);
				catalog.AddItem("Red Dead Redemption 2: Story", MediaType.Movie, 9.8);

				var moviesOnly = catalog.GetFilteredByType(MediaType.Movie);
				Assert.Equal(2, moviesOnly.Length);
				Assert.Contains(moviesOnly, m => m.Title.Contains("Red Dead"));
			}
		}
	}
}