using Microsoft.AspNetCore.Http;

namespace Utilities.Middlewares
{
	/// <summary>
	/// 
	/// </summary>
	public class ExceptionHandlingMiddleware : object
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="next"></param>
		public ExceptionHandlingMiddleware
			(Microsoft.AspNetCore.Http.RequestDelegate next) : base()
		{
			Next = next;
		}

		/// <summary>
		/// 
		/// </summary>
		protected Microsoft.AspNetCore.Http.RequestDelegate Next { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="httpContext"></param>
		/// <returns></returns>
		public async System.Threading.Tasks.Task InvokeAsync
			(Microsoft.AspNetCore.Http.HttpContext httpContext)
		{
			try
			{
				await Next(httpContext);
			}
			catch (System.Exception ex)
			{
				await HandleException(httpContext.Response, ex);
			}
		}

		private static async System.Threading.Tasks.Task HandleException
			(Microsoft.AspNetCore.Http.HttpResponse httpResponse, System.Exception exception)
		{
			// Log

			httpResponse.Headers.Add("Exception-Type", exception.GetType().Name);

			var feature =
				httpResponse.HttpContext.Features
				.Get<Microsoft.AspNetCore.Http.Features.IHttpResponseFeature>();

			feature.ReasonPhrase =
				"خطای ناشناخته‌ای صورت گرفته است! یا مجددا سعی نمایید و یا با تیم پشتیبانی تماس حاصل فرمایید.";

			httpResponse.StatusCode =
				(int)System.Net.HttpStatusCode.BadRequest;

			await httpResponse.WriteAsync(exception.Message).ConfigureAwait(false);
		}
	}
}
