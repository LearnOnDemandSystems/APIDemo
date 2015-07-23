namespace LODS.SharePoint.ContentManagement.Exceptions {
    /// <summary>
    /// An error that is owner organization-level on the Lab on Demand side.  There is a likely owner-level
    /// recovery for this condition.
    /// </summary>
    public class LodUserOrganizationException : LodException {
        /// <summary>
        /// An error that is owner organization-level on the Lab on Demand side.  There is a likely owner-level
        /// recovery for this condition.
        /// </summary>
        public LodUserOrganizationException(string message)
            : base(message) {
        }
    }
}