async function showResult(data) {

    await setValueToInputDisplayAsync(data.currentNumber);
    let operationSymbol = await getOperationSymbolByNumber(data.operation)
    await setValueToPlaceholderDisplayAsync(data.previousNumber, operationSymbol);
}

async function showError(data) {

    await setValueToInputDisplayAsync(data.displayMessage);
    if (data.operation == 5) {
        await setResultToCalculatorStateAsync();
    }
    else {
        await setErrorToCalculatorStateAsync();
    }
    
    await cleanDisplayPlaceholder();
}