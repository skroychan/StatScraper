using skroy.Scraper.Entities.Base;

namespace skroy.Scraper.Repository;

internal interface IEntityRepository
{
	public T Add<T>(T entity) where T : Entity, new();
	public IEnumerable<T> GetAll<T>() where T : Entity, new();
	public T Get<T>(long id) where T : Entity, new();
	public bool Update<T>(long id, Action<T> updater) where T : Entity, new();
	public bool Remove<T>(long id) where T : Entity, new();
}
