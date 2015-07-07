namespace LODS.LabClients.MVCSample.Exceptions {
    /// <summary>
    /// The memory limit for all running instances across the INTEGRATION (across all users and labs) has been reached.
    /// </summary>
    public class LodIntegrationMaxRamUsageReachedException : LodIntegrationException {
        /// <summary>
        /// The memory limit for all running instances across the INTEGRATION (across all users and labs) has been reached.
        /// </summary>
        public LodIntegrationMaxRamUsageReachedException() : base("The maximum amount of memory allowed to be used by your company (integration) across all active lab instances has been reached.  Please try again later.") { }
    }
}