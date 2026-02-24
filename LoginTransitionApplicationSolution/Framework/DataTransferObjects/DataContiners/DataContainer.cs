using DataTransferObjects;

namespace DataTrasferObjectInterfaces
{
    /// <summary>
    /// DataContainer class
    /// </summary>
    public class DataContainer : Dictionary<string, dynamic>, IDataContainer
    {
        #region Methods

        /// <summary>
        /// Method wich adds DataCollection
        /// </summary>
        /// <typeparam name="T">Type of DataCollection</typeparam>
        /// <param name="key">>Key wich points on DataCollection</param>
        /// <param name="dataCollection">DataCollection wich needs to be added</param>
        public void AddDataCollection<T>(string key, IDataCollection<T> dataCollection)
        {
            base.Add(key, dataCollection);
        }

        /// <summary>
        /// Method for adding DTO to DataContainer
        /// </summary>
        /// <typeparam name="T">Type of DTO</typeparam>
        /// <param name="dto">DTO wich needs to be added</param>
        /// <param name="key">Key wich points on DTO</param>
        public void AddDTOToDataContainer<T>(T dto, string key)
        {
            DataCollection<T> dataCollection;

            if (this.ContainsKey(key))
            {
                dataCollection = this[key];
                dataCollection.Add(dto);
            }
            else
            {
                dataCollection = new DataCollection<T>();
                dataCollection.Add(dto);
                AddDataCollection(key, dataCollection);
            }
        }

        /// <summary>
        /// Method for getting DataCollection
        /// </summary>
        /// <typeparam name="T">Type of DataCollection</typeparam>
        /// <param name="key">Key wich points on right DataCollection</param>
        /// <returns>DataCollection</returns>
        public IDataCollection<T>? GetDataCollection<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            if (this.Keys.Contains(key))
            {
                return this[key];
            }

            return null;
        }

        /// <summary>
        /// Method for getting DTO from DataContainer
        /// </summary>
        /// <typeparam name="T">Type of DTO</typeparam>
        /// <param name="key">Key wich points on right DTO</param>
        /// <returns>DTO</returns>
        public T? GetDTO<T>(string key)
        {
            IDataCollection<T>? dataCollection = this.GetDataCollection<T>(key);

            if (dataCollection == null)
            {
                return default;
            }

            if (dataCollection.Count == 0)
            {
                return default;
            }

            T dto = dataCollection[0];

            return dto;
        }

        /// <summary>
        /// Method for deleting the last DTO in DataCollection
        /// </summary>
        /// <typeparam name="T">Type of DTO</typeparam>
        /// <param name="key">Key wich points on right DTO</param>
        public void DeleteDTOLast<T>(string key)
        {
            IDataCollection<T>? dataCollection = GetDataCollection<T>(key);

            if (dataCollection == null || dataCollection.Count == 0)
            {
                return;
            }                

            dataCollection.RemoveAt(dataCollection.Count - 1);
        }


        #endregion
    }
}
