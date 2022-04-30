using System.Linq;
using Dtat.Results;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	public class UsersController : Utilities.ControllerBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="unitOfWork"></param>
		public UsersController
			(Dtat.Logging.ILogger<UsersController> logger,
			Persistence.IUnitOfWork unitOfWork) : base(unitOfWork: unitOfWork)
		{
			Logger = logger;
		}

		/// <summary>
		/// 
		/// </summary>
		private Dtat.Logging.ILogger<UsersController> Logger { get; }

		#region HttpPost
		/// <summary>
		/// Create
		/// </summary>
		/// <param name="viewModel"></param>
		/// <returns></returns>
		[Microsoft.AspNetCore.Mvc.HttpPost]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType
			(type: typeof(Dtat.Results.Result
				<ViewModels.Users.UserViewModel>),
			statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		public
			async
			System.Threading.Tasks.Task
			<Dtat.Results.Result<ViewModels.Users.UserViewModel>>
			PostAsync
			([Microsoft.AspNetCore.Mvc.FromBody]
			ViewModels.Users.CreateRequestViewModel viewModel)
		{
			var result =
				new FluentResults.Result
				<ViewModels.Users.UserViewModel>();

			try
			{
				// **************************************************
				var userResult =
					Domain.Aggregates.Users.User.Create
					(username: viewModel.Username,
					password: viewModel.Password,
					emailAddress: viewModel.EmailAddress,
					cellPhoneNumber: viewModel.CellPhoneNumber,
					role: viewModel.Role,
					gender: viewModel.Gender,
					firstName: viewModel.FirstName,
					lastName: viewModel.LastName);

				if (userResult.IsFailed)
				{
					result.WithErrors(errors: userResult.Errors);

					return result.ConvertToDtatResult();
				}
				// **************************************************

				// **************************************************
				await UnitOfWork.UserRepository.AddAsync(entity: userResult.Value);

				await UnitOfWork.SaveAsync();
				// **************************************************

				// **************************************************
				var value =
					new ViewModels.Users.UserViewModel
					{
						Id = userResult.Value.Id,
						Username = userResult.Value.Username.Value,
						Password = userResult.Value.Password.Value,
						EmailAddress = userResult.Value.EmailAddress.Value,
						EmailAddressIsVerified = userResult.Value.EmailAddress.IsVerified,
						EmailAddressVerificationKey = userResult.Value.EmailAddress.VerificationKey,
						Role = userResult.Value.Role.Value,
						Gender = userResult.Value.FullName.Gender.Value,
						FirstName = userResult.Value.FullName.FirstName.Value,
						LastName = userResult.Value.FullName.LastName.Value,
					};
				
				result.WithValue(value: value);
				// **************************************************

				// **************************************************
				string successMessage = string.Format
					(Resources.Messages.Successes.SuccessCreate, Resources.DataDictionary.User);

				result.WithSuccess(successMessage: successMessage);
				// **************************************************
			}
			catch (System.Exception ex)
			{
				Logger.LogError(exception: ex);

				result.WithError
					(errorMessage: Resources.Messages.Errors.UnexpectedError);
			}

			return result.ConvertToDtatResult();
		}
		#endregion /HttpPost

		//#region GetAsync
		///// <summary>
		///// 
		///// </summary>
		///// <returns></returns>
		//[Microsoft.AspNetCore.Mvc.HttpGet]

		//[Microsoft.AspNetCore.Mvc.ProducesResponseType
		//	(type: typeof(Dtat.Results.Result
		//		<System.Collections.Generic.IList
		//		<ViewModels.Users.UserViewModel>>),
		//	statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		//public
		//	async
		//	System.Threading.Tasks.Task
		//	<Dtat.Results.Result
		//		<System.Collections.Generic.IList
		//		<ViewModels.Users.UserViewModel>>>
		//	GetAsync()
		//{
		//	var result =
		//		new FluentResults.Result
		//		<System.Collections.Generic.IList
		//		<ViewModels.Users.UserViewModel>>();

		//	try
		//	{
		//		var value =
		//			await
		//			DatabaseContext.Users
		//			.Select(current => new ViewModels.Users.UserViewModel
		//			{
		//				Id = current.Id,
		//				Role = current.Role.Value,
		//				Username = current.Username.Value,
		//				Password = current.Password.Value,
		//				//Gender = current.FullName.Gender.Value,
		//				//EmailAddress = current.EmailAddress.Value,
		//				//LastName = current.FullName.LastName.Value,
		//				//FirstName = current.FullName.FirstName.Value,
		//				//EmailAddressIsVerified = current.EmailAddress.IsVerified,
		//				//EmailAddressVerificationKey = current.EmailAddress.VerificationKey,
		//			})
		//			.ToListAsync()
		//			;

		//		result.WithValue(value: value);
		//	}
		//	catch //(System.Exception ex)
		//	{
		//		// Log Error!

		//		result.WithError
		//			(errorMessage: Resources.Messages.Errors.UnexpectedError);
		//	}

		//	return result.ConvertToDtatResult();
		//}
		//#endregion /GetAsync

		//#region HttpPost
		///// <summary>
		///// 
		///// </summary>
		///// <param name="viewModel"></param>
		///// <returns></returns>
		//[Microsoft.AspNetCore.Mvc.HttpPost(template: "ChangePassword")]

		//[Microsoft.AspNetCore.Mvc.ProducesResponseType
		//	(type: typeof(Dtat.Results.Result),
		//	statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		//public
		//	async
		//	System.Threading.Tasks.Task
		//	<Dtat.Results.Result>
		//	ChangePasswordAsync
		//	([Microsoft.AspNetCore.Mvc.FromBody]
		//	ViewModels.Users.ChangePasswordRequestViewModel viewModel)
		//{
		//	var result =
		//		new FluentResults.Result();

		//	try
		//	{
		//		// **************************************************
		//		if (viewModel.Id is null)
		//		{
		//			string errorMessage = string.Format
		//				(Resources.Messages.Validations.Required,
		//				Resources.DataDictionary.Id);

		//			result.WithError(errorMessage: errorMessage);

		//			return result.ConvertToDtatResult();
		//		}
		//		// **************************************************

		//		// **************************************************
		//		var foundedObject =
		//			await
		//			DatabaseContext.Users
		//			.Where(current => current.Id == viewModel.Id.Value)
		//			.FirstOrDefaultAsync();

		//		if (foundedObject == null)
		//		{
		//			string errorMessage = string.Format
		//				(Resources.Messages.Validations.NotFound,
		//				Resources.DataDictionary.User);

		//			result.WithError(errorMessage: errorMessage);

		//			return result.ConvertToDtatResult();
		//		}
		//		// **************************************************

		//		// **************************************************
		//		var userResult =
		//			foundedObject.ChangePassword(newPassword: viewModel.NewPassword);

		//		if (userResult.IsFailed)
		//		{
		//			result.WithErrors(errors: userResult.Errors);

		//			return result.ConvertToDtatResult();
		//		}
		//		// **************************************************

		//		await DatabaseContext.SaveChangesAsync();

		//		// **************************************************
		//		string successMessage = string.Format
		//			(Resources.Messages.Successes.SuccessUserPasswordChanged);

		//		result.WithSuccess(successMessage: successMessage);
		//		// **************************************************
		//	}
		//	catch //(System.Exception ex)
		//	{
		//		// Log Error!

		//		result.WithError
		//			(errorMessage: Resources.Messages.Errors.UnexpectedError);
		//	}

		//	return result.ConvertToDtatResult();
		//}
		//#endregion /HttpPost
	}
}

/*
{
  "role": null,
  "gender": null,
  "username": null,
  "password": null,
  "lastName": null,
  "firstName": null,
  "emailAddress": null
}

{
  "role": 10,
  "gender": 20,
  "username": "1234567890",
  "password": "1234567890",
  "lastName": "     ",
  "firstName": "     ",
  "emailAddress": "     "
}

{
  "role": 1,
  "gender": 0,
  "username": "DariushT",
  "password": "1234567890",
  "lastName": "Dariush",
  "firstName": "Tasdighi",
  "emailAddress": "DariushT@GMail.com"
}

{
  "role": 1,
  "gender": 1,
  "username": "  AliRezaAlavi  ",
  "password": "  1234567890  ",
  "lastName": "  Ali   Reza  ",
  "firstName": "  Alavi   Asl  ",
  "cellPhoneNumber": "  09121087461  ",
  "emailAddress": "  DariushT@GMail.com  "
}
*/
