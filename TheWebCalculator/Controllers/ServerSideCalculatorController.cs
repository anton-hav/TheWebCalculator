using System.Globalization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TheWebCalculator.Core;
using TheWebCalculator.Core.Abstractions;
using TheWebCalculator.Core.DataTransferObjects;
using TheWebCalculator.Models;

namespace TheWebCalculator.Controllers;

public class ServerSideCalculatorController : Controller
{
    private readonly ICalculatorService _calculatorService;
    private readonly IMapper _mapper;

    public ServerSideCalculatorController(ICalculatorService calculatorService,
        IMapper mapper)
    {
        _calculatorService = calculatorService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index(MathExpressionDto dto)
    {
        var model = _mapper.Map<CalculatorModel>(dto);

        return View(model);
    }

    [HttpGet]
    public IActionResult AddDigitToNumber(byte digit,
        CalculatorModel model)
    {
        try
        {
            var dto = _mapper.Map<MathExpressionDto>(model);

            var newDto = _calculatorService.AddDigitToNumber(digit,
                dto);

            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(newDto));
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
    public IActionResult InvertSign(CalculatorModel model)
    {
        try
        {
            var dto = _mapper.Map<MathExpressionDto>(model);

            var newDto = _calculatorService.InvertNumberSign(dto);

            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(newDto));
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
    public IActionResult AddPoint(CalculatorModel model)
    {
        try
        {
            var dto = _mapper.Map<MathExpressionDto>(model);

            var newDto = _calculatorService.AddPoint(dto);

            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(newDto));
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
    public IActionResult AddAdditionalOperation(CalculatorModel model)
    {
        try
        {
            var dto = _mapper.Map<MathExpressionDto>(model);

            var newDto = _calculatorService
                .AddAdditionOperation(dto);

            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(newDto));
        }
        catch (OverflowException)
        {
            var dto = new MathExpressionDto
            {
                DisplayMessage = "Overflow"
            };
            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(dto));
        }
        catch (DivideByZeroException)
        {
            var dto = new MathExpressionDto
            {
                DisplayMessage = "Cannot divide by zero"
            };
            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(dto));
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
    public IActionResult AddSubtractionOperation(CalculatorModel model)
    {
        try
        {
            var dto = _mapper.Map<MathExpressionDto>(model);

            var newDto = _calculatorService
                .AddSubtractionOperation(dto);

            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(newDto));
        }
        catch (OverflowException)
        {
            var dto = new MathExpressionDto
            {
                DisplayMessage = "Overflow"
            };
            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(dto));
        }
        catch (DivideByZeroException)
        {
            var dto = new MathExpressionDto
            {
                DisplayMessage = "Cannot divide by zero"
            };
            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(dto));
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
    public IActionResult AddMultiplicationOperation(CalculatorModel model)
    {
        try
        {
            var dto = _mapper.Map<MathExpressionDto>(model);

            var newDto = _calculatorService
                .AddMultiplicationOperation(dto);

            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(newDto));
        }
        catch (OverflowException)
        {
            var dto = new MathExpressionDto
            {
                DisplayMessage = "Overflow"
            };
            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(dto));
        }
        catch (DivideByZeroException)
        {
            var dto = new MathExpressionDto
            {
                DisplayMessage = "Cannot divide by zero"
            };
            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(dto));
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
    public IActionResult AddDivisionOperation(CalculatorModel model)
    {
        try
        {
            var dto = _mapper.Map<MathExpressionDto>(model);

            var newDto = _calculatorService
                .AddDivisionOperation(dto);
            

            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(newDto));
        }
        catch (OverflowException)
        {
            var dto = new MathExpressionDto
            {
                DisplayMessage = "Overflow"
            };
            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(dto));
        }
        catch (DivideByZeroException)
        {
            var dto = new MathExpressionDto
            {
                DisplayMessage = "Cannot divide by zero"
            };
            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(dto));
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
    public IActionResult CalculateExpression(CalculatorModel model)
    {
        try
        {
            var dto = _mapper.Map<MathExpressionDto>(model);

            var newDto = _calculatorService
                .CalculateExpression(dto);

            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(newDto));
        }
        catch (OverflowException)
        {
            var dto = new MathExpressionDto
            {
                DisplayMessage = "Overflow"
            };
            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(dto));
        }
        catch (DivideByZeroException)
        {
            var dto = new MathExpressionDto
            {
                DisplayMessage = "Cannot divide by zero"
            };
            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(dto));
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
    public IActionResult CleanAll()
    {
        try
        {
            var dto = new MathExpressionDto();

            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(dto));
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
    public IActionResult AddCurrentNumberToMemory(CalculatorModel model)
    {
        try
        {
            var dto = _mapper.Map<MathExpressionDto>(model);
            var newDto = _calculatorService.AddNumberToMemory(dto);

            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(newDto));
        }
        catch (OverflowException)
        {
            var dto = new MathExpressionDto
            {
                DisplayMessage = "Overflow"
            };
            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(dto));
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
    public IActionResult SubtractNumberFromMemory(CalculatorModel model)
    {
        try
        {
            var dto = _mapper.Map<MathExpressionDto>(model);
            var newDto = _calculatorService.SubtractNumberFromMemory(dto);

            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(newDto));
        }
        catch (OverflowException)
        {
            var dto = new MathExpressionDto
            {
                DisplayMessage = "Overflow"
            };
            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(dto));
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
    public IActionResult CleanMemory(CalculatorModel model)
    {
        try
        {
            var dto = _mapper.Map<MathExpressionDto>(model);
            var newDto = _calculatorService.MemoryClean(dto);

            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(newDto));
        }
        catch (OverflowException)
        {
            var dto = new MathExpressionDto
            {
                DisplayMessage = "Overflow"
            };
            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(dto));
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
    public IActionResult ReadFromMemory(CalculatorModel model)
    {
        try
        {
            var dto = _mapper.Map<MathExpressionDto>(model);
            var newDto = _calculatorService.MemoryRead(dto);

            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(newDto));
        }
        catch (OverflowException)
        {
            var dto = new MathExpressionDto
            {
                DisplayMessage = "Overflow"
            };
            return RedirectToAction("Index",
                "ServerSideCalculator",
                new RouteValueDictionary(dto));
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