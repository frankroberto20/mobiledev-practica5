using AniAPIPortal.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AniAPIPortal.Services
{
    public interface IAniAPI
    {
        [Get("/v1/anime?per_page={limit}")]
        Task<HttpResponseMessage> GetAnimesAsync(int limit);
    }
}
