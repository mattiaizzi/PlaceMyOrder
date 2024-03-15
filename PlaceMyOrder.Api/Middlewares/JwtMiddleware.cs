using PlaceMyOrder.Api.Services;


namespace PlaceMyOrder.Api.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate next;
        private readonly JwtService jwtService;

        public JwtMiddleware(RequestDelegate next, JwtService jwtService)
        {
            this.next = next;
            this.jwtService = jwtService;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                await attachUserToContext(context, token);
            }
            await next(context);
        }

        private async Task attachUserToContext(HttpContext context, string token)
        {
            try
            {
                var user = await jwtService.GetUserFromToken(token);
                context.Items["User"] = user;
            }
            catch
            {
                //Do nothing if JWT validation fails
                // user is not attached to context so the request won't have access to secure routes
            }
        }
    }
}
