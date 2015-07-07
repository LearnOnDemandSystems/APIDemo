namespace LODS.LabClients.MVCSample.Exceptions {
    /// <summary>
    /// The maximum number of lab instances possible for the USER'S ORGANIZATION (across all users and integrations) has been reached.
    /// </summary>
    public class LodUserOrganizationMaxActiveLabInstancesReachedException: LodUserOrganizationException {
        /// <summary>
        /// The maximum number of lab instances possible for the USER'S ORGANIZATION (across all users and integrations) has been reached.
        /// </summary>
        public LodUserOrganizationMaxActiveLabInstancesReachedException() : base("The maximum number of concurrent instances for your organization has been reached.  Please try again later.") { }
    }
}