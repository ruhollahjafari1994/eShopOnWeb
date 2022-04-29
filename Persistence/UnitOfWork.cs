namespace Persistence
{
	public class UnitOfWork :
		Dtat.Ddd.EntityFrameworkCore.UnitOfWork<DatabaseContext>, IUnitOfWork
	{
		public UnitOfWork(DatabaseContext databaseContext) : base(databaseContext: databaseContext)
		{
		}

		// **********
		private Users.IUserRepository _userRepository;

		public Users.IUserRepository UserRepository
		{
			get
			{
				if (_userRepository == null)
				{
					_userRepository =
						new Users.UserRepository(databaseContext: DatabaseContext);
				}

				return _userRepository;
			}
		}
		// **********
	}
}
