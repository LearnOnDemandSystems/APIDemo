namespace LODS.LabClients.MVCSample.Exceptions {
    /// <summary>
    /// The maximum number of lab instances possible for the LAB PROFILE (across all users and integrations) has been reached.
    /// </summary>
    public class LodLabProfileMaxActiveLabInstancesReachedException: LodLabProfileException {
        /// <summary>
        /// The maximum number of lab instances possible for the LAB PROFILE (across all users and integrations) has been reached.
        /// </summary>
        public LodLabProfileMaxActiveLabInstancesReachedException() : base("The maximum number of concurrent instances for the requested lab has been reached.  Please try again later.") { }
    }
}