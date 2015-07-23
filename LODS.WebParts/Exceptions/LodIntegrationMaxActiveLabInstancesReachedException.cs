namespace LODS.SharePoint.ContentManagement.Exceptions {
    /// <summary>
    /// The maximum number of lab instances possible for the INTEGRATION (across all users and labs) has been reached.
    /// </summary>
    public class LodIntegrationMaxActiveLabInstancesReachedException: LodIntegrationException {
        /// <summary>
        /// The maximum number of lab instances possible for the INTEGRATION (across all users and labs) has been reached.
        /// </summary>
        public LodIntegrationMaxActiveLabInstancesReachedException() : base("The maximum number of concurrent instances for your company (integration) has been reached.  Please try again later.") { }
    }
}