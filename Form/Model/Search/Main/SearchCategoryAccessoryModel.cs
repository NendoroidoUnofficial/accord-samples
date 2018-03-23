using Nendoroido.Core.Model;

namespace Form.Model.Search.Main
{
    /// <summary>
    ///     Search Category
    /// </summary>
    public class SearchCategoryAccessoryModel
    {
        /// <summary>
        ///     Name
        /// </summary>
        public string SearchAccessoryName { get; set; }

        /// <summary>
        ///     Image
        /// </summary>
        public string BackgroundImage { get; set; }

        /// <summary>
        ///     Type
        /// </summary>
        public AccessoryType AccessoryType { get; set; }
    }
}