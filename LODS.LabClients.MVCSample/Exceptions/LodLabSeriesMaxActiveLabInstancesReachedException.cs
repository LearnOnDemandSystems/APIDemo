namespace LODS.LabClients.MVCSample.Exceptions {
    /// <summary>
    /// The maximum number of lab instances possible for the LAB SERIES (across all users and integrations) has been reached.
    /// </summary>
    public class LodLabSeriesMaxActiveLabInstancesReachedException: LodLabSeriesException {
        /// <summary>
        /// The maximum number of lab instances possible for the LAB SERIES (across all users and integrations) has been reached.
        /// </summary>
        public LodLabSeriesMaxActiveLabInstancesReachedException() : base("The maximum number of concurrent instances for the lab series has been reached.  Please try again later.") { }
    }
}