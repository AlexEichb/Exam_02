namespace UFOrganizer
{
    /// <summary>
    /// UFO report objects for list visualization.
    /// </summary>
    public interface IUfoReportListViewObject
    {
        /// <summary>
        /// The city of the observation.
        /// </summary>
        string City { get; set; }

        /// <summary>
        /// The timestamp of the observation.
        /// </summary>
        DateTime DateTime { get; set; }

        /// <summary>
        /// A brief summary of the observation.
        /// </summary>
        string Summary { get; set; }
    }
}
