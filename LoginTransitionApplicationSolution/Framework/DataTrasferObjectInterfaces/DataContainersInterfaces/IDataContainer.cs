namespace DataTrasferObjectInterfaces
{
    /// <summary>
    /// DataContainer interface
    /// </summary>
    public interface IDataContainer
    {
        /// <summary>
        /// Method which adding data collection by key into data container
        /// </summary>
        /// <typeparam name="T">Any property</typeparam>
        /// <param name="key">Key value</param>
        /// <param name="dataCollection">Data collection</param>
        void AddDataCollection<T>(string key, IDataCollection<T> dataCollection);


        void AddDTOToDataContainer<T>(T dto, string key);

        /// <summary>
        /// Method which gets data collection by key from data container
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        IDataCollection<T>? GetDataCollection<T>(string key);


        T? GetDTO<T>(string key);

        /// <summary>
        /// Method for deleting the last DTO in DataCollection
        /// </summary>
        /// <typeparam name="T">Type of DTO</typeparam>
        /// <param name="key">Key wich points on right DTO</param>
        void DeleteDTOLast<T>(string key);
    }
}
