using System;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using ZbW.Testing.Dms.Client.Repositories;

namespace ZbW.Testing.Dms.Client.ViewModels
{

    internal class DocumentDetailViewModel : BindableBase
    {
        private readonly Action _navigateBack;

        private string _benutzer;

        private string _bezeichnung;

        private DateTime _erfassungsdatum;

        private string _filePath;

        private bool _isRemoveFileEnabled;

        private string _selectedTypItem;

        private string _stichwoerter;

        private List<string> _typItems;

        private DateTime? _valutaDatum;

        public DocumentDetailViewModel(string benutzer, Action navigateBack)
        {
            _navigateBack = navigateBack;
            Benutzer = benutzer;
            Erfassungsdatum = DateTime.Now;
            TypItems = ComboBoxItems.Typ;

            CmdDurchsuchen = new DelegateCommand(OnCmdDurchsuchen);
            CmdSpeichern = new DelegateCommand(OnCmdSpeichern);
        }

        public string Stichwoerter
        {
            get { return _stichwoerter; }

            set { SetProperty(ref _stichwoerter, value); }
        }

        public string Bezeichnung
        {
            get { return _bezeichnung; }

            set { SetProperty(ref _bezeichnung, value); }
        }

        public List<string> TypItems
        {
            get { return _typItems; }

            set { SetProperty(ref _typItems, value); }
        }

        public string SelectedTypItem
        {
            get { return _selectedTypItem; }

            set { SetProperty(ref _selectedTypItem, value); }
        }

        public DateTime Erfassungsdatum
        {
            get { return _erfassungsdatum; }

            set { SetProperty(ref _erfassungsdatum, value); }
        }

        public string FilePath
        {
            get { return _filePath; }

            set { SetProperty(ref _filePath, value); }
        }

        public string Benutzer
        {
            get { return _benutzer; }

            set { SetProperty(ref _benutzer, value); }
        }

        public DelegateCommand CmdDurchsuchen { get; }

        public DelegateCommand CmdSpeichern { get; }

        public DateTime? ValutaDatum
        {
            get { return _valutaDatum; }

            set { SetProperty(ref _valutaDatum, value); }
        }

        public bool IsRemoveFileEnabled
        {
            get { return _isRemoveFileEnabled; }

            set { SetProperty(ref _isRemoveFileEnabled, value); }
        }

        public void OnCmdDurchsuchen()
        {
            var openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();

            if (result.GetValueOrDefault())
            {
                _filePath = openFileDialog.FileName;
            }
        }

        public void OnCmdSpeichern()
        {
            try
            {
                if (OnCanSpeichern())
                {
                    XmlService.WriteXML(CreateMetadataItem(), _filePath);
                    if (IsRemoveFileEnabled)
                    {
                        File.Delete(_filePath);
                    }

                    _navigateBack();
                }
                else
                {
                    MessageBox.Show("Es müssen alle Pflichtfelder ausgefüllt werden!", "Pflichtfelder ausfüllen");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Speichern fehlgeschlagen: " + ex.Message, "Speichern fehlgeschlagen");
            }


        }

        private MetadataItem CreateMetadataItem()
        {
            MetadataItem metadataItem = new MetadataItem();
            metadataItem.ValutaDatum = ValutaDatum;
            metadataItem.Benutzer = Benutzer;
            metadataItem.Bezeichnung = Bezeichnung;
            metadataItem.Erfassungsdatum = Erfassungsdatum;
            metadataItem.IsRemoveFileEnabled = IsRemoveFileEnabled;
            metadataItem.SelectedTypItem = SelectedTypItem;
            metadataItem.Stichwoerter = Stichwoerter;
            return metadataItem;
        }

        private bool OnCanSpeichern()
            {
                return !string.IsNullOrEmpty(_filePath)
                       && !string.IsNullOrEmpty(Bezeichnung)
                       && ValutaDatum != null
                       && !string.IsNullOrEmpty(SelectedTypItem);
            }
        }
    }