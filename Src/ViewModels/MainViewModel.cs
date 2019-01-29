using System.Windows;
using JoyConsPro.Services.Bluetooth;
using JoyConsPro.Services.Devices;
using JoyConsPro.Src.Commands;

namespace JoyConsPro.ViewModels
{
    class MainViewModel : DependencyObject
    {
        private JoyConsBtService _btService;
        private JoyConsProDevice _joyConsProDevice;

        public FindCommand FindCommand { get; private set; }

        #region Dependency Properties

        public static readonly DependencyProperty LeftJoyConSettingsViewModelProperty = DependencyProperty.Register(
            "LeftJoyConSettingsViewModel", typeof(JoyConSettingsViewModel), typeof(MainViewModel), new PropertyMetadata(default(JoyConSettingsViewModel)));

        public JoyConSettingsViewModel LeftJoyConSettingsViewModel
        {
            get => (JoyConSettingsViewModel) GetValue(LeftJoyConSettingsViewModelProperty);
            set => SetValue(LeftJoyConSettingsViewModelProperty, value);
        }

        public static readonly DependencyProperty RightJoyConSettingsViewModelProperty = DependencyProperty.Register(
            "RightJoyConSettingsViewModel", typeof(JoyConSettingsViewModel), typeof(MainViewModel), new PropertyMetadata(default(JoyConSettingsViewModel)));

        public JoyConSettingsViewModel RightJoyConSettingsViewModel
        {
            get => (JoyConSettingsViewModel) GetValue(RightJoyConSettingsViewModelProperty);
            set => SetValue(RightJoyConSettingsViewModelProperty, value);
        }

        public static readonly DependencyProperty StatusViewModelProperty = DependencyProperty.Register(
            "StatusViewModel", typeof(ControllersStatusViewModel), typeof(MainViewModel), new PropertyMetadata(default(ControllersStatusViewModel)));

        public ControllersStatusViewModel StatusViewModel
        {
            get => (ControllersStatusViewModel) GetValue(StatusViewModelProperty);
            set => SetValue(StatusViewModelProperty, value);
        }

        public static readonly DependencyProperty IsLoadingPopupVisibleProperty = DependencyProperty.Register(
            "IsLoadingPopupVisible", typeof(bool), typeof(MainViewModel), new PropertyMetadata(default(bool)));

        public bool IsLoadingPopupVisible
        {
            get => (bool) GetValue(IsLoadingPopupVisibleProperty);
            set => SetValue(IsLoadingPopupVisibleProperty, value);
        }

        #endregion

        public MainViewModel()
        {
            RightJoyConSettingsViewModel = new JoyConSettingsViewModel();
            LeftJoyConSettingsViewModel = new JoyConSettingsViewModel();
            StatusViewModel = new ControllersStatusViewModel();
            FindCommand = new FindCommand(FindControllers);

            _btService = new JoyConsBtService();

            _joyConsProDevice = new JoyConsProDevice();
        }

        public async void FindControllers()
        {
            IsLoadingPopupVisible = true;
            await _btService.FindControllers();
            IsLoadingPopupVisible = false;
        }
    }
}
