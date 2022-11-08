namespace TheWebCalculator.Core.DataTransferObjects;

public class MathExpressionDto
{
    public decimal PreviousNumber { get; set; }
    public decimal CurrentNumber { get; set; }
    public MathOperation Operation { get; set; }
    public string? DisplayMessage { get; set; }
    public PointState PointState { get; set; }
    public decimal Memory { get; set; }
    public byte NumberOfInitiatingFractionalZeros { get; set; }
}