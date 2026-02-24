namespace MediaCatalogApp
{
	public class MediaItem:IComparable<MediaItem>
	{
		public string Title { get; set; }
		public MediaType Type { get; set; }
		public double Rating { get; set; }

		public MediaItem(string title, MediaType type, int rating)
		{
			Title = title;
			Type = type;
			Rating = rating;
		}
		public MediaItem(){}
		public override string ToString()
		{
			return $" Title : {Title} | Type : {Type} | Rating : {Rating}";
		}

		public int CompareTo(MediaItem other)
		{
			if(other==null) return 1;
			return this.Rating.CompareTo(other.Rating);
		}
	}
}

