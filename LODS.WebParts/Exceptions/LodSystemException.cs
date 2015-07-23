namespace LODS.SharePoint.ContentManagement.Exceptions {
    /// <summary>
    /// An error that is system-level on the Lab on Demand side.  There is likely no customer-level or user-level
    /// recovery for this condition.
    /// </summary>
    public class LodSystemException : LodException {
        /// <summary>
        /// An error that is system-level on the Lab on Demand side.  There is likely no customer-level or user-level
        /// recovery for this condition.
        /// </summary>
        public LodSystemException(string message)
            : base(message) {
        }
    }
}