using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using LabOnDemand.ApiV3;

namespace LODS.LabClients.MVCSample.Models {
    /// <summary>
    /// A single lab as viewable to the user in the Available view.
    /// </summary>
    public class AvailableLabViewModel {
        /// <summary>
        /// The ID is the unique ID for this lab profile in the LOD system.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The formatted text to show to the user as the title for the lab.
        /// </summary>
        public string TitleString { get; set; }
        /// <summary>
        /// The abstract for the lab, explaining the lab's purpose and background.
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// The set of all labs available to the user for the Available view.
    /// </summary>
    public class AvailableLabViewModelCollection : Dictionary<LabSeries, ICollection<AvailableLabViewModel>> {
    }

    /// <summary>
    /// A single lab instance for the user in the Saved view.
    /// </summary>
    public class SavedLabViewModel {
        /// <summary>
        /// The unique identifier for this specific lab instance.
        /// </summary>
        public long InstanceId { get; set; }
        /// <summary>
        /// The formatted text to show to the user as the title for the lab.
        /// </summary>
        public string TitleString { get; set; }
        /// <summary>
        /// The abstract for the lab, explaining the lab's purpose and background.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// When (in UTC) the lab instance was last saved.
        /// </summary>
        public DateTime SavedUtc { get; set; }
        /// <summary>
        /// When (in UTC) the lab instance will expire and automatically be removed from the system.
        /// </summary>
        public DateTime ExpiresUtc { get; set; }
        /// <summary>
        /// The time left in the original lab session before the time limit has been reached.
        /// </summary>
        public int MinutesRemaining { get; set; }
        /// <summary>
        /// The lab is available to be resumed.  Practically speaking, this is only going to be false
        /// if the lab is in the process of being saved.
        /// </summary>
        public bool Available { get; set; }
    }

    /// <summary>
    /// The set of all lab instances available to the user for the Saved view.
    /// </summary>
    public class SavedLabViewModelCollection : Collection<SavedLabViewModel> {}

    /// <summary>
    /// A single lab instance from the past, with its results.
    /// </summary>
    public class HistoricalLabInstance {
        /// <summary>
        /// The unique identifier for this specific lab instance.
        /// </summary>
        public long InstanceId { get; set; }
        /// <summary>
        /// The formatted text to show to the user as the title for the lab.
        /// </summary>
        public string TitleString { get; set; }
        /// <summary>
        /// The user identification string as originally supplied to Lab on Demand.
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// When (in UTC) the lab was originally started.
        /// </summary>
        public DateTime StartUtc { get; set; }
        /// <summary>
        /// When (in UTC) the lab was ended - may be <c>null</c> if the instance has not ended yet.
        /// </summary>
        public DateTime EndUtc { get; set; }
        /// <summary>
        /// The end status of the lab.
        /// </summary>
        public LabCompletionStatus CompletionStatus { get; set; }
    }

    /// <summary>
    /// The set of all lab instances in a past report.
    /// </summary>
    public class HistoricalLabInstanceCollection: Collection<HistoricalLabInstance> { }


}