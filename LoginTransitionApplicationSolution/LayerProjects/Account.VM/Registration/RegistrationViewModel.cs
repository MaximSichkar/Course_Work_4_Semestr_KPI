using Account.MOD;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace Account.VM
{
    public partial class RegistrationViewModel : ObservableObject
    {
        #region Constructors

        /// <summary>
        /// DI
        /// </summary>
        /// <param name="loggingTransitionHandler"></param>
        public RegistrationViewModel(Account.BL.IRegistrationTransitionHandler registrationTransitionHandler)
        {
            WindowLoadedCommand = new RelayCommand(OnWindowLoaded);
            AccountModel = new AccountModel();
            RegisterTransitionHandler = registrationTransitionHandler;
        }

        #endregion

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

        [ObservableProperty]
        AccountModel accountModel = default!;

        /// <summary>
        /// Start of Register transition
        /// Binds to register button
        /// </summary>
        [RelayCommand]
        void Register()
        {
            CreateNewDataContainer();
            AddMetaDataToDataContainer();
            AddSearchAccountDTOToRequest();
            SendRequestToApplicationNextLayer();
            GetRegisterResult();
            GetMessageFromeResponse();
            if (MessageRecivedFromResponse)
            {
                SetNotificationMessage();
            }
        }

        #endregion
    }
}
