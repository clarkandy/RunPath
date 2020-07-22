using System.Threading.Tasks;

namespace RunPath.Test.Core.Infrastructure
{
    public interface IJsonDeserializer
    {
        Task<T> DeserializeAsync<T>(string json);
    }
}
