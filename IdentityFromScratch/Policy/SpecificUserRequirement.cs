using Microsoft.AspNetCore.Authorization;

namespace IdentityFromScratch.Policy
{
    public class SpecificUserRequirement  : AuthorizationHandler<SpecificUserRequirement>, IAuthorizationRequirement
    {
        public string UserName { get; set; }
        protected override Task HandlerRequirementAsync(AuthorizationHandlerContext context, SpecificUserRequirement requirement)
        {
            try
            {
                if (context.User?.Identity?.Name?.ToLower()?.Equals(UserName)) ?? false){
                    context.Succeed(requirement);
                }
            else
                {
                    context.Fail();
                }
            return Task.CompletedTask;
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
