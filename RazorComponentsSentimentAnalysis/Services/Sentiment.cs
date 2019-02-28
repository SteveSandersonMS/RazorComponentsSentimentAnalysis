using Microsoft.ML.Legacy;

namespace RazorComponentsSentimentAnalysis.Services
{
    // Model input
    public class SourceData
    {
        public string SentimentText { get; set; }
    }

    // Model output
    public class Prediction
    {
        public float Probability { get; set; } // 0=bad, 1=good
        public float Percentage => Probability * 100;
    }

    public static class Sentiment
    {
        static PredictionModel<SourceData, Prediction> model
            = PredictionModel.ReadAsync<SourceData, Prediction>("SentimentModel.zip").Result;

        public static Prediction Predict(string text)
        {
            return model.Predict(new SourceData { SentimentText = text });
        }
    }
}
