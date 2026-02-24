using DataTrasferObjectInterfaces;

namespace DataTransferObjects
{
    public class MetaDataDTO : IMetaDataDTO
    {
        #region Properties

        public string? UseCaseName
        {
            get; set;
        }

        public string? TransitionName
        {
            get; set;
        }

        public string? StateName
        {
            get; set;
        }

        public string? LayerName
        {
            get; set;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Method for crating MetaDataDTO
        /// </summary>
        /// <param name="useCaseName">Name of usecase</param>
        /// <param name="transitionName">Name of transition</param>
        /// <param name="stateName">Name of state</param>
        /// <param name="layerName">Name of the next layer</param>
        /// <returns>Created new MetaDataDTO</returns>
        public static MetaDataDTO Create(string useCaseName, string transitionName, string stateName, string layerName)
        {
            return new MetaDataDTO
            {
                UseCaseName = useCaseName,
                TransitionName = transitionName,
                StateName = stateName,
                LayerName = layerName
            };
        }

        #endregion
    }
}
