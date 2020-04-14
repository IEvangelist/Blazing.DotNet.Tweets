using Blazing.DotNet.Tweets.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazing.DotNet.Tweets.Client.Pages
{
    public class IndexComponent : ComponentBase
    {
        protected string StatusMessage { get; set; }
        protected bool IsStreaming { get; set; }

        protected bool IsConnected => _hubConnection?.State == HubConnectionState.Connected;

        protected readonly List<TweetResult> Tweets = new List<TweetResult>();
        protected readonly ISet<string> Tracks = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "#SignalR",
            "#BlazoR",
            "#DeveloperCommunity",
            "@davidpine7"
        };

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        private HubConnection _hubConnection;

        protected override async Task OnInitializedAsync()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/streamHub"))
                .Build();

            _hubConnection.On<TweetResult>("TweetReceived", tweet =>
            {
                Tweets.Add(tweet);
                StateHasChanged();

                // We need to tell the Twitter HTML to render correctly.
                // This is a Twitter thing, not a Blazor thing...
                JSRuntime.InvokeVoidAsync("nudgeTwitterCard");
            });

            _hubConnection.On<Status>("StatusUpdated", status =>
            {
                StatusMessage = status.Message;
                StateHasChanged();
            });

            await _hubConnection.StartAsync();
            await _hubConnection.InvokeAsync("AddTracks", Tracks);
        }

        protected async Task RemoveTrack(string track)
        {
            Tracks.Remove(track);
            StateHasChanged();

            await _hubConnection.InvokeAsync(nameof(RemoveTrack), track);
        }

        protected async Task Start() =>
            await _hubConnection.InvokeAsync("StartStream");

        protected async Task Stop() =>
            await _hubConnection.InvokeAsync("StopStream");

        protected async Task Pause() =>
            await _hubConnection.InvokeAsync("PauseStream");
    }
}