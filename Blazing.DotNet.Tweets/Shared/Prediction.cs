namespace Blazing.DotNet.Tweets.Shared
{
    public class Prediction
    {
        // 0 = bad, 1 = good
        public float Probability { get; set; }

        public float Percentage => Probability * 100;
    }
}
