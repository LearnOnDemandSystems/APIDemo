namespace LODS.SharePoint.ContentManagement.Exceptions {
    /// <summary>
    /// An error that is content-level on the Lab on Demand side.  This likely requires customer intervention
    /// in the lab profile.
    /// </summary>
    public class LodLabProfileException : LodException {
        /// <summary>
        /// An error that is content-level on the Lab on Demand side.  This likely requires customer intervention
        /// in the lab profile.
        /// </summary>
        public LodLabProfileException(string message)
            : base(message) {
        }
    }
}