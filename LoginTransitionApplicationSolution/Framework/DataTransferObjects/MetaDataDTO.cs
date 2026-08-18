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
        public static IMetaDataDTO Create(string useCaseName, string stateName, string transitionName, string layerName)
        {
            IMetaDataDTO metaDataDTO = new MetaDataDTO();
            metaDataDTO.UseCaseName = useCaseName;
            metaDataDTO.StateName = stateName;
            metaDataDTO.TransitionName = transitionName;
            metaDataDTO.LayerName = layerName;

            return metaDataDTO;
        }

        #endregion
    }
}
