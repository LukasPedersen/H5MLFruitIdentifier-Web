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
            returnVal += $"{"Class", -20}{"Score",-20}\n";
            returnVal += $"{"--------------------",-20}{"--------------------",-20}\n";

            bool first = true;
            foreach (var score in sortedScoresWithLabel)
            {
                if (score.Value > 0.01)
                {
                    if (first)
                    {
                        if (score.Key == "Rotten")
                        {
                            returnVal += $"This is: {score.Key} \n";
                        }
                        else
                        {
                            returnVal += $"This is a: {score.Key} \n";
                        }

                        first = false;
                    }

                    returnVal += $"{score.Key,-20}: {(score.Value * 100).ToString("00") + "%",-20}\n";
                }
            }
            return returnVal;
        }
    }
}
