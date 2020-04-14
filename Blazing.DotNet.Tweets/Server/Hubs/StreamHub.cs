using Blazing.DotNet.Tweets.Server.Services;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazing.DotNet.Tweets.Server.Hubs
{
    public class StreamHub : Hub<ITwitterClient>
    {
        readonly ITwitterService<StreamHub> _twitterService;

        public StreamHub(ITwitterService<StreamHub> twitterService) =>
            _twitterService = twitterService;

        public void RemoveTrack(string track) =>
            _twitterService.RemoveTrack(track);

        public void AddTracks(ISet<string> tracks) =>
            _twitterService.AddTracks(tracks);

        public Task StartStream() =>
            _twitterService.StartTweetStreamAsync();

        public void PauseStream() =>
            _twitterService.PauseTweetStream();

        public void StopStream() =>
            _twitterService.StopTweetStream();
    }
}
