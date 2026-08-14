using BusinessProcessHandlers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace Account.VM
{
    public partial class RegistrationViewModel : StateHandler
    {
        #region Data Fields        

        /// <summary>
        /// Message for notification
        /// </summary>
        [ObservableProperty]
        public string? notificationMessage;

        /// <summary>
        /// Command for window loading
        /// </summary>
        public ICommand WindowLoadedCommand
        {
            get;
        }

        /// <summary>
        /// Start of Register transition
        /// Binds to register button
        /// </summary>
        [RelayCommand]
        void Register()
        {
            CreateNewDataContainer();
            AddMetaDataToDataContainer();
            AddSearchAccountDTOToDataContainer();
            SendRequestToNextApplicationLayer();

            GetMessageFromeResponse();
            GetRegisterResult();            

            if (MessageRecivedFromResponse)
            {
                SetNotificationMessage();
            }
        }

        #endregion
    }
}
