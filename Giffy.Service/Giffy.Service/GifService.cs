using Giffy.Service.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Giffy.Service
{
    public interface IGifService
    {
        Task<List<GifPost>> GetGifs(GetGifRq rq);
        Task<int> GetGifCount();
    }

    public class GifService : IGifService
    {
        private HttpClient client = new HttpClient();

        private string apiUrl = AppSettings.WEB_API_URL + "post/getgags?filter=gif&userFilter=";

        public GifService()
        {
        }

        public Task<int> GetGifCount()
        {
            throw new NotImplementedException();
        }

        public async Task<List<GifPost>> GetGifs(GetGifRq rq)
        {
            var requestUrl = $"{apiUrl}&skip={rq.Skip}&take={rq.Take}";
            var response = await client.GetStringAsync(requestUrl);
            var items = JsonConvert.DeserializeObject<List<GifPost>>(response);

            return items;
        }
    }
}
