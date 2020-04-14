This application was written to demonstrate SignalR with Blazor WebAssembly. It was inspired by the evolution of an earlier project of mine which started with Blazor.Extensions + SignalR, before the .NET client actually worked with Blazor. I later converted the app to no longer rely on Blazor.Extensions but then had to rely on JavaScript, [IEvangelist.BlazoR.TwitterStreaming](https://github.com/IEvangelist/IEvangelist.BlazoR.TwitterStreaming). Now, we're back to a more pure .NET solution... Enjoy!

![Demos](assets/demo-image.png "Demo")

## Accessing Twitter API

In order to access the Twitter API, you need a [Twitter developer account](https://developer.twitter.com/en/apps/create). Then you will need to specify several environment variables in order for this application to function appropriately.

- `Authentication__Twitter__AccessToken`
- `Authentication__Twitter__AccessTokenSecret`
- `Authentication__Twitter__ConsumerKey`
- `Authentication__Twitter__ConsumerSecret`
