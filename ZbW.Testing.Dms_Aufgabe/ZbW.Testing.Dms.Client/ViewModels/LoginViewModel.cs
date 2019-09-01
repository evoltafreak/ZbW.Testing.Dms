using ZbW.Testing.Dms.Client.Views;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;

namespace ZbW.Testing.Dms.Client.ViewModels
{

    internal class LoginViewModel : BindableBase
    {
        private readonly LoginView _loginView;

        private string _benutzername;

        public LoginViewModel(LoginView loginView)
        {
            _loginView = loginView;
            CmdLogin = new DelegateCommand(OnCmdLogin, OnCanLogin);
            CmdAbbrechen = new DelegateCommand(OnCmdAbbrechen);
        }

        public DelegateCommand CmdAbbrechen { get; }

        public DelegateCommand CmdLogin { get; }

        public string Benutzername
        {
            get
            {
                return _benutzername;
            }

            set
            {
                if (SetProperty(ref _benutzername, value))
                {
                    CmdLogin.RaiseCanExecuteChanged();
                }
            }
        }

        public bool OnCanLogin()
        {
            return !string.IsNullOrEmpty(Benutzername);
        }

        public void OnCmdAbbrechen()
        {
            Application.Current.Shutdown();
        }

        public void OnCmdLogin()
        {
            if (string.IsNullOrEmpty(Benutzername))
            {
                MessageBox.Show("Bitte tragen Sie einen Benutzernamen ein...");
                return;
            }

            var searchView = new MainView(Benutzername);
            searchView.Show();

            _loginView.Close();
        }
    }
}