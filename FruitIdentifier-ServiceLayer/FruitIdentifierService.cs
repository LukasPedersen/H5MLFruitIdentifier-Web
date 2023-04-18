using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLIdentifierModel_First;

namespace FruitIdentifier_ServiceLayer
{
    public class FruitIdentifierService : IFruitIdentifierService
    {
        public string GetImagePrediction(string path)
        {
            string returnVal = "";
            // Create single instance of sample data from first line of dataset for model input
            var imageBytes = File.ReadAllBytes(path);
            MLIdentifierModel.ModelInput sampleData = new MLIdentifierModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            // Make a single prediction on the sample data and print results.
            var sortedScoresWithLabel = MLIdentifierModel.PredictAllLabels(sampleData);
            returnVal += $"{"Class",-40}{"Score",-20}\n";
            returnVal += $"{"-----",-40}{"-----",-20}\n";

            foreach (var score in sortedScoresWithLabel)
            {
                returnVal += $"{score.Key,-40}{score.Value,-20}\n";
            }
            return returnVal;
        }
    }
}
