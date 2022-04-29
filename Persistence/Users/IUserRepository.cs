namespace Persistence.Users
{
	public interface IUserRepository : Dtat.Ddd.IRepository<Domain.Aggregates.Users.User>
	{
		System.Threading.Tasks.Task<ViewModels.Users.UserViewModel> GetByUsernameAsync
			(Domain.Aggregates.Users.ValueObjects.Username username,
			System.Threading.CancellationToken cancellationToken);

		System.Threading.Tasks.Task<ViewModels.Users.UserViewModel> GetByEmailAddressAsync
			(Domain.SharedKernel.EmailAddress emailAddress,
			System.Threading.CancellationToken cancellationToken);

		//System.Threading.Tasks.Task<ViewModels.Users.UserViewModel> GetByCellPhoneNumberAsync
		//	(Domain.SharedKernel.CellPhoneNumber cellPhoneNumber,
		//	System.Threading.CancellationToken cancellationToken);
	}
}
