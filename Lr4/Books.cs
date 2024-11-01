public class BooksService
{
    public string BooksOut(IConfigurationSection configurationSection)
    {
        return string.Join(", ", configurationSection.Get<List<string>>());
    }
}