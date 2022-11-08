namespace TheWebCalculator.Core.DataTransferObjects;

public class MathExpressionDto
{
    public decimal PreviousNumber { get; set; }
    public decimal CurrentNumber { get; set; }
    public MathOperation Operation { get; set; }
    public string? DisplayMessage { get; set; }
    public bool IsPointExist { get; set; }
    public decimal Memory { get; set; }
}