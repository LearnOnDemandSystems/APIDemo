using System;
using System.Linq;
using System.Web;
using LabOnDemand.ApiV3;
using LODS.SharePoint.ContentManagement.Exceptions;
using Microsoft.IdentityModel.Claims;
using Microsoft.SharePoint.WebControls;

namespace LODS.SharePoint.ContentManagement.Layouts.LODS.WebParts {
    public partial class LodLauncher : UnsecuredLayoutsPageBase {

        protected override bool AllowAnonymousAccess {
            get {
                return SessionManager.SessionAllowsAnonymous(Session);
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!SessionManager.SessionReadyForApiIntegration(Session)) {
                ErrorMessage.Text = "Improper launch information supplied.";
                return;
            }
            var labIdString = Request[Constants.QueryStringLabId];
            if (string.IsNullOrWhiteSpace(labIdString)) {
                ErrorMessage.Text = "Missing or empty lab profile id.";
                return;
            }
            int labProfileId;
            if (!int.TryParse(labIdString, out labProfileId)) {
                ErrorMessage.Text = "Improper lab profile id.";
                return;
            }
            Tracing.WriteTraceMessage("Profile id : {0}", labProfileId);
            var client = IntegrationHelpers.GetLabOnDemandApiClientForSession(Session);

            var allowAnonymousLaunch = SessionManager.SessionAllowsAnonymous(Session);
            if (!Request.IsAuthenticated && !allowAnonymousLaunch) {
                throw new HttpException(403, "You must be signed in to continue.");
            }

            try {
                LaunchResponse launchResponse;
                string userExternalId = string.Empty;
                if (Request.IsAuthenticated) {
                    userExternalId = SessionManager.GetActiveUserName(Session);
                    var userFirstName = "SharePoint";
                    var userLastName = "User";
                    var userEmail = IdentityHelpers.GetUsedEmail(Page.User as IClaimsPrincipal);
                    Tracing.WriteTraceMessage("Identifiers : \"{0}\" \"{1}\" \"{2}\" \"{3}\"", userExternalId,
                        userFirstName, userLastName, userEmail);
                    launchResponse = client.Launch(labProfileId, userExternalId, userFirstName, userLastName, userEmail,
                        false);
                } else {
                    launchResponse = client.LaunchAnonymous(labProfileId);
                }
                switch (launchResponse.Result) {
                    case LaunchResult.Success:
                        Response.Redirect(launchResponse.Url, true);
                        return;
                    case LaunchResult.SavedInstanceExists:
                        if (string.IsNullOrWhiteSpace(userExternalId)) {
                            throw new HttpException(500, "Anonymous launch call returned saved instance response");
                        }
                        var savedSessionResponse = client.UserRunningAndSavedLabs(userExternalId);
                        var savedSession = savedSessionResponse.SavedLabs.First(s => s.LabProfileId == labProfileId);
                        var resumeResponse = client.Resume(savedSession.LabInstanceId);
                        Response.Redirect(resumeResponse.Url, true);
                        return;
                    case LaunchResult.InsufficientResources:
                        // On the hosting side, resources necessary to launch the lab were unavailable.  This generally means
                        // a configuration error in the lab.
                        throw new LodInsufficientResourcesException();
                    case LaunchResult.ApiIntegrationMaxActiveLabInstancesReached:
                        // The maximum number of lab instances possible for the INTEGRATION (across all users and labs) has been reached.
                        throw new LodIntegrationMaxActiveLabInstancesReachedException();
                    case LaunchResult.ApiIntegrationMaxRamUsageReached:
                        // The memory limit for all running instances across the INTEGRATION (across all users and labs) has been reached.
                        throw new LodIntegrationMaxRamUsageReachedException();
                    case LaunchResult.UserMaxActiveLabInstancesReached:
                        // The maximum number of lab instances possible for the USER has been reached... note that as of when this code was
                        // written, users are only allowed to have one instance per user, so the error message in the exception assumes
                        // that is the case.  In production, you may want to be less specific about this as a futureproofing decision;
                        // however, you would also know what the maximum per user is allowed to be if it's not "one," so you can
                        // do the right thing.
                        throw new LodUserMaxActiveLabInstancesReachedException();
                    case LaunchResult.UserMaxRamUsageReached:
                        // The memory limit for all running instances for the USER been reached
                        throw new LodUserMaxRamUsageReachedException();
                    case LaunchResult.LabSeriesMaxActiveLabInstancesReached:
                        // The maximum number of lab instances possible for the LAB SERIES (across all users and integrations) has been reached.
                        throw new LodLabSeriesMaxActiveLabInstancesReachedException();
                    case LaunchResult.LabSeriesMaxRamUsageReached:
                        // The memory limit for all running instances for the LAB SERIES (across all users and integrations) has been reached.
                        throw new LodLabSeriesMaxRamUsageReachedException();
                    case LaunchResult.LabOrganizationMaxActiveLabInstancesReached:
                        // The maximum number of lab instances possible for the LAB OWNER ORGANIZATION (PUBLISHER) (across all users and integrations) has been reached.
                        throw new LodLabOrganizationMaxActiveLabInstancesReachedException();
                    case LaunchResult.LabOrganizationMaxRamUsageReached:
                        // The memory limit for all running instances for the LAB OWNER ORGANIZATION (PUBLISHER) (across all users and integrations) has been reached.
                        throw new LodLabOrganizationMaxRamUsageReachedException();
                    case LaunchResult.LabProfileMaxActiveLabInstancesReached:
                        // The maximum number of lab instances possible for the LAB PROFILE (across all users and integrations) has been reached.
                        throw new LodLabProfileMaxActiveLabInstancesReachedException();
                    case LaunchResult.UserOrganizationMaxActiveLabInstancesReached:
                        // The maximum number of lab instances possible for the USER'S ORGANIZATION (across all users and integrations) has been reached.
                        throw new LodUserOrganizationMaxActiveLabInstancesReachedException();
                    case LaunchResult.UserOrganizationMaxRamUsageReached:
                        // The memory limit for all running instances for the USER'S ORGANIZATION (across all users and integrations) has been reached.
                        throw new LodUserOrganizationMaxRamUsageReachedException();
                    case LaunchResult.Error:
                        // A non-specific error occurred creating the lab instance.  This is not expected to be reported.
                        throw new LodLabLaunchErrorException(launchResponse.Error);
                    default:
                        // There are no other response codes.  This is here to keep the compiler happy, as well as making sure that
                        // we are somewhat future-proofed.  Perhaps throwing a generic launch exception would be better.
                        throw new HttpException(404, "The launch failed - profile not found?");
                }
            }
            catch (Exception ex) {
                ErrorMessage.Text = ex.Message;
            }
        }

    }
}
