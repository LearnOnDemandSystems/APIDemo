namespace LODS.SharePoint.ContentManagement.Exceptions {
    /// <summary>
    /// The memory limit for all running instances for this user (across all integrations and labs) has been reached.
    /// </summary>
    public class LodUserMaxRamUsageReachedException : LodUserException {
        /// <summary>
        /// The memory limit for all running instances for this user (across all integrations and labs) has been reached.
        /// </summary>
        public LodUserMaxRamUsageReachedException() : base("The maximum amount of memory allowed to be used by you across all active lab instances has been reached.  Please try again later.") { }
    }
}