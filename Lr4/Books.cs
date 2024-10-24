public class Books
{
    public static string BooksOut(IConfigurationSection configurationSection)
    {
        return string.Join(", ", configurationSection.Get<List<string>>());
    }
}