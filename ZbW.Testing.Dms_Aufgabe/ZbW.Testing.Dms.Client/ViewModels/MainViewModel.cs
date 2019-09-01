using System.Windows.Controls;
using Prism.Commands;
using Prism.Mvvm;
using ZbW.Testing.Dms.Client.Views;

namespace ZbW.Testing.Dms.Client.ViewModels
{

    internal class MainViewModel : BindableBase
    {
        private string _benutzer;

        private UserControl _content;

        public MainViewModel(string benutzername)
        {
            Benutzer = benutzername;
            CmdNavigateToSearch = new DelegateCommand(OnCmdNavigateToSearch);
            CmdNavigateToDocumentDetail = new DelegateCommand(OnCmdNavigateToDocumentDetail);
        }

        public string Benutzer
        {
            get
            {
                return _benutzer;
            }

            set
            {
                SetProperty(ref _benutzer, value);
            }
        }

        public UserControl Content
        {
            get
            {
                return _content;
            }

            set
            {
                SetProperty(ref _content, value);
            }
        }

        public DelegateCommand CmdNavigateToSearch { get; }

        public DelegateCommand CmdNavigateToDocumentDetail { get; }

        public void OnCmdNavigateToSearch()
        {
            NavigateToSearch();
        }

        public void OnCmdNavigateToDocumentDetail()
        {
            Content = new DocumentDetailView(Benutzer, NavigateToSearch);
        }

        private void NavigateToSearch()
        {
            Content = new SearchView();
        }
    }
}