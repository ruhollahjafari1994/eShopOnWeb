using System.Linq;
using Dtat.Results;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	public class ProvincesController : Utilities.ControllerBaseTemp
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="databaseContext"></param>
		public ProvincesController
			(Persistence.DatabaseContext databaseContext) : base(databaseContext: databaseContext)
		{
		}

		#region PostAsync
		/// <summary>
		/// Create
		/// </summary>
		/// <param name="viewModel"></param>
		/// <returns></returns>
		[Microsoft.AspNetCore.Mvc.HttpPost]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType
			(type: typeof(Dtat.Results.Result
				<ViewModels.Provinces.ProvinceViewModel>),
			statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		public
			async
			System.Threading.Tasks.Task
			<Dtat.Results.Result<ViewModels.Provinces.ProvinceViewModel>>
			PostAsync
			([Microsoft.AspNetCore.Mvc.FromBody]
			ViewModels.Provinces.ProvinceRequestViewModel viewModel)
		{
			var result =
				new FluentResults.Result
				<ViewModels.Provinces.ProvinceViewModel>();

			try
			{
				// **************************************************
				var provinceResult =
					Domain.Aggregates.Provinces.Province.Create(name: viewModel.Name);

				if (provinceResult.IsFailed)
				{
					result.WithErrors(errors: provinceResult.Errors);

					return result.ConvertToDtatResult();
				}
				// **************************************************

				// **************************************************
				// نکته مهم: دستور ذیل کار نمی‌کند
				//bool hasAny =
				//	DatabaseContext
				//	.Provinces
				//	.Where(current => current.Name.Value.ToLower()
				//		== provinceResult.Value.Name.Value.ToLower())
				//	.Any();

				bool hasAny =
					DatabaseContext
					.Provinces
					.Where(current => current.Name == provinceResult.Value.Name)
					.Any();

				if (hasAny)
				{
					string errorMessage = string.Format
						(Resources.Messages.Validations.Repetitive,
						Resources.DataDictionary.ProvinceName);

					result.WithError(errorMessage: errorMessage);

					return result.ConvertToDtatResult();
				}
				// **************************************************

				// **************************************************
				// دستور ذیل کار نمی‌کند DDD با نگاه
				//DatabaseContext.Provinces.Add(provinceResult.Value);

				var entity =
					DatabaseContext.Attach(provinceResult.Value);

				entity.State =
					Microsoft.EntityFrameworkCore.EntityState.Added;

				await DatabaseContext.SaveChangesAsync();
				// **************************************************

				// **************************************************
				var value =
					new ViewModels.Provinces.ProvinceViewModel
					{
						Id = provinceResult.Value.Id,
						Name = provinceResult.Value.Name.Value,
					};

				result.WithValue(value: value);
				// **************************************************

				// **************************************************
				string successMessage = string.Format
					(Resources.Messages.Successes.SuccessCreate,
					Resources.DataDictionary.Province);

				result.WithSuccess(successMessage: successMessage);
				// **************************************************
			}
			catch //System.Exception ex)
			{
				// Log Error!

				result.WithError
					(errorMessage: Resources.Messages.Errors.UnexpectedError);
			}

			return result.ConvertToDtatResult();
		}
		#endregion /PostAsync

		#region GetAsync
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[Microsoft.AspNetCore.Mvc.HttpGet]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType
			(type: typeof(Dtat.Results.Result
				<System.Collections.Generic.IList
				<ViewModels.Provinces.ProvinceViewModel>>),
			statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		public
			async
			System.Threading.Tasks.Task
			<Dtat.Results.Result
				<System.Collections.Generic.IList
				<ViewModels.Provinces.ProvinceViewModel>>>
			GetAsync()
		{
			var result =
				new FluentResults.Result
				<System.Collections.Generic.IList
				<ViewModels.Provinces.ProvinceViewModel>>();

			try
			{
				var value =
					await
					DatabaseContext.Provinces
					.Select(current => new ViewModels.Provinces.ProvinceViewModel
					{
						Id = current.Id,
						Name = current.Name.Value,
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
		#endregion /GetAsync

		#region GetByIdAsync
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[Microsoft.AspNetCore.Mvc.HttpGet(template: "{id}")]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType
			(type: typeof(Dtat.Results.Result
				<ViewModels.Provinces.ProvinceViewModel>),
			statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		public
			async
			System.Threading.Tasks.Task
			<Dtat.Results.Result<ViewModels.Provinces.ProvinceViewModel>>
			GetByIdAsync([Microsoft.AspNetCore.Mvc.FromRoute] System.Guid id)
		{
			var result =
				new FluentResults.Result
				<ViewModels.Provinces.ProvinceViewModel>();

			try
			{
				var value =
					await
					DatabaseContext.Provinces
					.Where(current => current.Id == id)
					.Select(current => new ViewModels.Provinces.ProvinceViewModel
					{
						Id = current.Id,
						Name = current.Name.Value,
					})
					.FirstOrDefaultAsync();

				if (value is null)
				{
					string errorMessage = string.Format
						(Resources.Messages.Validations.NotFound,
						Resources.DataDictionary.Province);

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
		#endregion /GetByIdAsync

		#region PutAsync
		/// <summary>
		/// 
		/// </summary>
		/// <param name="viewModel"></param>
		/// <returns></returns>
		[Microsoft.AspNetCore.Mvc.HttpPut]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType
			(type: typeof(Dtat.Results.Result
				<ViewModels.Provinces.ProvinceViewModel>),
			statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		public
			async
			System.Threading.Tasks.Task
			<Dtat.Results.Result<ViewModels.Provinces.ProvinceViewModel>>
			PutAsync
			([Microsoft.AspNetCore.Mvc.FromBody]
			ViewModels.Provinces.ProvinceViewModel viewModel)
		{
			var result =
				new FluentResults.Result
				<ViewModels.Provinces.ProvinceViewModel>();

			try
			{
				// **************************************************
				if (viewModel.Id is null)
				{
					string errorMessage = string.Format
						(Resources.Messages.Validations.Required,
						Resources.DataDictionary.Id);

					result.WithError(errorMessage: errorMessage);

					return result.ConvertToDtatResult();
				}
				// **************************************************

				// **************************************************
				var foundedObject =
					await
					DatabaseContext.Provinces
					.Where(current => current.Id == viewModel.Id.Value)
					.FirstOrDefaultAsync();

				if (foundedObject == null)
				{
					string errorMessage = string.Format
						(Resources.Messages.Validations.NotFound,
						Resources.DataDictionary.Province);

					result.WithError(errorMessage: errorMessage);

					return result.ConvertToDtatResult();
				}
				// **************************************************

				// **************************************************
				var provinceResult =
					foundedObject.Update(name: viewModel.Name);

				if (provinceResult.IsFailed)
				{
					result.WithErrors(errors: provinceResult.Errors);

					return result.ConvertToDtatResult();
				}
				// **************************************************

				// **************************************************
				// نکته مهم: دستور ذیل کار نمی‌کند
				//bool hasAny =
				//	DatabaseContext
				//	.Provinces
				//	.Where(current => current.Id != foundedObject.Id)
				//	.Where(current => current.Name == foundedObject.Name)
				//	.Any();

				bool hasAny =
					DatabaseContext
					.Provinces
					.Where(current => current.Id != foundedObject.Id)
					.Where(current => current.Name == foundedObject.Name)
					.Any();

				if (hasAny)
				{
					string errorMessage = string.Format
						(Resources.Messages.Validations.Repetitive,
						Resources.DataDictionary.ProvinceName);

					result.WithError(errorMessage: errorMessage);

					return result.ConvertToDtatResult();
				}
				// **************************************************

				// **************************************************
				//var entity =
				//	DatabaseContext.Attach(foundedObject);

				//entity.State =
				//	Microsoft.EntityFrameworkCore.EntityState.Modified;

				await DatabaseContext.SaveChangesAsync();
				// **************************************************

				// **************************************************
				var value =
					new ViewModels.Provinces.ProvinceViewModel
					{
						Id = foundedObject.Id,
						Name = foundedObject.Name.Value,
					};

				result.WithValue(value: value);
				// **************************************************

				// **************************************************
				string successMessage = string.Format
					(Resources.Messages.Successes.SuccessUpdate,
					Resources.DataDictionary.Province);

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

		#region DeleteByIdAsync
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
			DeleteByIdAsync([Microsoft.AspNetCore.Mvc.FromRoute] System.Guid id)
		{
			var result =
				new FluentResults.Result();

			try
			{
				var foundedObject =
					await
					DatabaseContext.Provinces
					.Where(current => current.Id == id)
					.FirstOrDefaultAsync();

				if (foundedObject is null)
				{
					string errorMessage = string.Format
						(Resources.Messages.Validations.NotFound, Resources.DataDictionary.Province);

					result.WithError(errorMessage: errorMessage);

					return result.ConvertToDtatResult();
				}

				DatabaseContext.Remove(foundedObject);

				//DatabaseContext.Provinces.Remove(foundedObject);

				await DatabaseContext.SaveChangesAsync();

				// **************************************************
				string successMessage = string.Format
					(Resources.Messages.Successes.SuccessDelete, Resources.DataDictionary.Province);

				result.WithSuccess(successMessage: successMessage);
				// **************************************************
			}
			catch (Microsoft.Data.SqlClient.SqlException)
			{
				string errorMessage = string.Format
					(Resources.Messages.Errors.CanNotDelete, Resources.DataDictionary.Province);

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
		#endregion /DeleteByIdAsync
	}
}

/*

**********
Create
**********

{}

{
	"name": null
}

{
	"name": ""
}

{
	"name": "     "
}

{
	"name": "استان تهران"
}

{
	"name": "   استان تهران   "
}

{
	"name": "   استان   تهران   "
}

**********
Update
**********

{}

{
	"id" : null
}

{
	"id" : "03782b1e-e4f1-436d-e429-08d9445571eb",
	"name": null
}

{
	"id" : "03782b1e-e4f1-436d-e429-08d9445571eb",
	"name": ""
}

{
	"id" : "03782b1e-e4f1-436d-e429-08d9445571eb",
	"name": "     "
}

{
	"id" : "03782b1e-e4f1-436d-e429-08d9445571eb",
	"name": "استان البرز"
}

{
	"id" : "03782b1e-e4f1-436d-e429-08d9445571eb",
	"name": "   استان البرز   "
}

{
	"id" : "03782b1e-e4f1-436d-e429-08d9445571eb",
	"name": "   استان   البرز   "
}

*/
