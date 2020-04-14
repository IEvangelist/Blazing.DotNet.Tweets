using Blazing.DotNet.Tweets.Shared;
using System.Threading.Tasks;

namespace Blazing.DotNet.Tweets.Server.Services
{
    public interface ITwitterClient
    {
        Task TweetReceived(TweetResult tweet);

        Task StatusUpdated(Status status);
    }
}
