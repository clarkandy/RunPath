using Newtonsoft.Json;
using RunPath.Test.Core.Infrastructure;
using System.Threading.Tasks;

namespace RunPath.Test.Infrastructure
{
    public class JsonDeserializer : IJsonDeserializer
    {
        public async Task<T> DeserializeAsync<T>(string json)
            => await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
    }
}
