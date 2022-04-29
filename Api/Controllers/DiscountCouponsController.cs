using System.Linq;
using Dtat.Results;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	public class DiscountCouponsController : Utilities.ControllerBaseTemp
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="databaseContext"></param>
		public DiscountCouponsController
			(Persistence.DatabaseContext databaseContext) : base(databaseContext: databaseContext)
		{
		}

		//#region HttpGet
		///// <summary>
		///// 
		///// </summary>
		///// <returns></returns>
		//[Microsoft.AspNetCore.Mvc.HttpGet]

		//[Microsoft.AspNetCore.Mvc.ProducesResponseType
		//	(type: typeof(FluentResults.Result
		//		<System.Collections.Generic.IList
		//		<Persistence.DiscountCoupons.ViewModels.DiscountCouponViewModel>>),
		//	statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		//public
		//	async
		//	System.Threading.Tasks.Task
		//	<FluentResults.Result
		//		<System.Collections.Generic.IList
		//		<Persistence.DiscountCoupons.ViewModels.DiscountCouponViewModel>>>
		//	GetAsync()
		//{
		//	var result =
		//		new FluentResults.Result
		//		<System.Collections.Generic.IList
		//		<Persistence.DiscountCoupons.ViewModels.DiscountCouponViewModel>>();

		//	try
		//	{
		//		var value =
		//			await
		//			DatabaseContext.DiscountCoupons
		//			.Select(current => new Persistence.DiscountCoupons.ViewModels.DiscountCouponViewModel
		//			{
		//				Id = current.Id,
		//				ValidDateTo = current.ValidDateTo.Value,
		//				ValidDateFrom = current.ValidDateFrom.Value,
		//				DiscountPercent = current.DiscountPercent.Value,
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

		//	return result;
		//}
		//#endregion /HttpGet

		#region HttpGet
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[Microsoft.AspNetCore.Mvc.HttpGet]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType
			(type: typeof(Dtat.Results.Result
				<System.Collections.Generic.IList
				<ViewModels.DiscountCoupons.DiscountCouponViewModel>>),
			statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		public
			async
			System.Threading.Tasks.Task
			<Dtat.Results.Result
				<System.Collections.Generic.IList
				<ViewModels.DiscountCoupons.DiscountCouponViewModel>>>
			GetAsync()
		{
			var result =
				new FluentResults.Result
				<System.Collections.Generic.IList
				<ViewModels.DiscountCoupons.DiscountCouponViewModel>>();

			try
			{
				var value =
					await
					DatabaseContext.DiscountCoupons
					.Select(current => new ViewModels.DiscountCoupons.DiscountCouponViewModel
					{
						Id = current.Id,
						ValidDateTo = current.ValidDateTo.Value,
						ValidDateFrom = current.ValidDateFrom.Value,
						DiscountPercent = current.DiscountPercent.Value,
					})
					.ToListAsync()
					;

				result.WithValue(value: value);
			}
			catch //(System.Exception ex)
			{
				// Log Error!

				result.WithError
					(errorMessage: Resources.Messages.Errors.UnexpectedError);
			}

			return result.ConvertToDtatResult();
		}
		#endregion /HttpGet

		#region HttpGet(template: "{id}")
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[Microsoft.AspNetCore.Mvc.HttpGet(template: "{id}")]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType
			(type: typeof(Dtat.Results.Result
				<ViewModels.DiscountCoupons.DiscountCouponViewModel>),
			statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		public
			async
			System.Threading.Tasks.Task
			<Dtat.Results.Result<ViewModels.DiscountCoupons.DiscountCouponViewModel>>
			GetAsync(System.Guid id)
		{
			var result =
				new FluentResults.Result
				<ViewModels.DiscountCoupons.DiscountCouponViewModel>();

			try
			{
				var value =
					await
					DatabaseContext.DiscountCoupons
					.Where(current => current.Id == id)
					.Select(current => new ViewModels.DiscountCoupons.DiscountCouponViewModel
					{
						Id = current.Id,
						ValidDateTo = current.ValidDateTo.Value,
						ValidDateFrom = current.ValidDateFrom.Value,
						DiscountPercent = current.DiscountPercent.Value,
					})
					.FirstOrDefaultAsync();

				if (value is null)
				{
					string errorMessage = string.Format
						(Resources.Messages.Validations.NotFound, Resources.DataDictionary.DiscountCoupon);

					result.WithError(errorMessage: errorMessage);

					return result.ConvertToDtatResult();
				}

				result.WithValue(value: value);
			}
			catch //(System.Exception ex)
			{
				// Log Error!

				result.WithError
					(errorMessage: Resources.Messages.Errors.UnexpectedError);
			}

			return result.ConvertToDtatResult();
		}
		#endregion /HttpGet(template: "{id}")

		#region HttpPost
		/// <summary>
		/// Create
		/// </summary>
		/// <param name="viewModel"></param>
		/// <returns></returns>
		[Microsoft.AspNetCore.Mvc.HttpPost]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType
			(type: typeof(Dtat.Results.Result
				<ViewModels.DiscountCoupons.DiscountCouponViewModel>),
			statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		public
			async
			System.Threading.Tasks.Task
			<Dtat.Results.Result<ViewModels.DiscountCoupons.DiscountCouponViewModel>>
			PostAsync
			([Microsoft.AspNetCore.Mvc.FromBody]
			ViewModels.DiscountCoupons.DiscountCouponRequestViewModel viewModel)
		{
			var result =
				new FluentResults.Result
				<ViewModels.DiscountCoupons.DiscountCouponViewModel>();

			try
			{
				// **************************************************
				var discountCouponResult =
					Domain.Aggregates.DiscountCoupons.DiscountCoupon.Create
					(validDateTo: viewModel.ValidDateTo,
					validDateFrom: viewModel.ValidDateFrom,
					discountPercent: viewModel.DiscountPercent);

				if (discountCouponResult.IsFailed)
				{
					result.WithErrors(errors: discountCouponResult.Errors);

					return result.ConvertToDtatResult();
				}
				// **************************************************

				// **************************************************
				DatabaseContext.Attach(discountCouponResult.Value);

				await DatabaseContext.SaveChangesAsync();
				// **************************************************

				// **************************************************
				var value =
					new ViewModels.DiscountCoupons.DiscountCouponViewModel
					{
						Id = discountCouponResult.Value.Id,
						ValidDateTo = discountCouponResult.Value.ValidDateTo.Value,
						ValidDateFrom = discountCouponResult.Value.ValidDateFrom.Value,
						DiscountPercent = discountCouponResult.Value.DiscountPercent.Value,
					};

				result.WithValue(value: value);
				// **************************************************

				// **************************************************
				string successMessage = string.Format
					(Resources.Messages.Successes.SuccessCreate, Resources.DataDictionary.DiscountCoupon);

				result.WithSuccess(successMessage: successMessage);
				// **************************************************
			}
			catch //(System.Exception ex)
			{
				// Log Error!

				result.WithError
					(errorMessage: Resources.Messages.Errors.UnexpectedError);
			}

			return result.ConvertToDtatResult();
		}
		#endregion /HttpPost

		#region PutAsync
		/// <summary>
		/// 
		/// </summary>
		/// <param name="viewModel"></param>
		/// <returns></returns>
		[Microsoft.AspNetCore.Mvc.HttpPut]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType
			(type: typeof(Dtat.Results.Result
				<ViewModels.DiscountCoupons.DiscountCouponViewModel>),
			statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		public
			async
			System.Threading.Tasks.Task
			<Dtat.Results.Result<ViewModels.DiscountCoupons.DiscountCouponViewModel>>
			PutAsync
			([Microsoft.AspNetCore.Mvc.FromBody]
			ViewModels.DiscountCoupons.DiscountCouponViewModel viewModel)
		{
			var result =
				new FluentResults.Result
				<ViewModels.DiscountCoupons.DiscountCouponViewModel>();

			try
			{
				if (viewModel.Id is null)
				{
					string errorMessage = string.Format
						(Resources.Messages.Validations.Required, Resources.DataDictionary.Id);

					result.WithError(errorMessage: errorMessage);

					return result.ConvertToDtatResult();
				}

				var foundedObject =
					await
					DatabaseContext.DiscountCoupons
					.Where(current => current.Id == viewModel.Id.Value)
					.FirstOrDefaultAsync();

				if (foundedObject == null)
				{
					string errorMessage = string.Format
						(Resources.Messages.Validations.NotFound, Resources.DataDictionary.DiscountCoupon);

					result.WithError(errorMessage: errorMessage);

					return result.ConvertToDtatResult();
				}

				var discountCouponResult =
					foundedObject.Update
					(validDateTo: viewModel.ValidDateTo,
					validDateFrom: viewModel.ValidDateFrom,
					discountPercent: viewModel.DiscountPercent);

				if (discountCouponResult.IsFailed)
				{
					result.WithErrors(errors: discountCouponResult.Errors);

					return result.ConvertToDtatResult();
				}

				await DatabaseContext.SaveChangesAsync();

				// **************************************************
				string successMessage = string.Format
					(Resources.Messages.Successes.SuccessUpdate, Resources.DataDictionary.DiscountCoupon);

				result.WithSuccess(successMessage: successMessage);
				// **************************************************
			}
			catch //(System.Exception ex)
			{
				// Log Error!

				result.WithError
					(errorMessage: Resources.Messages.Errors.UnexpectedError);
			}

			return result.ConvertToDtatResult();
		}
		#endregion /PutAsync

		#region HttpDelete(template: "{id}")
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Microsoft.AspNetCore.Mvc.HttpDelete(template: "{id}")]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType
			(type: typeof(Dtat.Results.Result),
			statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		public
			async
			System.Threading.Tasks.Task<Dtat.Results.Result>
			DeleteAsync(System.Guid id)
		{
			var result =
				new FluentResults.Result();

			try
			{
				var foundedObject =
					await
					DatabaseContext.DiscountCoupons
					.Where(current => current.Id == id)
					.FirstOrDefaultAsync();

				if (foundedObject is null)
				{
					string errorMessage = string.Format
						(Resources.Messages.Validations.NotFound, Resources.DataDictionary.DiscountCoupon);

					result.WithError(errorMessage: errorMessage);

					return result.ConvertToDtatResult();
				}

				DatabaseContext.Remove(foundedObject);

				await DatabaseContext.SaveChangesAsync();

				// **************************************************
				string successMessage = string.Format
					(Resources.Messages.Successes.SuccessDelete, Resources.DataDictionary.DiscountCoupon);

				result.WithSuccess(successMessage: successMessage);
				// **************************************************
			}
			catch (Microsoft.Data.SqlClient.SqlException)
			{
				string errorMessage = string.Format
					(Resources.Messages.Errors.CanNotDelete, Resources.DataDictionary.DiscountCoupon);

				result.WithError
					(errorMessage: errorMessage);
			}
			catch //(System.Exception ex)
			{
				// Log Error!

				string errorMessage =
					Resources.Messages.Errors.UnexpectedError;

				result.WithError
					(errorMessage: errorMessage);
			}

			return result.ConvertToDtatResult();
		}
		#endregion /HttpDelete(template: "{id}")
	}
}

/*

Create:

{}

{
	"discountPercent": null,
	"validDateFrom": null,
	"validDateTo": null
}

{
	"discountPercent": "abc",
	"validDateFrom": null,
	"validDateTo": null
}

{
	"discountPercent": 150,
	"validDateFrom": null,
	"validDateTo": null
}

{
	"discountPercent": 50,
	"validDateFrom": "2021-06-02",
	"validDateTo": "2021-06-01"
}

{
	"discountPercent": 50,
	"validDateFrom": "2022-06-02",
	"validDateTo": "2022-06-01"
}

{
	"discountPercent": 50,
	"validDateFrom": "2022-06-01",
	"validDateTo": "2022-06-01"
}

*/

/*

Update:

{}

{
	"id" : null,
	"discountPercent": null,
	"validDateFrom": null,
	"validDateTo": null
}

{
	"id" : "065102ab-a845-41de-a45c-08d92d961aaa",
	"discountPercent": null,
	"validDateFrom": null,
	"validDateTo": null
}

{
	"id" : "065102ab-a845-41de-a45c-08d92d961e13",
	"discountPercent": null,
	"validDateFrom": null,
	"validDateTo": null
}

{
	"id" : "065102ab-a845-41de-a45c-08d92d961e13",
	"discountPercent": "abc",
	"validDateFrom": null,
	"validDateTo": null
}

{
	"id" : "065102ab-a845-41de-a45c-08d92d961e13",
	"discountPercent": 123,
	"validDateFrom": null,
	"validDateTo": null
}

{
	"id" : "065102ab-a845-41de-a45c-08d92d961e13",
	"discountPercent": 50,
	"validDateFrom": "2021-06-02",
	"validDateTo": "2021-06-01"
}

{
	"id" : "065102ab-a845-41de-a45c-08d92d961e13",
	"discountPercent": 50,
	"validDateFrom": "2022-06-02",
	"validDateTo": "2022-06-01"
}

{
	"id" : "065102ab-a845-41de-a45c-08d92d961e13",
	"discountPercent": 50,
	"validDateFrom": "2022-06-01",
	"validDateTo": "2022-06-01"
}

*/
