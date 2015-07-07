namespace LODS.LabClients.MVCSample.Exceptions {
    /// <summary>
    /// The user has a saved instance, and should use that one instead of requesting a new instance.
    /// </summary>
    public class LodUserSavedInstanceExistsException: LodUserException {
        /// <summary>
        /// The user has a saved instance, and should use that one instead of requesting a new instance.
        /// </summary>
        public LodUserSavedInstanceExistsException() : base("An existing session exists; please resume that one instead of requesting a new one.") { }
    }
}