using ApplicationEvents;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace Account.VM
{
    /// <summary>
    /// Login View Model, (UI file)
    /// </summary>
    public partial class LoginViewModel : ObservableObject
    {
        #region Constructors

        /// <summary>
        /// DI
        /// </summary>
        /// <param name="loggingTransitionHandler"></param>
        public LoginViewModel(Account.BL.ILoggingTransitionHandler loggingTransitionHandler)
        {
            WindowLoadedCommand = new RelayCommand(OnWindowLoaded);
            AccountModel = new AccountModel();
            LoggingTransitionHandler = loggingTransitionHandler;
        }

        public LoginViewModel(ManagmentSystemEvents managmentSystemEvents)
        {
            _managmentSystemEvents = managmentSystemEvents;
        }

        #endregion

        #region Data Fields        

        /// <summary>
        /// Message for notification
        /// </summary>
        [ObservableProperty]
        public string? notificationMessage;

        /// <summary>
        /// 
        /// </summary>
        public readonly ManagmentSystemEvents _managmentSystemEvents;

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
            GoToManagmentSystem();
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
