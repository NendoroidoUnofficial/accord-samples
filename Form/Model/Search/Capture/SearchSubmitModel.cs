using NendoroidAccessorySearchEngine.Core.Model;

namespace Form.Model.Search.Capture
{
    /// <summary>
    ///     Search submit model
    /// </summary>
    public class SearchSubmitModel
    {
        /// <summary>
        ///     Type
        /// </summary>
        public AccessoryType AccessoryType { get; set; }

        /// <summary>
        ///     Image
        /// </summary>

        private byte[] Image { get; set; }
    }
}