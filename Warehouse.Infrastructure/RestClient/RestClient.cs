using System.Text.Json;

namespace Warehouse.Infrastructure.RestClient
{
    public class RestClient<TResource, TIdentifier> : IDisposable where TResource : class
    {
        private HttpClient httpClient;
        protected readonly string _baseAddress;
        private readonly string _addressSuffix;
        private bool disposed = false;

        public RestClient(string baseAddress, string addressSuffix = "")
        {
            _baseAddress = baseAddress;
            _addressSuffix = addressSuffix;
            httpClient = CreateHttpClient(_baseAddress);
        }
        protected virtual HttpClient CreateHttpClient(string serviceBaseAddress)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(serviceBaseAddress);
            return httpClient;
        }
        public async Task<TResource?> GetAsync(TIdentifier identifier)
        {
            var responseMessage = await httpClient.GetAsync(_addressSuffix + identifier.ToString());
            responseMessage.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<TResource>(await responseMessage.Content.ReadAsStringAsync());
        }
        public async Task<IEnumerable<TResource?>?> GetAll()
        {
            var responseMessage = await httpClient.GetAsync(_addressSuffix);
            responseMessage.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize< IEnumerable<TResource>>(await responseMessage.Content.ReadAsStringAsync());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                if (httpClient != null)
                {
                    httpClient.Dispose();
                }
                disposed = true;
            }
        }
    }
}

