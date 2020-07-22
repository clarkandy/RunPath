using RunPath.Test.Core.Infrastructure;
using RunPath.Test.Core.Typicode;
using System;
using System.Threading.Tasks;

namespace RunPath.Test.TypiCode
{
    public abstract class TypiCodeClient
    {
        private readonly ITypiCodeConnectionSettings _connectionSettings;

        private readonly IWebClient _webClient;

        private readonly IJsonDeserializer _jsonDeserializer;

        public abstract string RelativePath { get; }

        public TypiCodeClient(ITypiCodeConnectionSettings connectionSettings, IWebClient webClient, IJsonDeserializer jsonDeserializer)
        {
            _connectionSettings = connectionSettings;
            _webClient = webClient;
            _jsonDeserializer = jsonDeserializer;
        }

        protected async Task<T> Get<T>(string queryPath = null)
        {
            string uri = new Uri(BuildUrl(), queryPath).ToString();

            return await _jsonDeserializer.DeserializeAsync<T>(await _webClient.DownloadAsync(uri));
        }

        private Uri BuildUrl()
            => new Uri(new Uri(_connectionSettings.Url), RelativePath);
    }
}
