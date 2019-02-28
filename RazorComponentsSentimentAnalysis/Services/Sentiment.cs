using System;
using System.IO;
using Microsoft.ML;

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
        static MLContext context = new MLContext();
        static ITransformer model
            = context.Model.Load(File.Open("SentimentModel.zip", FileMode.Open));

        [ThreadStatic]
        static PredictionEngine<SourceData, Prediction> t_engine;

        private static PredictionEngine<SourceData, Prediction> GetPredictionEngine()
        {
            if (t_engine != null)
                return t_engine;

            return t_engine = model.CreatePredictionEngine<SourceData, Prediction>(context);
        }

        public static Prediction Predict(string text)
        {
            var engine = GetPredictionEngine();
            return engine.Predict(new SourceData { SentimentText = text });
        }
    }
}
