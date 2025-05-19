namespace Mock.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;        
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApplicationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new { message = ex.Message });
            }
            catch(FluentValidation.ValidationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;                

                var errorResponse = new
                {
                    Errors = ex.Errors.Select(err => new
                    {
                        Field = err.PropertyName,
                        Message = err.ErrorMessage
                    })
                };

                await context.Response.WriteAsJsonAsync(errorResponse);
            }
            catch (Exception ex)
            {                
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new { message = "An unexpected error occurred." });
            }
        }
    }
}
