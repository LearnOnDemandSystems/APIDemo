namespace LODS.SharePoint.ContentManagement.Exceptions {
    /// <summary>
    /// The maximum number of lab instances for THIS SPECIFIC LAB allowed for THIS USER has been reached, so they
    /// should cleanly exit another instance before trying to start a new one.
    /// </summary>
    /// <remarks>
    /// Typically, users will only be
    /// allowed one instance, so the error message is written with that in mind.
    /// </remarks>
    public class LodUserMaxActiveLabInstancesReachedException : LodUserException {
        /// <summary>
        /// The maximum number of lab instances for THIS SPECIFIC LAB allowed for THIS USER has been reached, so they
        /// should cleanly exit another instance before trying to start a new one.
        /// </summary>
        /// <remarks>
        /// Typically, users will only be
        /// allowed one instance, so the error message is written with that in mind.
        /// </remarks>
        public LodUserMaxActiveLabInstancesReachedException() : base("You are only allowed one lab instance at a time and already have one running.  Please exit the other one, then try again.") { }
    }
}