using Blazing.DotNet.Tweets.Server.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tweetinvi;
using Tweetinvi.Streaming;

namespace Blazing.DotNet.Tweets.Server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazoRTwitterServices<THub>(
            this IServiceCollection services,
            IConfiguration configuration)
            where THub : Hub<ITwitterClient>
        {
            services.AddSignalR(options => options.KeepAliveInterval = TimeSpan.FromSeconds(5));

            Auth.SetUserCredentials(
                configuration["Authentication:Twitter:ConsumerKey"],
                configuration["Authentication:Twitter:ConsumerSecret"],
                configuration["Authentication:Twitter:AccessToken"],
                configuration["Authentication:Twitter:AccessTokenSecret"]);

            return services.AddSingleton<ISentimentService, SentimentService>()
                           .AddSingleton<ITwitterService<THub>, TwitterService<THub>>()
                           .AddHostedService<TwitterService<THub>>()
                           .AddSingleton<IFilteredStream>(_ =>
                           {
                               var stream = Stream.CreateFilteredStream();
                               stream.StallWarnings = true;

                               return stream;
                           });
        }
    }
}
