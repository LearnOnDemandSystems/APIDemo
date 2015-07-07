namespace LODS.LabClients.MVCSample.Exceptions {
    /// <summary>
    /// The memory limit for all running instances for the USER'S ORGANIZATION (across all users and integrations) has been reached.
    /// </summary>
    public class LodUserOrganizationMaxRamUsageReachedException : LodUserOrganizationException {
        /// <summary>
        /// The memory limit for all running instances for the USER'S ORGANIZATION (across all users and integrations) has been reached.
        /// </summary>
        public LodUserOrganizationMaxRamUsageReachedException() : base("The maximum amount of memory allowed to be used by your organization across all active lab instances has been reached.  Please try again later.") { }
    }
}