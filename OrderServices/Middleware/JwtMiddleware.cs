using Lombok.NET;
using OrderServices.Utils;

namespace TableServices.Middleware
{
    [RequiredArgsConstructor]
    public partial class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtUtils _jwtUtils;
        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {

                var userId = _jwtUtils.ValidateToken(token);
                if (userId != null)
                {
                    context.Items["UserId"] = userId;
                }

            }

            await _next(context);
        }
    }
}
