namespace Router
{
    public class ApplicationRouter
    {
        public void Redirect(IDataContainer dataContainer)
        {
            switch (MetaDataDTO.LayerName)
            {
                case LayerContract.VM:
                    break;

                case LayerContract.BL:
                    break;

                case LayerContract.DPL:
                    break;

                case LayerContract.DAL:
                    break;
            }

            ITransitionHandler transitionHandler = _serviceProvider.GetRequiredKeyedService<ItransitionHandler>(key);
            ManagementSystem.InitializeTransitionHandler(transitionHandler);
        }
    }
}
