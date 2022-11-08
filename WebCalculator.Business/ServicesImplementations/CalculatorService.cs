using System.Globalization;
using TheWebCalculator.Core;
using TheWebCalculator.Core.Abstractions;
using TheWebCalculator.Core.DataTransferObjects;

namespace WebCalculator.Business.ServicesImplementations;

public class CalculatorService : ICalculatorService
{
    public MathExpressionDto AddDigitToNumber(byte digit, MathExpressionDto dto)
    {
        if (dto.Operation.Equals(MathOperation.Result))
        {
            dto.PreviousNumber = 0;
            dto.CurrentNumber = 0;
            dto.Operation = MathOperation.None;
        }

        var maxValue = (decimal)Math.Pow(10, 27);

        if (dto.CurrentNumber >= maxValue || dto.CurrentNumber <= -maxValue) return dto;

        if (dto.IsPointExist)
        {
            var fractionalPart = dto.CurrentNumber % 1;

            if (fractionalPart == 0)
            {
                dto.CurrentNumber = dto.CurrentNumber + (decimal)digit / 10;
            }
            else
            {
                // It is the same that var scale = fractionPart.ToString().Length - 2
                var fractionPartScale = (byte)((decimal.GetBits(fractionalPart)[3] >> 16) & 0x7F);
                fractionPartScale++;

                dto.CurrentNumber = dto.CurrentNumber < 0
                    ? dto.CurrentNumber - (decimal)(digit * Math.Pow(10, -fractionPartScale))
                    : dto.CurrentNumber + (decimal)(digit * Math.Pow(10, -fractionPartScale));
            }
        }
        else
        {
            dto.CurrentNumber = dto.CurrentNumber < 0
                ? dto.CurrentNumber * 10 - digit
                : dto.CurrentNumber * 10 + digit;
        }

        return dto;
    }

    public MathExpressionDto InvertNumberSign(MathExpressionDto dto)
    {
        if (dto.Operation.Equals(MathOperation.Result))
        {
            dto.PreviousNumber = 0;
            dto.Operation = MathOperation.None;
        }
        //todo: perhaps a multiplication of the number and (-1) is better way?
        var parts = decimal.GetBits(dto.CurrentNumber);
        var sign = (parts[3] & 0x80000000) != 0;
        sign = !sign;
        var scale = (byte)((parts[3] >> 16) & 0x7F);
        dto.CurrentNumber = new decimal(parts[0], parts[1], parts[2], sign, scale);

        return dto;
    }

    public MathExpressionDto AddPoint(MathExpressionDto dto)
    {
        if (dto.Operation.Equals(MathOperation.Result))
        {
            dto.PreviousNumber = 0;
            dto.CurrentNumber = 0;
            dto.Operation = MathOperation.None;
        }

        if (!dto.IsPointExist) dto.IsPointExist = true;
        return dto;
    }


    public MathExpressionDto AddAdditionOperation(MathExpressionDto dto)
    {
        dto.PreviousNumber = Calculate(dto);
        dto.CurrentNumber = 0;
        dto.Operation = MathOperation.Addition;
        dto.IsPointExist = false;

        return dto;
    }

    public MathExpressionDto AddSubtractionOperation(MathExpressionDto dto)
    {
        dto.PreviousNumber = Calculate(dto);
        dto.CurrentNumber = 0;
        dto.Operation = MathOperation.Subtraction;
        dto.IsPointExist = false;

        return dto;
    }

    public MathExpressionDto AddMultiplicationOperation(MathExpressionDto dto)
    {
        dto.PreviousNumber = Calculate(dto);
        dto.CurrentNumber = 0;
        dto.Operation = MathOperation.Multiplication;
        dto.IsPointExist = false;

        return dto;
    }

    public MathExpressionDto AddDivisionOperation(MathExpressionDto dto)
    {
        dto.PreviousNumber = Calculate(dto);
        dto.CurrentNumber = 0;
        dto.Operation = MathOperation.Division;
        dto.IsPointExist = false;

        return dto;
    }

    public MathExpressionDto CalculateExpression(MathExpressionDto dto)
    {
        var result = Calculate(dto);
        return new MathExpressionDto
        {
            PreviousNumber = dto.CurrentNumber,
            CurrentNumber = result,
            Operation = MathOperation.Result,
            Memory = dto.Memory,
            DisplayMessage = result
                .ToString("##,##0.############################", CultureInfo.InvariantCulture)
        };
    }

    public MathExpressionDto AddNumberToMemory(MathExpressionDto dto)
    {
        if (decimal.MaxValue - dto.CurrentNumber <= dto.Memory)
            throw new OverflowException("Memory is overflow");

        dto.Memory += dto.CurrentNumber;

        return dto;
    }

    public MathExpressionDto SubtractNumberFromMemory(MathExpressionDto dto)
    {
        if (decimal.MinValue + dto.CurrentNumber >= dto.Memory)
            throw new OverflowException("Memory is overflow");

        dto.Memory -= dto.CurrentNumber;

        return dto;
    }

    public MathExpressionDto MemoryClean(MathExpressionDto dto)
    {
        dto.Memory = 0;
        return dto;
    }

    public MathExpressionDto MemoryRead(MathExpressionDto dto)
    {
        if (dto.Memory >= decimal.MaxValue
            && dto.Memory <= decimal.MinValue)
            throw new OverflowException("Memory is overflow");

        dto.CurrentNumber = dto.Memory;

        return dto;
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