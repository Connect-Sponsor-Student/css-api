
using System.Net;

namespace CSS.WebAPI.Middlewares;
public class GlobalExceptionMiddleware : IMiddleware
{
   private readonly ILogger<GlobalExceptionMiddleware> _logger;
		public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
		{
			_logger = logger;
		}
		public async Task InvokeAsync(HttpContext context, RequestDelegate _next)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
				context.Response.ContentType = "text/plain";
				_logger.LogError(ex.Message);
				
				await context.Response.WriteAsync(ex.Message);
			}
		}
}