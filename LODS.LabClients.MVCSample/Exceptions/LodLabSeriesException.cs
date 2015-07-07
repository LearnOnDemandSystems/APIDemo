namespace LODS.LabClients.MVCSample.Exceptions {
    /// <summary>
    /// Parent exception for lab series level exceptions.
    /// </summary>
    public class LodLabSeriesException : LodException {
        /// <summary>
        /// Parent exception for lab series level exceptions.
        /// </summary>
        public LodLabSeriesException(string message)
            : base(message) {
        }
    }
}