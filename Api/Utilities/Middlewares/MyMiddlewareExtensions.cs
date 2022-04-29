using Microsoft.AspNetCore.Builder;

namespace Utilities.Middlewares
{
	/// <summary>
	/// 
	/// </summary>
	public static class MyMiddlewareExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		static MyMiddlewareExtensions()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="builder"></param>
		/// <returns></returns>
		public static Microsoft.AspNetCore.Builder.IApplicationBuilder
			UseExceptionHandling(this Microsoft.AspNetCore.Builder.IApplicationBuilder builder)
		{
			// UseMiddleware -> using Microsoft.AspNetCore.Builder;
			return builder.UseMiddleware<ExceptionHandlingMiddleware>();
		}
	}
}
