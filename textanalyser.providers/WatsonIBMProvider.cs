using System.Linq;
using System.Collections.Generic;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1.Model;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1;
using IBM.WatsonDeveloperCloud.Util;
using textanalyser.infra.common;
using textanalyser.domain.core;
using System;
using System.Threading.Tasks;

namespace textanalyser.providers
{
    public class WatsonIBMProvider : IWatsonIBMProvider
    {
        private NaturalLanguageUnderstandingService _service;

        public WatsonIBMProvider(AppSettings appSettings)
        {
            var token = new TokenOptions() { IamApiKey = appSettings.WatsonApiKey() };
            _service = new NaturalLanguageUnderstandingService(token, appSettings.WatsonVersionDate());
            _service.SetEndpoint(appSettings.WatsonUrl());
        }

        public Task<WatsonReponse> LoadWatsonFromUrl(string url)
        {
            var parameters = BuildParameters(url: url);
            return Task.Run(() => LoadNaturalLanguageUnderstanding(parameters));
        }

        public Task<WatsonReponse> LoadWatsonFromText(string text)
        {
            var parameters = BuildParameters(text: text);
            return Task.Run(() => LoadNaturalLanguageUnderstanding(parameters));
        }

        private static Parameters BuildParameters(string url = null, string text = null)
        {
            var features = BuildWatsonFeatures();

            var parameters = new Parameters();
            parameters.Features = features;
            parameters.ReturnAnalyzedText = true;

            if (!string.IsNullOrEmpty(url))
                parameters.Url = url;

            if (!string.IsNullOrEmpty(text))
                parameters.Text = text;

            return parameters;
        }

        private WatsonReponse LoadNaturalLanguageUnderstanding(Parameters parameters)
        {
            try
            {
                var result = _service.Analyze(parameters);
                return CreteWatsonCustomResponse(result);
            }
            catch (Exception ex)
            {
                return new WatsonReponse() { ErrorMessage = ex.Message };
            }
        }

        private static Features BuildWatsonFeatures()
        {
            return new Features()
            {
                Emotion = new EmotionOptions() { Document = true },
                Sentiment = new SentimentOptions() { Document = true },
                Categories = new CategoriesOptions() { Limit = 5 },
                Keywords = new KeywordsOptions()
                {
                    Sentiment = true,
                    Emotion = true
                }
            };
        }

        private static WatsonReponse CreteWatsonCustomResponse(AnalysisResults result)
        {
            var emotions = GetEmotionsFromResult(result);
            var categories = GetCategoriesFromResult(result);
            var sentiment = GetSentimentFromResult(result);
            var keywords = GetKeywordsFromResult(result);

            return new WatsonReponse()
            {
                AnalyzedText = result.AnalyzedText,
                Sentiment = sentiment,
                Keywords = keywords,
                Emotions = emotions,
                Categories = categories
            };
        }

        private static Dictionary<string, double> GetEmotionsFromResult(AnalysisResults result)
        {
            var emotions = new Dictionary<string, double>();

            if (result != null 
                && result.Emotion != null 
                && result.Emotion.Document != null 
                && result.Emotion.Document.Emotion != null)
            {
                emotions.Add("Sadness", result.Emotion.Document.Emotion.Sadness.GetValueOrDefault());
                emotions.Add("Joy", result.Emotion.Document.Emotion.Joy.GetValueOrDefault());
                emotions.Add("Fear", result.Emotion.Document.Emotion.Fear.GetValueOrDefault());
                emotions.Add("Disgust", result.Emotion.Document.Emotion.Disgust.GetValueOrDefault());
                emotions.Add("Anger", result.Emotion.Document.Emotion.Anger.GetValueOrDefault());
            }

            return emotions;
        }

        private static List<string> GetCategoriesFromResult(AnalysisResults result)
        {
            return result.Categories?
                .Select(x => x.Label)
                .ToList();
        }

        private static Dictionary<string, double> GetSentimentFromResult(AnalysisResults result)
        {
            return new Dictionary<string, double>()
            {
                {result.Sentiment.Document.Label, result.Sentiment.Document.Score.GetValueOrDefault()}
            };
        }

        private static Dictionary<string, double> GetKeywordsFromResult(AnalysisResults result)
        {
            return result.Keywords?
                .ToDictionary(x => x.Text, x => x.Relevance.GetValueOrDefault());
        }
    }
}