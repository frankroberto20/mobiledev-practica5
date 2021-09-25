using AniAPIPortal.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AniAPIPortal.Services
{
    public interface IAniAPIService
    {
        Task<AnimeList> GetAnimesAsync(int limit);
    }
}
