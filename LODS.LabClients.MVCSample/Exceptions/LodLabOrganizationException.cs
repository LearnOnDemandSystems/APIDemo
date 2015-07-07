namespace LODS.LabClients.MVCSample.Exceptions {
    /// <summary>
    /// An error that is lab owner-level on the Lab on Demand side.  There is likely no customer-level or user-level
    /// recovery for this condition; the lab owner will need to be consulted.
    /// </summary>
    public class LodLabOrganizationException : LodException {
        /// <summary>
        /// An error that is lab owner-level on the Lab on Demand side.  There is likely no customer-level or user-level
        /// recovery for this condition; the lab owner will need to be consulted.
        /// </summary>
        public LodLabOrganizationException(string message)
            : base(message) {
        }
    }
}