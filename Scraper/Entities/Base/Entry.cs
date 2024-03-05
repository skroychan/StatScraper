namespace skroy.Scraper.Entities.Base;

public class Entry : Entity
{
    public string Title { get; set; }
    public DateTime? AddedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime LastScrapedDate { get; set; }
}
