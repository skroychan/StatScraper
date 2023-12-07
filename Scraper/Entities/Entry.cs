namespace Scraper.Entities;

public class Entry
{
	public long Id { get; set; }
	public string Title { get; set; }
	public DateTime? AddedDate { get; set; }
	public DateTime? UpdatedDate { get; set; }
	public DateTime LastScrapedDate { get; set; }
}
