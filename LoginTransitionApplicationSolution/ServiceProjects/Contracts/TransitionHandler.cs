using ApplicationEvents;
using DataTrasferObjectInterfaces;

namespace Contracts
{
    public class TransitionHandler
    {
        public readonly ManagmentSystemEvents _managmentSystemEvents = new ManagmentSystemEvents();

        private IMetaDataDTO MetaDataDTO
        {
            get; set;
        } = default!;

        private IDataContainer DataContainer
        {
            get; set;
        } = default!;

        public void ProcessRequest(IDataContainer dataContainer)
        {
            _managmentSystemEvents.RouteRequest(DataContainer);
        }

        public void AddMetaData(IMetaDataDTO MetaDataDTO, string key)
        {
            DataContainer.AddDTOToDataContainer(MetaDataDTO, key);
        }

        public void DeleteLastMetaData(string key)
        {
            DataContainer.DeleteLastDTO<IMetaDataDTO>(key);
        }
        //TODO MetaData ADD, RAISE EVENT, DELETE 
        // IHERITE LAYER CLASS
    }
}
