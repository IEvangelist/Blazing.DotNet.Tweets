using Blazing.DotNet.Tweets.Shared;

namespace Blazing.DotNet.Tweets.Server.Services
{
    public interface ISentimentService
    {
        Prediction Predict(string text);
    }
}
