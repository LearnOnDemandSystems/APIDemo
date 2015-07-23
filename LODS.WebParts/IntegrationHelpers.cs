using System.Web.SessionState;
using LabOnDemand.ApiV3;

namespace LODS.SharePoint.ContentManagement {
    public static class IntegrationHelpers {
        public static LabOnDemandApiClient GetLabOnDemandApiClientForSession(HttpSessionState session) {
            var endpoint = SessionManager.GetIntegrationEndpoint(session);
            var apiKey = SessionManager.GetIntegrationApiKey(session);
            Tracing.WriteTraceMessage("Connection info : {0} {1}");
            return new LabOnDemandApiClient(endpoint, apiKey);
        }
    }
}
