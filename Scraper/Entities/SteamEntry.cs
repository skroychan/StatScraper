namespace Scraper.Entities;

public class SteamEntry : EntryWithRating
{
    public string ImageHash { get; set; }
	public long Playtime { get; set; }
    public long? Achievements { get; set; }
    public long? TotalAchievements { get; set; }
}
