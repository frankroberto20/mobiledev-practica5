using AniAPIPortal.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AniAPIPortal.Services
{
    public class AniAPIService
    {
        private IAniAPI _aniApi;
        private JsonSerializerService _serializer;
        public AniAPIService()
        {
            _aniApi = RestService.For<IAniAPI>("https://api.aniapi.com");
        }
        public async Task<AnimeList> GetAnimesAsync()
        {

            var response = await _aniApi.GetAnimesAsync();

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                var episodesListResponse = _serializer.Deserialize<AnimeList>(responseString);

                return episodesListResponse;
            }

            return null;
        }
    }
}
