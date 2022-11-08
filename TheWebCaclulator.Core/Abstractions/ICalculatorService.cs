using TheWebCalculator.Core.DataTransferObjects;

namespace TheWebCalculator.Core.Abstractions;

public interface ICalculatorService
{
    decimal AddDigitToNumber(byte digital, decimal number, bool isPointExist);
    decimal InvertNumberSign(decimal number);
    MathExpressionDto AddPoint(MathExpressionDto dto);
    MathExpressionDto AddAdditionOperation(MathExpressionDto dto);
    MathExpressionDto AddSubtractionOperation(MathExpressionDto dto);
    MathExpressionDto AddMultiplicationOperation(MathExpressionDto dto);
    MathExpressionDto AddDivisionOperation(MathExpressionDto dto);
    MathExpressionDto CalculateExpression(MathExpressionDto dto);
    decimal AddNumberToMemory(MathExpressionDto dto);
    decimal SubtractNumberFromMemory(MathExpressionDto dto);
    MathExpressionDto MemoryClean(MathExpressionDto dto);
    decimal MemoryRead(MathExpressionDto dto);
}