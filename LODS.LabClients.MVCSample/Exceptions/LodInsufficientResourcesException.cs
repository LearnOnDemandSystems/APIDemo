namespace LODS.LabClients.MVCSample.Exceptions {
    /// <summary>
    /// On the hosting side, resources necessary to launch the lab were unavailable.  This generally means
    /// a configuration error in the lab.
    /// </summary>
    public class LodInsufficientResourcesException: LodSystemException {
        /// <summary>
        /// On the hosting side, resources necessary to launch the lab were unavailable.  This generally means
        /// a configuration error in the lab.
        /// </summary>
        public LodInsufficientResourcesException() : base("Required resources for your lab are not available in the lab system for your request at this time.  Please try again later.") { }
    }
}