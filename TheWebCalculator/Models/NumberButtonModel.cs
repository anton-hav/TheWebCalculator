using System.Globalization;

namespace TheWebCalculator.Models;

public class NumberButtonModel
{
    public int Digit { get; set; }

    public CalculatorModel CalculatorModel { get; set; }

    public Dictionary<string, string> ToDictionary()
    {
        var routeDictionary = CalculatorModel.ToDictionary();
        routeDictionary.Add(nameof(Digit), Digit.ToString(CultureInfo.InvariantCulture));

        return routeDictionary;
    }
}