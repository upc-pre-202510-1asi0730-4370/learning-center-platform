using ACME.LearningCenterPlatform.API.IAM.Application.Internal.OutbountServices;
using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.IAM.Domain.Services;
using ACME.LearningCenterPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace ACME.LearningCenterPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Components;

public class RequestAuthorizationMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(
        HttpContext context,
        IUserQueryService userQueryService,
        ITokenService tokenService
    )
    {
        Console.WriteLine("Entering InvokeAsync");
        var allowAnonymous = context.Request.HttpContext.GetEndpoint()!.Metadata
            .Any(m => m.GetType() == typeof(AllowAnonymousAttribute));

        if (allowAnonymous)
        {
            Console.WriteLine("Skipping authorization - Middleware");
            await next(context);
            return;
        }
        Console.WriteLine("Entering Authorization");
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token == null) throw new Exception("Null or invalid token");

        var userId = await tokenService.ValidateToken(token);
        
        if (userId == null) throw new Exception("Invalid token");

        var getUserByIdQuery = new GetUserByIdQuery(userId.Value);
        var user = await userQueryService.Handle(getUserByIdQuery);
        Console.WriteLine("Successfully authorization. Updating Context ... ");
        context.Items["User"] = user;
        Console.WriteLine("Continuing with Middleware Pipeline");
        
        await next(context);
    }
    
}