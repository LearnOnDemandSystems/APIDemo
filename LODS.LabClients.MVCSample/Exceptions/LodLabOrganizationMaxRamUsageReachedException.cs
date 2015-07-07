namespace LODS.LabClients.MVCSample.Exceptions {
    /// <summary>
    /// The memory limit for all running instances for the LAB OWNER ORGANIZATION (PUBLISHER) (across all users and integrations) has been reached.
    /// </summary>
    public class LodLabOrganizationMaxRamUsageReachedException : LodLabOrganizationException {
        /// <summary>
        /// The memory limit for all running instances for the LAB OWNER ORGANIZATION (PUBLISHER) (across all users and integrations) has been reached.
        /// </summary>
        public LodLabOrganizationMaxRamUsageReachedException() : base("The maximum amount of memory allowed to be used by the lab publisher across all active lab instances has been reached.  Please try again later.") { }
    }
}