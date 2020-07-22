using RunPath.Test.Core.Infrastructure;
using System.Net;
using System.Threading.Tasks;

namespace RunPath.Test.Infrastructure
{
    public class WebClientWrapper : IWebClient
    {
        public async Task<string> DownloadAsync(string address)
        {
            using (WebClient webClient = new WebClient())
                return await webClient.DownloadStringTaskAsync(address);
        }
    }
}
