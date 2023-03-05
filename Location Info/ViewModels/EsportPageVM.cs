using Location_Info.Info;
using Location_Info.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
enum Site
{
    First,
    Previous,
    Next,
    Last
}
namespace Location_Info.ViewModels
{
    public class EsportPageVM : ViewModel
    {
        private Database _database = ServiceContainer.GetService<Database>();
        private EsportApiService _esportApiService;

        #region pagination
        private int _resultsPerPage = 20;
        private int _actualRangeStart = 0;
        private int _actualRangeStop;
        private int _actualSite;
        private int _countOfSites;
        private string _siteOfSites;
        public string SiteOfSites { get { return _siteOfSites; } set { _siteOfSites = value; OnPropertyChanged(); } }
        public ICommand FirstSiteCommand { get { return new RelayCommand(FirstSite); } }
        public ICommand PreviousSiteCommand { get { return new RelayCommand(PreviousSite); } }
        public ICommand NextSiteCommand { get { return new RelayCommand(NextSite); } }
        public ICommand LastSiteCommand { get { return new RelayCommand(LastSite); } }
        public ICommand SortCommand { get; set; }
        private void FirstSite(object obj) { UpdateRange(Site.First); UpdateSites(); }
        private void PreviousSite(object obj) { UpdateRange(Site.Previous); UpdateSites(); }
        private void NextSite(object obj) { UpdateRange(Site.Next); UpdateSites(); }
        private void LastSite(object obj) { UpdateRange(Site.Last); UpdateSites(); }
        private void UpdateSites()
        {

            if (EsportInfo != null)
            {
                _actualSite = Convert.ToInt32(_actualRangeStart / _resultsPerPage);
                _countOfSites = Convert.ToInt32(EsportInfo.Count / _resultsPerPage);
                if (EsportInfo.Count % _resultsPerPage != 0) { _countOfSites++; }
                SiteOfSites = _actualSite + 1 + " of " + _countOfSites;

            }
        }
        private void UpdateRange(Site site)
        {
            if (EsportInfo != null)
            {
                switch (site)
                {
                    case Site.First:
                        _actualRangeStart = 0;
                        _actualRangeStop = _actualRangeStart + _resultsPerPage;
                        break;
                    case Site.Previous:
                        if (_actualRangeStart - _resultsPerPage < 0) { _actualRangeStart = 0; _actualRangeStop += _resultsPerPage; break; }
                        _actualRangeStart -= _resultsPerPage;
                        _actualRangeStop = _actualRangeStart + _resultsPerPage;
                        break;
                    case Site.Next:
                        if (_actualRangeStart + _resultsPerPage > EsportInfo.Count) { break; }
                        _actualRangeStart += _resultsPerPage;
                        _actualRangeStop += _actualRangeStart + _resultsPerPage;
                        break;
                    case Site.Last:
                        _actualRangeStart = _resultsPerPage * Convert.ToInt32(EsportInfo.Count / _resultsPerPage);
                        _actualRangeStop = _actualRangeStart + _resultsPerPage;
                        break;
                }
                PartiedEsportInfo = new ObservableCollection<EsportInfo>(EsportInfo.Skip(_actualRangeStart).Take(_resultsPerPage));

            }
        }
        #endregion
        #region collections
        private ObservableCollection<EsportInfo> _esportInfo;
        private ObservableCollection<PlayerInfo> _playerInfo;
        private List<EsportMatchesInfo> _esportMatchesInfo;
        private ObservableCollection<EsportInfo> _partiedEsportInfo;
        public ObservableCollection<EsportInfo> PartiedEsportInfo { get { return _partiedEsportInfo; } set { _partiedEsportInfo = value; OnPropertyChanged(); UpdateSites(); } }
        public List<EsportMatchesInfo> EsportMatchesInfo { get { return _esportMatchesInfo; } set { _esportMatchesInfo = value; OnPropertyChanged(); } }
        public ObservableCollection<EsportInfo> EsportInfo { get { return _esportInfo; } set { _esportInfo = value; OnPropertyChanged(); OnPropertyChanged(nameof(PartiedEsportInfo)); } }
        public ObservableCollection<PlayerInfo> PlayerInfo { get { return _playerInfo; } set { _playerInfo = value; OnPropertyChanged(); } }
        #endregion

        public EsportPageVM(EsportApiService esportApiService)
        {
            _esportApiService = esportApiService;
            _database.DataChanged += RefreshData;
            SortCommand = new RelayCommand(Sort);

        }
        private void Sort(object obj)
        {
            var args = (SelectionChangedEventArgs)obj;
            var item = (ComboBoxItem)args.AddedItems[0];
            var name = item.Tag.ToString();
            switch (name)
            {
                case "Name (A-Z)":
                    EsportInfo = new ObservableCollection<EsportInfo>(this.EsportInfo.OrderBy(x => x.Name));
                    PartCollection();
                    break;
                case "Name (Z-A)":
                    EsportInfo = new ObservableCollection<EsportInfo>(this.EsportInfo.OrderByDescending(x => x.Name));
                    PartCollection();
                    break;
                case "Game (A-Z)":
                    this.EsportInfo = new ObservableCollection<EsportInfo>(this.EsportInfo.OrderBy(x => x.GameName));
                    PartCollection();
                    break;
                case "Game (Z-A)":
                    this.EsportInfo = new ObservableCollection<EsportInfo>(this.EsportInfo.OrderByDescending(x => x.GameName));
                    PartCollection();
                    break;
                case "Updated (newest)":
                    this.EsportInfo = new ObservableCollection<EsportInfo>(this.EsportInfo.OrderByDescending(x => x.Updated));
                    PartCollection();
                    break;
                case "Updated (oldest)":
                    this.EsportInfo = new ObservableCollection<EsportInfo>(this.EsportInfo.OrderBy(x => x.Updated));
                    PartCollection();
                    break;
            }
        }
        private void PartCollection()
        {
            PartiedEsportInfo = new ObservableCollection<EsportInfo>(EsportInfo?.Skip(_actualRangeStart)?.Take(_actualRangeStart + _resultsPerPage));
        }

        private async void RefreshData(string datatype)
        {
            switch (datatype)
            {
                case "All":
                    this.PlayerInfo = _database.PlayerInfo;
                    this.EsportInfo = _database.EsportInfo;
                    this.EsportMatchesInfo = _database.EsportMatchesInfo;
                    PartCollection();
                    break;
                case "EsportMatchesInfo":
                    this.EsportMatchesInfo = _database.EsportMatchesInfo;
                    break;
                case "EsportInfo":
                    this.EsportInfo = _database.EsportInfo;
                    PartCollection();
                    break;
                case "PlayerInfo":
                    this.PlayerInfo = _database.PlayerInfo;
                    break;

            }

        }

    }
}
