using System.Collections;
using MediaCatalogApp;
public class Enumerator : IEnumerator
{
    public MediaCatalog mediaCatalog { get; set; }
    public int position = -1;
    public Enumerator(MediaCatalog catalog)
    {
        mediaCatalog = catalog;
    }
    public object Current
    {
        get
        {
            return mediaCatalog.GetAt(position);
        }
    }
    public bool MoveNext()
    {
        position++;
        if (position < mediaCatalog.Count)
        {
            return true;
        }
        return false;
    }
    public void Reset()
    {
        position = -1;
    }
}
            