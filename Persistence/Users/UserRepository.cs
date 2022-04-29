using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Users
{
	public class UserRepository :
		Dtat.Ddd.EntityFrameworkCore.Repository<Domain.Aggregates.Users.User>, IUserRepository
	{
		public UserRepository(DatabaseContext databaseContext) : base(databaseContext: databaseContext)
		{
		}

		public
			async
			System.Threading.Tasks.Task<ViewModels.Users.UserViewModel>
			GetByUsernameAsync(Domain.Aggregates.Users.ValueObjects.Username username,
			System.Threading.CancellationToken cancellationToken)
		{
			var result =
				await
				DbSet
				.Where(current => current.Username == username)
				.Select(current => new ViewModels.Users.UserViewModel
				{
					Id = current.Id,
					Role = current.Role.Value,
					Username = current.Username.Value,
					Password = current.Password.Value,
					Gender = current.FullName.Gender.Value,
					EmailAddress = current.EmailAddress.Value,
					LastName = current.FullName.LastName.Value,
					FirstName = current.FullName.FirstName.Value,
					EmailAddressIsVerified = current.EmailAddress.IsVerified,
					EmailAddressVerificationKey = current.EmailAddress.VerificationKey,
				})
				.FirstOrDefaultAsync(cancellationToken: cancellationToken);

			return result;
		}

		//public
		//	async
		//	System.Threading.Tasks.Task<ViewModels.Users.UserViewModel>
		//	GetByCellPhoneNumberAsync(Domain.SharedKernel.CellPhoneNumber cellPhoneNumber,
		//	System.Threading.CancellationToken cancellationToken)
		//{
		//	var result =
		//		await
		//		DbSet
		//		.Where(current => current.CellPhoneNumber == cellPhoneNumber)
		//		.Select(current => new ViewModels.Users.UserViewModel
		//		{
		//			Id = current.Id,
		//			Role = current.Role.Value,
		//			Username = current.Username.Value,
		//			Password = current.Password.Value,
		//			Gender = current.FullName.Gender.Value,
		//			EmailAddress = current.EmailAddress.Value,
		//			LastName = current.FullName.LastName.Value,
		//			FirstName = current.FullName.FirstName.Value,
		//			EmailAddressIsVerified = current.EmailAddress.IsVerified,
		//			EmailAddressVerificationKey = current.EmailAddress.VerificationKey,
		//		})
		//		.FirstOrDefaultAsync(cancellationToken: cancellationToken);

		//	return result;
		//}

		public
			async
			System.Threading.Tasks.Task<ViewModels.Users.UserViewModel>
			GetByEmailAddressAsync(Domain.SharedKernel.EmailAddress emailAddress,
			System.Threading.CancellationToken cancellationToken)
		{
			var result =
				await
				DbSet
				.Where(current => current.EmailAddress == emailAddress)
				.Select(current => new ViewModels.Users.UserViewModel
				{
					Id = current.Id,
					Role = current.Role.Value,
					Username = current.Username.Value,
					Password = current.Password.Value,
					Gender = current.FullName.Gender.Value,
					EmailAddress = current.EmailAddress.Value,
					LastName = current.FullName.LastName.Value,
					FirstName = current.FullName.FirstName.Value,
					EmailAddressIsVerified = current.EmailAddress.IsVerified,
					EmailAddressVerificationKey = current.EmailAddress.VerificationKey,
				})
				.FirstOrDefaultAsync(cancellationToken: cancellationToken);

			return result;
		}
	}
}
