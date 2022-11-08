using TheWebCalculator.Core.DataTransferObjects;

namespace TheWebCalculator.Core.Abstractions;

public interface ICalculatorService
{
    MathExpressionDto AddDigitToNumber(byte digital, MathExpressionDto dto);
    MathExpressionDto InvertNumberSign(MathExpressionDto dto);
    MathExpressionDto AddPoint(MathExpressionDto dto);
    MathExpressionDto AddAdditionOperation(MathExpressionDto dto);
    MathExpressionDto AddSubtractionOperation(MathExpressionDto dto);
    MathExpressionDto AddMultiplicationOperation(MathExpressionDto dto);
    MathExpressionDto AddDivisionOperation(MathExpressionDto dto);
    MathExpressionDto CalculateExpression(MathExpressionDto dto);
    MathExpressionDto AddNumberToMemory(MathExpressionDto dto);
    MathExpressionDto SubtractNumberFromMemory(MathExpressionDto dto);
    MathExpressionDto MemoryClean(MathExpressionDto dto);
    MathExpressionDto MemoryRead(MathExpressionDto dto);
}