namespace URLShortnerREST.Models
{
    public interface IUrlLibary
    {
        string StoreURL(string url);
        string GetURL(string shortenedKey);
    }
}
