using System.Threading.Tasks;

namespace RunPath.Test.Core.Infrastructure
{
    public interface IWebClient
    {
        Task<string> DownloadAsync(string uri);
    }
}
