using System.Diagnostics;
using System.IO;
using ZbW.Testing.Dms.Client.Services;
using System.Collections.Generic;
using Prism.Commands;
using Prism.Mvvm;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Repositories;

namespace ZbW.Testing.Dms.Client.ViewModels
{

    internal class SearchViewModel : BindableBase
    {
        private List<MetadataItem> _filteredMetadataItems;

        private MetadataItem _selectedMetadataItem;

        private string _selectedTypItem;

        private string _suchbegriff;

        private List<string> _typItems;

        public SearchViewModel()
        {
            TypItems = ComboBoxItems.Typ;

            CmdSuchen = new DelegateCommand(OnCmdSuchen);
            CmdReset = new DelegateCommand(OnCmdReset);
            CmdOeffnen = new DelegateCommand(OnCmdOeffnen, OnCanCmdOeffnen);
        }

        public DelegateCommand CmdOeffnen { get; }

        public DelegateCommand CmdSuchen { get; }

        public DelegateCommand CmdReset { get; }

        public string Suchbegriff
        {
            get
            {
                return _suchbegriff;
            }

            set
            {
                SetProperty(ref _suchbegriff, value);
            }
        }

        public List<string> TypItems
        {
            get
            {
                return _typItems;
            }

            set
            {
                SetProperty(ref _typItems, value);
            }
        }

        public string SelectedTypItem
        {
            get
            {
                return _selectedTypItem;
            }

            set
            {
                SetProperty(ref _selectedTypItem, value);
            }
        }

        public List<MetadataItem> FilteredMetadataItems
        {
            get
            {
                return _filteredMetadataItems;
            }

            set
            {
                SetProperty(ref _filteredMetadataItems, value);
            }
        }

        public MetadataItem SelectedMetadataItem
        {
            get
            {
                return _selectedMetadataItem;
            }

            set
            {
                if (SetProperty(ref _selectedMetadataItem, value))
                {
                    CmdOeffnen.RaiseCanExecuteChanged();
                }
            }
        }

        public bool OnCanCmdOeffnen()
        {
            return SelectedMetadataItem != null;
        }

        public void OnCmdOeffnen()
        {
            Process.Start(SelectedMetadataItem.FilePath);
        }

        public void OnCmdSuchen()
        {
            List<MetadataItem> items = new List<MetadataItem>();
            string[] filePaths = Directory.GetFiles(ConfigService.GetConfigValueByKey("RepositoryDir"), "*.xml", SearchOption.AllDirectories);

            string suchbegriff = "";
            if (Suchbegriff != null)
            {
                suchbegriff = Suchbegriff.ToLower();
            }

            string selectedTypItem = "";
            if (SelectedTypItem != null)
            {
                selectedTypItem = SelectedTypItem.ToLower();
            }

            // Minimum one search criteria has to be filled
            if (string.IsNullOrEmpty(suchbegriff) && string.IsNullOrEmpty(selectedTypItem))
            {
                return;
            }
                

            foreach (string filePath in filePaths)
            {
                MetadataItem metadataItem = XmlService.ReadXML(filePath);
                if (metadataItem.SelectedTypItem.ToLower().Contains(selectedTypItem)
                    && (metadataItem.Bezeichnung.ToLower().Contains(suchbegriff) ||
                        metadataItem.Stichwoerter.ToLower().Contains(suchbegriff)))
                {
                    items.Add(metadataItem);
                }
            }
            FilteredMetadataItems = items;
        }

        public void OnCmdReset()
        {
            FilteredMetadataItems = new List<MetadataItem>();
            SelectedTypItem = null;
            Suchbegriff = "";
        }
    }
}