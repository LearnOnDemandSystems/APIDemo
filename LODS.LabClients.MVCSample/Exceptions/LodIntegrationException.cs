namespace LODS.LabClients.MVCSample.Exceptions {
    /// <summary>
    /// The base exception for integration-level exceptions.  These are conditions that apply to all users and labs across
    /// an integration at that point in time.
    /// </summary>
    public class LodIntegrationException: LodException {
        /// <summary>
        /// The base exception for integration-level exceptions.  These are conditions that apply to all users and labs across
        /// an integration at that point in time.
        /// </summary>
        public LodIntegrationException(string message)
            : base(message) {
        }
    }
}