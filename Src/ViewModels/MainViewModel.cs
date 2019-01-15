using System.Windows;

namespace JoyConsPro.ViewModels
{
    class MainViewModel : DependencyObject
    {
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

        #endregion

        public MainViewModel()
        {
            RightJoyConSettingsViewModel = new JoyConSettingsViewModel();
            LeftJoyConSettingsViewModel = new JoyConSettingsViewModel();
            StatusViewModel = new ControllersStatusViewModel();
        }
    }
}
