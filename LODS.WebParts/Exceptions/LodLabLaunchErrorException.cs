namespace LODS.SharePoint.ContentManagement.Exceptions {
    /// <summary>
    /// A non-specific error occurred creating the lab instance.  This is not expected to be reported.
    /// </summary>
    public class LodLabLaunchErrorException: LodSystemException {
        /// <summary>
        /// A non-specific error occurred creating the lab instance.  This is not expected to be reported.
        /// </summary>
        public LodLabLaunchErrorException(string message) : base(string.Format("A system error occurred creating your lab instance.  Please try again later.  (Details: {0})", message)) { }
    }
}