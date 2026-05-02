using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contracts;
using System.Windows.Input;

namespace Account.VM
{
    /// <summary>
    /// Login View Model, (UI file)
    /// </summary>
    public partial class LoginViewModel : StateHandler
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
        /// Start of Login transition
        /// Binds to login button
        /// </summary>
        [RelayCommand]
        public void Login()
        {
            CreateNewDataContainer();
            AddMetaDataToDataContainer();
            AddSearchAccountDTOToDataContainer();
            SendRequestToNextApplicationLayer();
            GetLoginResult();
            GetMessageFromeResponse();

            if (MessageRecivedFromResponse)
            {
                SetNotificationMessage();
            }

            if (LoginSuccessful)
            {
                CacheAccount();
            }
        }

        #endregion
    }
}
