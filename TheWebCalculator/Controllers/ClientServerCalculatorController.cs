using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Globalization;
using TheWebCalculator.Core;
using TheWebCalculator.Core.Abstractions;
using TheWebCalculator.Core.DataTransferObjects;
using TheWebCalculator.Models;

namespace TheWebCalculator.Controllers
{
    public class ClientServerCalculatorController : Controller
    {
        private readonly ICalculatorService _calculatorService;
        private readonly IMapper _mapper;

        public ClientServerCalculatorController(ICalculatorService calculatorService, 
            IMapper mapper)
        {
            _calculatorService = calculatorService;
            _mapper = mapper;
        }

        public IActionResult Index(MathExpressionDto dto)
        {
            var model = _mapper.Map<CalculatorModel>(dto);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddAdditionalOperation([FromQuery] decimal previousNumber,
            decimal currentNumber, MathOperation operation)
        {
            try
            {
                var dto = new MathExpressionDto()
                {
                    PreviousNumber = previousNumber,
                    CurrentNumber = currentNumber,
                    Operation = operation,
                };

                var newDto = _calculatorService
                    .AddAdditionOperation(dto);

                return Ok(newDto);
            }
            catch (OverflowException)
            {
                var dto = new MathExpressionDto()
                {
                    DisplayMessage = "Overflow"
                };
                return Ok(dto);
            }
            catch (DivideByZeroException)
            {
                var dto = new MathExpressionDto()
                {
                    DisplayMessage = "Cannot divide by zero"
                };
                return Ok(dto);
            }
            catch (ArgumentException ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine} {ex.StackTrace}");
                return BadRequest();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine} {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddSubtractionOperation([FromQuery] decimal previousNumber,
            decimal currentNumber, MathOperation operation)
        {
            try
            {
                var dto = new MathExpressionDto()
                {
                    PreviousNumber = previousNumber,
                    CurrentNumber = currentNumber,
                    Operation = operation,
                };

                var newDto = _calculatorService
                    .AddSubtractionOperation(dto);

                return Ok(newDto);
            }
            catch (OverflowException)
            {
                var dto = new MathExpressionDto()
                {
                    DisplayMessage = "Overflow"
                };
                return Ok(dto);
            }
            catch (DivideByZeroException)
            {
                var dto = new MathExpressionDto()
                {
                    DisplayMessage = "Cannot divide by zero"
                };
                return Ok(dto);
            }
            catch (ArgumentException ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine} {ex.StackTrace}");
                return BadRequest();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine} {ex.StackTrace}");
                return StatusCode(500);
            }
        }


        [HttpGet]
        public async Task<IActionResult> AddMultiplicationOperation([FromQuery] decimal previousNumber,
            decimal currentNumber, MathOperation operation)
        {
            try
            {
                var dto = new MathExpressionDto()
                {
                    PreviousNumber = previousNumber,
                    CurrentNumber = currentNumber,
                    Operation = operation,
                };

                var newDto = _calculatorService
                    .AddMultiplicationOperation(dto);

                return Ok(newDto);
            }
            catch (OverflowException)
            {
                var dto = new MathExpressionDto()
                {
                    DisplayMessage = "Overflow"
                };
                return Ok(dto);
            }
            catch (DivideByZeroException)
            {
                var dto = new MathExpressionDto()
                {
                    DisplayMessage = "Cannot divide by zero"
                };
                return Ok(dto);
            }
            catch (ArgumentException ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine} {ex.StackTrace}");
                return BadRequest();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine} {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddDivisionOperation([FromQuery] decimal previousNumber,
            decimal currentNumber, MathOperation operation)
        {
            try
            {
                var dto = new MathExpressionDto()
                {
                    PreviousNumber = previousNumber,
                    CurrentNumber = currentNumber,
                    Operation = operation,
                };

                var newDto = _calculatorService
                    .AddDivisionOperation(dto);

                return Ok(newDto);
            }
            catch (OverflowException)
            {
                var dto = new MathExpressionDto()
                {
                    DisplayMessage = "Overflow"
                };
                return Ok(dto);
            }
            catch (DivideByZeroException)
            {
                var dto = new MathExpressionDto()
                {
                    DisplayMessage = "Cannot divide by zero"
                };
                return Ok(dto);
            }
            catch (ArgumentException ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine} {ex.StackTrace}");
                return BadRequest();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine} {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> CalculateExpression([FromQuery] decimal previousNumber,
            decimal currentNumber, MathOperation operation)
        {
            try
            {
                var dto = new MathExpressionDto()
                {
                    PreviousNumber = previousNumber,
                    CurrentNumber = currentNumber,
                    Operation = operation,
                };

                dto.PreviousNumber = _calculatorService
                    .CalculateExpression(dto).CurrentNumber;

                dto.DisplayMessage = dto.PreviousNumber
                    .ToString("##,##0.############################", CultureInfo.InvariantCulture);

                return Ok(dto);
            }
            catch (OverflowException)
            {
                var dto = new MathExpressionDto()
                {
                    DisplayMessage = "Overflow"
                };
                return Ok(dto);
            }
            catch (DivideByZeroException)
            {
                var dto = new MathExpressionDto()
                {
                    DisplayMessage = "Cannot divide by zero"
                };
                return Ok(dto);
            }
            catch (ArgumentException ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine} {ex.StackTrace}");
                return BadRequest();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine} {ex.StackTrace}");
                return StatusCode(500);
            }

        }
    }
}
