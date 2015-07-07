namespace LODS.LabClients.MVCSample.Exceptions {
    /// <summary>
    /// A non-specific error occurred creating the lab instance.  This is not expected to be reported.
    /// </summary>
    public class LodLabLaunchErrorException: LodSystemException {
        /// <summary>
        /// A non-specific error occurred creating the lab instance.  This is not expected to be reported.
        /// </summary>
        public LodLabLaunchErrorException() : base("A system error occurred creating your lab instance.  Please try again later.") { }
    }
}