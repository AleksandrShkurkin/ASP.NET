class ProfileService
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

    public string GetProfile(int? id, IConfigurationSection configurationSection)
    {
        var profiles = configurationSection.Get<List<ProfileService>>();

        if(id != null)
        {
            return profiles[id.Value].Output();
        }
        return $"Your id: default\nYour username: User1\nYour email: test@gmail.com";
    }

    public string Output()
    {
        return $"Your id: {Id}\nYour username: {Username}\nYour email: {Email}";
    }
}