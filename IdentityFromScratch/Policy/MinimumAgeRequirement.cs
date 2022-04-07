using Microsoft.AspNetCore.Authorization;

namespace IdentityFromScratch.Policy
{
    public class MinimumAgeRequirement : AuthorizationHandler<MinimumAgeRequirement>, IAuthorizationRequirement
    {

    }
}
