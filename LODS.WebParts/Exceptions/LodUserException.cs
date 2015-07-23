namespace LODS.SharePoint.ContentManagement.Exceptions {
    /// <summary>
    /// An error that is user-level on the Lab on Demand side.  There is a likely customer-level
    /// recovery for this condition.
    /// </summary>
    public class LodUserException : LodException {
        /// <summary>
        /// An error that is user-level on the Lab on Demand side.  There is a likely customer-level
        /// recovery for this condition.
        /// </summary>
        public LodUserException(string message)
            : base(message) {
        }
    }
}