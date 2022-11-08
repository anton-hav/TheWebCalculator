using AutoMapper;
using TheWebCalculator.Core.DataTransferObjects;
using TheWebCalculator.Models;

namespace TheWebCalculator.MappingProfiles;

public class MathExpressionProfile : Profile
{
    public MathExpressionProfile()
    {
        CreateMap<MathExpressionDto, CalculatorModel>();
        CreateMap<CalculatorModel, MathExpressionDto>();
    }
}