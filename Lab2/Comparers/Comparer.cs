using MediaCatalogApp;

class Comparer:IComparer<MediaItem>
{
    public int Compare(MediaItem x, MediaItem y)
    {
        return x.Title.CompareTo(y.Title);
    }
}