using System;

namespace ZbW.Testing.Dms.Client.Model
{
    public class MetadataItem
    {
        private string _benutzer;

        private string _bezeichnung;

        private DateTime _erfassungsdatum;

        private string _filePath;

        private bool _isRemoveFileEnabled;

        private string _selectedTypItem;

        private string _stichwoerter;

        private DateTime? _valutaDatum;

        public string Benutzer
        {
            get => _benutzer;
            set => _benutzer = value;
        }

        public string Bezeichnung
        {
            get => _bezeichnung;
            set => _bezeichnung = value;
        }

        public DateTime Erfassungsdatum
        {
            get => _erfassungsdatum;
            set => _erfassungsdatum = value;
        }

        public string FilePath
        {
            get => _filePath;
            set => _filePath = value;
        }

        public bool IsRemoveFileEnabled
        {
            get => _isRemoveFileEnabled;
            set => _isRemoveFileEnabled = value;
        }

        public string SelectedTypItem
        {
            get => _selectedTypItem;
            set => _selectedTypItem = value;
        }

        public string Stichwoerter
        {
            get => _stichwoerter;
            set => _stichwoerter = value;
        }

        public DateTime? ValutaDatum
        {
            get => _valutaDatum;
            set => _valutaDatum = value;
        }
    }
}