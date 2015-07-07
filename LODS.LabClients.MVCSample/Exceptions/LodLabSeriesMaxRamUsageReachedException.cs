namespace LODS.LabClients.MVCSample.Exceptions {
    /// <summary>
    /// The memory limit for all running instances for the LAB SERIES (across all users and integrations) has been reached.
    /// </summary>
    public class LodLabSeriesMaxRamUsageReachedException : LodLabSeriesException {
        /// <summary>
        /// The memory limit for all running instances for the LAB SERIES (across all users and integrations) has been reached.
        /// </summary>
        public LodLabSeriesMaxRamUsageReachedException() : base("The maximum amount of memory allowed to be used by the lab series across all active lab instances has been reached.  Please try again later.") { }
    }
}