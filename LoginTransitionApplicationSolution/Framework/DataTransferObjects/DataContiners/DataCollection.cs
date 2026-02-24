using DataTrasferObjectInterfaces;

namespace DataTransferObjects
{
    /// <summary>
    /// DataCollection class
    /// </summary>
    /// <typeparam name="T">Any property</typeparam>
    public class DataCollection<T> : List<T>, IDataCollection<T>
    {

    }
}
