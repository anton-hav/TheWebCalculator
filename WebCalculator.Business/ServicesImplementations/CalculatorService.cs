using TheWebCalculator.Core;
using TheWebCalculator.Core.Abstractions;
using TheWebCalculator.Core.DataTransferObjects;

namespace WebCalculator.Business.ServicesImplementations;

public class CalculatorService : ICalculatorService
{
    public decimal AddDigitToNumber(byte digit, decimal number, bool isPointExist)
    {
        var maxValue = (decimal)Math.Pow(10, 27);

        if (number >= maxValue || number <= -maxValue) return number;

        if (isPointExist)
        {
            var fractionalPart = number % 1;

            if (fractionalPart == 0)
            {
                number = number + (decimal)digit / 10;
            }
            else
            {
                // It is the same that var scale = fractionPart.ToString().Length - 2
                var fractionPartScale = (byte)((decimal.GetBits(fractionalPart)[3] >> 16) & 0x7F);
                fractionPartScale++;

                number = number < 0
                    ? number - (decimal)(digit * Math.Pow(10, -fractionPartScale))
                    : number + (decimal)(digit * Math.Pow(10, -fractionPartScale));
            }
        }
        else
        {
            number = number < 0
                ? number * 10 - digit
                : number * 10 + digit;
        }

        return number;
    }

    public decimal InvertNumberSign(decimal number)
    {
        //todo: perhaps a multiplication of the number and (-1) is better way?
        var parts = decimal.GetBits(number);
        var sign = (parts[3] & 0x80000000) != 0;
        sign = !sign;
        var scale = (byte)((parts[3] >> 16) & 0x7F);
        number = new decimal(parts[0], parts[1], parts[2], sign, scale);

        return number;
    }

    public MathExpressionDto AddPoint(MathExpressionDto dto)
    {
        if (!dto.IsPointExist) dto.IsPointExist = true;
        return dto;
    }


    public MathExpressionDto AddAdditionOperation(MathExpressionDto dto)
    {
        dto.PreviousNumber = Calculate(dto);
        dto.CurrentNumber = 0;
        dto.Operation = MathOperation.Addition;

        return dto;
    }

    public MathExpressionDto AddSubtractionOperation(MathExpressionDto dto)
    {
        dto.PreviousNumber = Calculate(dto);
        dto.CurrentNumber = 0;
        dto.Operation = MathOperation.Subtraction;

        return dto;
    }

    public MathExpressionDto AddMultiplicationOperation(MathExpressionDto dto)
    {
        dto.PreviousNumber = Calculate(dto);
        dto.CurrentNumber = 0;
        dto.Operation = MathOperation.Multiplication;

        return dto;
    }

    public MathExpressionDto AddDivisionOperation(MathExpressionDto dto)
    {
        dto.PreviousNumber = Calculate(dto);
        dto.CurrentNumber = 0;
        dto.Operation = MathOperation.Division;

        return dto;
    }

    public MathExpressionDto CalculateExpression(MathExpressionDto dto)
    {
        return new MathExpressionDto
        {
            PreviousNumber = dto.CurrentNumber,
            CurrentNumber = Calculate(dto),
            Operation = MathOperation.None,
            Memory = dto.Memory
        };
    }

    public decimal AddNumberToMemory(MathExpressionDto dto)
    {
        if (decimal.MaxValue - dto.CurrentNumber <= dto.Memory)
            throw new OverflowException("Memory is overflow");

        return dto.Memory + dto.CurrentNumber;
    }

    public decimal SubtractNumberFromMemory(MathExpressionDto dto)
    {
        if (decimal.MinValue + dto.CurrentNumber >= dto.Memory)
            throw new OverflowException("Memory is overflow");

        return dto.Memory + dto.CurrentNumber;
    }

    public MathExpressionDto MemoryClean(MathExpressionDto dto)
    {
        dto.Memory = 0;
        return dto;
    }

    public decimal MemoryRead(MathExpressionDto dto)
    {
        if (dto.Memory >= decimal.MaxValue
            && dto.Memory <= decimal.MinValue)
            throw new OverflowException("Memory is overflow");

        return dto.Memory;
    }

    private decimal Calculate(MathExpressionDto dto)
    {
        return dto.Operation switch
        {
            MathOperation.Addition => dto.CurrentNumber + dto.PreviousNumber,
            MathOperation.Subtraction => dto.PreviousNumber - dto.CurrentNumber,
            MathOperation.Multiplication => dto.CurrentNumber * dto.PreviousNumber,
            MathOperation.Division => dto.CurrentNumber != 0
                ? dto.PreviousNumber / dto.CurrentNumber
                : throw new DivideByZeroException(),
            MathOperation.None => dto.CurrentNumber,
            MathOperation.Result => dto.PreviousNumber,
            _ => throw new ArgumentOutOfRangeException(
                $"Attempting to call a non-existent mathematical operation: {nameof(dto.Operation)}: {dto.Operation}")
        };
    }
}