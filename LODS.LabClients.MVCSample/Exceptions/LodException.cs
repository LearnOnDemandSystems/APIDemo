namespace LODS.LabClients.MVCSample.Exceptions {
    /// <summary>
    /// The base launch exception for all lab-related exceptions.
    /// </summary>
    public class LodException: System.Exception {
        /// <summary>
        /// The base launch exception for all lab-related exceptions.
        /// </summary>
        public LodException(string message) : base(message) { }
    }
}