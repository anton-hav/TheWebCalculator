# TheWebCalculator

The project provides the ability to use two calculators: server side and client-server.

Each calculator provides the ability to perform the following operations: addition, subtract, divide, multiply, change sign, decimal point, memory plus, memory minus, memory recall, clear memory and all clear.

## Server side calculator.
This calculator performs GET request with every user action like entering a number or selecting a mathematical operation.

The server side calculator is written without using loops and with using conversion of numbers to strings as part of the HTTP request and output only.

## Client-server calculator
This calculator uses JavaScript to process user input. Actions related to entering numbers, points, sign changes and complete clearing - are performed on the client side (without sending a request to the server). When pressing buttons related to mathematical operations and working with memory - GET request to the server is performed. The result is displayed without full page re-rendering.

## Key features:
ASP.Net Core MVC, C#, JavaScript, Serilog, Automapper, Dependepcy Injection, Bootstrap
