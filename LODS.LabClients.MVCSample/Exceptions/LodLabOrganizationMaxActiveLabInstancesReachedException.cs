namespace LODS.LabClients.MVCSample.Exceptions {
    /// <summary>
    /// The maximum number of lab instances possible for the LAB OWNER ORGANIZATION (PUBLISHER) (across all users and integrations) has been reached.
    /// </summary>
    public class LodLabOrganizationMaxActiveLabInstancesReachedException: LodLabOrganizationException {
        /// <summary>
        /// The maximum number of lab instances possible for the LAB OWNER ORGANIZATION (PUBLISHER) (across all users and integrations) has been reached.
        /// </summary>
        public LodLabOrganizationMaxActiveLabInstancesReachedException() : base("The maximum number of concurrent instances for the lab publisher has been reached.  Please try again later.") { }
    }
}