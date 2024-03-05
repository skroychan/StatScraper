using skroy.Scraper.Entities.Base;

namespace skroy.Scraper.Repository;

internal class EntityRepository : IEntityRepository
{
    private DatabaseAccess Database { get; }
    private EntityCache Cache { get; }


    public EntityRepository()
    {
        Database = new DatabaseAccess();
        Cache = new EntityCache();
    }


    public T Add<T>(T entity) where T : Entity, new()
    {
        entity = Database.Insert(entity);

		Cache.Add(entity);

		return entity;
    }

    public IEnumerable<T> GetAll<T>() where T : Entity, new()
    {
		return Cache.GetAll<T>();
	}

    public T Get<T>(long id) where T : Entity, new()
    {
        return Cache.Get<T>(id);
    }

    public bool Update<T>(long id, Action<T> updater) where T : Entity, new()
    {
        var result = true;
		var entity = Get<T>(id);
		updater(entity);

		if (entity.Id != id)
			throw new ArgumentException("Updating ID of an entity is not allowed.");

        result &= Database.Update(entity);
		result &= Cache.Update(id, updater);

        return result;
    }

    public bool Remove<T>(long id) where T : Entity, new()
	{
        var result = true;

        result &= Database.Delete<T>(id);
        result &= Cache.Remove<T>(id);

		return result;
    }
}
