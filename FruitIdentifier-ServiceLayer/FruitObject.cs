using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FruitIdentifier_ServiceLayer
{
    public class Nutritions
    {
        public int Calories { get; set; }
        public double Fat { get; set; }
        public double Sugar { get; set; }
        public double Carbohydrates { get; set; }
        public double Protein { get; set; }
    }
    public class FruitObject
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Family { get; set; }
        public string Order { get; set; }
        public string Genus { get; set; }
        [JsonPropertyName("nutritions")]
        public Nutritions FruitNutritions { get; set; } = new();
    }
}
