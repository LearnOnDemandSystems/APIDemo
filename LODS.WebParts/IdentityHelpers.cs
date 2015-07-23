using System.Linq;
using Microsoft.IdentityModel.Claims;

namespace LODS.SharePoint.ContentManagement {
    public static class IdentityHelpers {
        public static string GetUsedEmail(IClaimsPrincipal claimsPrincipal) {
            if (claimsPrincipal == null) {
                return GenerateFakeEmail();
            }
            var claimsIdentity = (IClaimsIdentity)claimsPrincipal.Identity;
            if (claimsIdentity.Name.Contains('@')) {
                // parse a claim identity to pull out a user's name
                var nameSplit = claimsIdentity.Name.Split('|');
                if (nameSplit.Length == 3) {
                    return nameSplit[2];
                }
                return claimsIdentity.Name;
            }
            var possibleUpn = LookForClaim(claimsIdentity.Claims, Constants.ClaimUpnSts);
            if (possibleUpn != null) {
                return possibleUpn;
            }
            possibleUpn = LookForClaim(claimsIdentity.Claims, Constants.ClaimUpnSp);
            if (possibleUpn != null) {
                return possibleUpn;
            }
            return GenerateFakeEmail();
        }

        private static string GenerateFakeEmail() {
            return "sharepointUser@unknown.local";
        }

        public static string LookForClaim(ClaimCollection claimCollection, string claimType) {
            var possibleClaim = claimCollection.FirstOrDefault(c => c.ClaimType == claimType);
            return possibleClaim == default(Claim) ? null : possibleClaim.Value;
        }
        
    }
}
