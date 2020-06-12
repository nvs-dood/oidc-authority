using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using is4aspid.Models;
using Microsoft.AspNetCore.Identity;

namespace is4aspid.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;

        public ProfileService(IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, UserManager<ApplicationUser> userManager)
        {
            _claimsFactory = claimsFactory;
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            var principal = await _claimsFactory.CreateAsync(user);

            var claims = principal.Claims.ToList();
            claims.Add(new Claim("doodrole", user.IsSupervisor ? "supervisor" : "inferior"));

            var actualRequestedResources = new List<Resource>();
            actualRequestedResources.AddRange(context.RequestedResources.ApiResources);
            actualRequestedResources.AddRange(context.RequestedResources.IdentityResources);

            var actualRequestedClaims = actualRequestedResources.SelectMany(res => res.UserClaims);

            // TODO try to use context.RequestedClaimTypes, but its not working (empty)
            claims = claims.Where(claim => actualRequestedClaims.Contains(claim.Type)).ToList();
            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);

            context.IsActive = user != null;
        }
    }
}
