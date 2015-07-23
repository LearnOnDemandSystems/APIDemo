namespace LODS.SharePoint.ContentManagement {
    public static class Constants {
    
        // session constants - integration
        public const string SessionApiKey = "LodKey";
        public const string SessionLodEndpoint = "LodEndpoint";
        public const string SessionDataServiceEndpoint = "DataEndpoint";
        public const string SessionActiveUserName = "ActiveUserName";
        public const string SessionAllowAnonymousLaunch = "AllowAnonymousLaunch";
        
        // query string constants - launch
        public const string QueryStringLabId = "labId";

        // claims identifiers
        public const string ClaimUpnSts = "http://schemas.microsoft.com/office/2012/01/upn";
        public const string ClaimUpnSp = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn";
    }
}

