﻿
// This file was auto-generated by ML.NET Model Builder. 

using MLIdentifierModel_First;
using System.IO;

// Create single instance of sample data from first line of dataset for model input
var imageBytes = File.ReadAllBytes(@"C:\Users\Aramoniax\Desktop\Fruit identifier\FruitIdentifier-Web\FruitIdentifier-Web\Data\Fruit\Apple\1000_F_210597040_wxyvT8wGl322pfG6xO4LGW4FCWTgkOyX.jpg");
MLIdentifierModel.ModelInput sampleData = new MLIdentifierModel.ModelInput()
{
    ImageSource = imageBytes,
};

// Make a single prediction on the sample data and print results.
var sortedScoresWithLabel = MLIdentifierModel.PredictAllLabels(sampleData);
Console.WriteLine($"{"Class",-40}{"Score",-20}");
Console.WriteLine($"{"-----",-40}{"-----",-20}");

foreach (var score in sortedScoresWithLabel)
{
    Console.WriteLine($"{score.Key,-40}{score.Value,-20}");
}
