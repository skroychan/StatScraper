using skroy.Scraper.Entities.Base;
using System.Collections;

namespace skroy.Scraper.Repository;

internal class EntityCache : IEntityRepository
{
	private Dictionary<Type, IDictionary> Cache { get; }
	private DatabaseAccess Database { get; }


    public EntityCache()
	{
		Cache = [];
		Database = new DatabaseAccess();
    }


	public T Add<T>(T entity) where T : Entity, new()
	{
		var cache = GetCache<T>();

		if (cache.ContainsKey(entity.Id))
			throw new ArgumentException($"Entity of type [{typeof(T)}] with ID=[{entity.Id}] already exists.");

		cache[entity.Id] = entity;

		return entity;
	}

	public IEnumerable<T> GetAll<T>() where T : Entity, new()
	{
		var cache = GetCache<T>();

		return cache.Values;
	}

	public T Get<T>(long id) where T : Entity, new()
	{
		var cache = GetCache<T>();

		if (!cache.TryGetValue(id, out var entity))
			throw new ArgumentException($"Cannot find entity of type [{typeof(T)}] with ID=[{entity.Id}].");

		return entity;
	}

	public bool Update<T>(long id, Action<T> updater) where T : Entity, new()
	{
		var cache = GetCache<T>();

		if (!cache.TryGetValue(id, out var entity))
			throw new ArgumentException($"Cannot find entity of type [{typeof(T)}] with ID=[{id}].");

		updater(entity);
		cache[id] = entity;

		return true;
	}

	public bool Remove<T>(long id) where T : Entity, new()
	{
		var cache = GetCache<T>();

		if (!cache.ContainsKey(id))
			throw new ArgumentException($"Cannot find entity of type [{typeof(T)}] with ID=[{id}].");

		return cache.Remove(id);
	}


	private Dictionary<long, T> GetCache<T>() where T : Entity, new()
	{
		if (!Cache.TryGetValue(typeof(T), out var cache))
			cache = Cache[typeof(T)] = Database.Select<T>().ToDictionary(x => x.Id, x => x);

		return (Dictionary<long, T>)cache;
	}
}
