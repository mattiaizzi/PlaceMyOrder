using PlaceMyOrder.Core.Facade;


namespace PlaceMyOrder.Api.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate next;

        public JwtMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, AuthFacade authFacade)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                try
                {
                    var user = await authFacade.GetUserFromTokenAsync(token);
                    context.Items["User"] = user;
                }
                catch
                {
                    //Do nothing if JWT validation fails
                    // user is not attached to context so the request won't have access to secure routes
                }
            }
            await next(context);
        }
    }
}
