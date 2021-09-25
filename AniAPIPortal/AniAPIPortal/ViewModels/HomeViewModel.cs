using AniAPIPortal.Models;
using AniAPIPortal.Services;
using AniAPIPortal.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AniAPIPortal.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private Document _selectedAnime;
        private AniAPIService _aniAPIService;

        public Document SelectedAnime
        {
            get => _selectedAnime;
            set
            {
                _selectedAnime = value;
                if (_selectedAnime != null)
                {
                    SelectedMailCommand.Execute(_selectedAnime);
                }
            }
        }
        public bool IsRefreshing { get; set; }
        public ICommand RefreshCommand { get; }
        public ICommand ComposeCommand { get; }
        public ICommand DeleteCommand { get; }
        private ICommand SelectedMailCommand { get; }
        public ObservableCollection<Document> Animes { get; } = new ObservableCollection<Document>();

        async void OnRefresh()
        {
            IsRefreshing = true;
            Animes.Clear();
            var response = await _aniAPIService.GetAnimesAsync();
            var animes = response.Data.Documents;
            foreach (var anime in animes)
            {
                Animes.Add(anime);
            }
            IsRefreshing = false;
        }

        async void OnAnimeSelected(Document anime)
        {
            await App.Current.MainPage.Navigation.PushAsync(new AnimePage(anime));
        }

        public HomeViewModel(AniAPIService aniAPIService)
        {
            _aniAPIService = aniAPIService;
            RefreshCommand = new Command(OnRefresh);
            SelectedMailCommand = new Command<Document>(OnAnimeSelected);
        }
    }
}
