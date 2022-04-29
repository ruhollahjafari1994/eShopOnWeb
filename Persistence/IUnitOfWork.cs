namespace Persistence
{
	public interface IUnitOfWork : Dtat.Ddd.IUnitOfWork
	{
		Users.IUserRepository UserRepository { get; }
	}
}
