using Form.Domain.Setting.SearchEngine;

namespace Form.Model.Setting.SearchEngine
{
    public class SearchEngineSelectionModel
    {
        /// <summary>
        ///     Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Type
        /// </summary>
        public SearchEngineType SearchEngineType { get; set; }
    }
}