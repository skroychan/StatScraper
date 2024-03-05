using skroy.ORM;
using skroy.Scraper.Entities;
using skroy.Scraper.Entities.Base;

namespace skroy.Scraper.Repository;

internal class DatabaseAccess
{
	private Database Database { get; }


	public DatabaseAccess()
    {
		Database = Database.GetMySqlDatabase(AppConfig.ConnectionString);

		var steamEntryMappingBuilder = Database.GetMappingBuilder<SteamEntry>()
			.AddIndex(false, x => x.Title);

		Database.AddMapping(steamEntryMappingBuilder);

		Database.Initialize();
	}


	public T Insert<T>(T entity) where T : Entity, new()
	{
		entity.Id = (long)Database.Insert(entity);

		return entity;
	}

	public IEnumerable<T> Select<T>() where T : Entity, new()
	{
		return Database.Select<T>();
	}

	public T Select<T>(T entity) where T : Entity, new()
	{
		return Database.Select(entity);
	}

	public bool Update<T>(T entity) where T : Entity, new()
	{
		return Database.Update(entity) == 1;
	}

	public bool Delete<T>(long id) where T : Entity, new()
	{
		return Database.Delete<T>(x => x.Id == id) == 1;
	}
}
