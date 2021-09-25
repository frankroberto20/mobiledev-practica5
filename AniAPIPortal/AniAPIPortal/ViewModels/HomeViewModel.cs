using AniAPIPortal.Models;
using AniAPIPortal.Services;
using AniAPIPortal.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AniAPIPortal.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private Anime _selectedAnime;
        private AniAPIService _aniAPIService;

        public Anime SelectedAnime
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
        public ObservableCollection<Anime> Animes { get; } = new ObservableCollection<Anime>();

        async void OnRefresh()
        {
            IsRefreshing = true;
            Animes.Clear();
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var response = await _aniAPIService.GetAnimesAsync();
                var animes = response.Data.Animes;
                foreach (var anime in animes)
                {
                    Animes.Add(anime);
                }
            } 
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "No Internet connection. Try again later.", "Ok");
            }
            IsRefreshing = false;
        }

        async void OnAnimeSelected(Anime anime)
        {
            await App.Current.MainPage.Navigation.PushAsync(new AnimePage(anime));
        }

        public HomeViewModel(AniAPIService aniAPIService)
        {
            _aniAPIService = aniAPIService;
            var animes = _aniAPIService.GetAnimesAsync().Result.Data.Animes;
            foreach (var anime in animes)
            {
                Animes.Add(anime);
            }
            RefreshCommand = new Command(OnRefresh);
            SelectedMailCommand = new Command<Anime>(OnAnimeSelected);
        }
    }
}
