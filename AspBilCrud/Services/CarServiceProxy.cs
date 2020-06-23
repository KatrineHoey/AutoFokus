using Autofokus.Service.Contracts.DTOs;
using Autofokus.Service.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AspBilCrud.Services
{
    public class CarServiceProxy : ICarService
    {
        private const string _carsRequestUrl = "api/Cars";
        public HttpClient Client { get; }
        public CarServiceProxy(HttpClient client)
        {
            Client = client;
            client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json")
            { Parameters = { new NameValueHeaderValue("v", "1.0") } });
        }


        public async Task AddAsync(CarDto car)
        {
            var json = JsonSerializer.Serialize(car); //Laver et objekt car om til json.
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(_carsRequestUrl, data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        public async Task<CarDto> GetCarAsync(int id)
        {
            var response = await Client.GetAsync($"{_carsRequestUrl}/{id}").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions //Uvælger hvilke propterites som skal være gældene. 
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<CarDto>(stream, options).ConfigureAwait(false); //returnere en strøm af movieDTO'er og de er tællelige.

        }

        public async Task<IEnumerable<CarDto>> GetCarsAsync()
        {
            var response = await Client.GetAsync(_carsRequestUrl).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<IEnumerable<CarDto>>(stream, options).ConfigureAwait(false);
        }

        public async Task RemoveAsync(int id)
        {
            var response = await Client.DeleteAsync($"{_carsRequestUrl}/{id}").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(int id, CarDto car)
        {
            var json = JsonSerializer.Serialize(car);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync($"{_carsRequestUrl}/{id}", data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }
    }
}
