using Microsoft.AspNetCore.Authorization;

namespace L08HandsOnASPNetDB.Policy
{
    public class SpecificUserRequirement : AuthorizationHandler<SpecificUserRequirement>, IAuthorizationRequirement
    {

        public string UserName { get; set; }

        public SpecificUserRequirement(string username)
        {
            UserName = username.ToLower();
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SpecificUserRequirement requirement)
        {
            
            if (context.User?.Identity?.Name?.ToLower()?.Equals(UserName) ?? false)
            {
                context.Succeed(requirement);

            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
