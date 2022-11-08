async function getOperationStringNameBySymbol(symbol) {
    let operationName = "";
    if (symbol == "+") {
        operationName = "Addition";
    } else if (symbol == "-") {
        operationName = "Subtraction";
    } else if (symbol == "x") {
        operationName = "Multiplication";
    } else if (symbol == "÷") {
        operationName = "Division";
    } else if (symbol == "=") {
        operationName = "Result";
    } else operationName = "None";

    return operationName;
}


async function getOperationSymbolByNumber(number) {

    switch (number) {
        case 1:
            symbol = "+";
            break;
        case 2:
            symbol = "-";
            break;
        case 3:
            symbol = "x";
            break;
        case 4:
            symbol = "÷";
            break;
        case 5:
            symbol = "=";
            break;
        default:
            symbol = "";
    }

    return symbol;
}