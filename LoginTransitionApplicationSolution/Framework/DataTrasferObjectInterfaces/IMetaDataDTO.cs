namespace DataTrasferObjectInterfaces
{
    public interface IMetaDataDTO
    {
        #region Properties

        /// <summary>
        /// Nanme of use case
        /// </summary>
        string? UseCaseName
        {
            get; set;
        }

        /// <summary>
        /// Name of transition
        /// </summary>
        string? TransitionName
        {
            get; set;
        }

        /// <summary>
        /// Name of state
        /// </summary>
        string? StateName
        {
            get; set;
        }

        /// <summary>
        /// Name of layer
        /// </summary>
        string? LayerName
        {
            get; set;
        }

        #endregion
    }
}
