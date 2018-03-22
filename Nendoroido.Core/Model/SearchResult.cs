using System;
using System.Collections.Generic;
using System.Text;

namespace NendoroidAccessorySearchEngine.Core.Model
{
    /// <summary>
    /// search result
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// Number of Nendoroid
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// display name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Display image
        /// </summary>
        public string DisplayImage { get; set; }

        /// <summary>
        /// accessory type
        /// </summary>
        public AccessoryType AccessoryType { get; set; }

        /// <summary>
        /// introduce url
        /// </summary>
        public string IntroduceUrl { get; set; }

        /// <summary>
        /// uploader name
        /// </summary>
        public string UploaderName { get; set; }
    }
}
