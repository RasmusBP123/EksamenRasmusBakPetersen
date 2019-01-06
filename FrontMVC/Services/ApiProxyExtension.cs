using FrontMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FrontMVC.Services
{
    public class ApiProxyExtension
    {
        private const string baseUrl = "http://localhost:60073/api";

        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            return client;
        }
        public async Task<IEnumerable<Item>> GetAllItems()
        {
            var json = await InitializeClient().GetStringAsync(baseUrl);
            var content = JsonConvert.DeserializeObject<List<Item>>(json);

            return content;
        }

        public async Task<bool> LoadItemToApi(ItemForCreationDTO item)
        {
            var json = JsonConvert.SerializeObject(item);

            var content = new StringContent(json, Encoding.Unicode, "application/json");

            var response = await InitializeClient().PostAsync($"{baseUrl}/{item}", content);

            return response.IsSuccessStatusCode;
        }


    }
}
