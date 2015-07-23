using System.Web.SessionState;

namespace LODS.SharePoint.ContentManagement {
    public static class SessionManager {
        public static void SaveIntegrationSession(HttpSessionState session, string endpointUri, string apiKey, string dataServiceEndpoint, string activeUserName) {
            session[Constants.SessionApiKey] = apiKey;
            session[Constants.SessionLodEndpoint] = endpointUri;
            session[Constants.SessionDataServiceEndpoint] = dataServiceEndpoint;
            session[Constants.SessionActiveUserName] = activeUserName;
        }

        public static string GetIntegrationEndpoint(HttpSessionState session) {
            return (string)session[Constants.SessionLodEndpoint];
        }

        public static string GetIntegrationApiKey(HttpSessionState session) {
            return (string)session[Constants.SessionApiKey];
        }

        public static string GetDataServiceEndpoint(HttpSessionState session) {
            return (string) session[Constants.SessionDataServiceEndpoint];
        }

        public static string GetActiveUserName(HttpSessionState session) {
            return (string) session[Constants.SessionActiveUserName];
        }

        public static bool SessionReadyForApiIntegration(HttpSessionState session) {
            return !string.IsNullOrWhiteSpace(GetIntegrationApiKey(session)) &&
                   !string.IsNullOrWhiteSpace(GetIntegrationEndpoint(session)) &&
                   !string.IsNullOrWhiteSpace(GetActiveUserName(session));
        }

        public static bool SessionReadyForDataAccess(HttpSessionState session) {
            return !string.IsNullOrWhiteSpace(GetDataServiceEndpoint(session)) &&
                !string.IsNullOrWhiteSpace(GetActiveUserName(session));
        }

        public static bool SessionAllowsAnonymous(HttpSessionState session) {
            return (bool) (session[Constants.SessionAllowAnonymousLaunch] ?? false);
        }

        public static void SessionAllowsAnonymous(HttpSessionState session, bool allowsAnonymous) {
            session[Constants.SessionAllowAnonymousLaunch] = allowsAnonymous;
        }
    }
}
