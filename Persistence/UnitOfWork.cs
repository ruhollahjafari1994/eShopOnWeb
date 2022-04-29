using RJ.EntityFrameworkCore;

namespace Persistence
{
	public class UnitOfWork :
		 UnitOfWork<DatabaseContext>, IUnitOfWork
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
