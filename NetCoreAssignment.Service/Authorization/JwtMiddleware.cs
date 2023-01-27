namespace NetCoreAssignment.Service.Authorization;

using NetCoreAssignment.Service.Contracts.Services;
using Microsoft.AspNetCore.Http;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = jwtUtils.ValidateToken(token);
        if (userId != null)
        {
            // attach user to context on successful jwt validation
            context.Items["User"] = userService.GetByIdAsync(userId.Value).Result;
        }

        await _next(context);
    }
}