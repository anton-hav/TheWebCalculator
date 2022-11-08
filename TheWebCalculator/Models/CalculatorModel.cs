using System.Globalization;
using TheWebCalculator.Core;

namespace TheWebCalculator.Models;

public class CalculatorModel
{
    public decimal PreviousNumber { get; set; }
    public decimal CurrentNumber { get; set; }
    public MathOperation Operation { get; set; }
    public string? DisplayMessage { get; set; }
    public PointState PointState { get; set; }
    public decimal Memory { get; set; }
    public byte NumberOfInitiatingFractionalZeros { get; set; }

    public Dictionary<string, string> ToDictionary()
    {
        return new Dictionary<string, string>
        {
            { nameof(PreviousNumber), PreviousNumber.ToString(CultureInfo.InvariantCulture) },
            { nameof(CurrentNumber), CurrentNumber.ToString(CultureInfo.InvariantCulture) },
            { nameof(Operation), Operation.ToString() },
            { nameof(PointState), PointState.ToString() },
            { nameof(Memory), Memory.ToString(CultureInfo.InvariantCulture) },
            { nameof(NumberOfInitiatingFractionalZeros), NumberOfInitiatingFractionalZeros.ToString(CultureInfo.InvariantCulture) }
        };
    }
}